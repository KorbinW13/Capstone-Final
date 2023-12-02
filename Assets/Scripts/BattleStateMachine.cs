using AutoLayout3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lost
}

public enum TypeReaction
{
    Normal,
    Weak,
    Resist,
    Null,
    Drain
}

public class BattleStateMachine : MonoBehaviour
{
    public Camera MainCamera;
    public Camera BackCamera;
    public Camera FrontCamera;

    public RectTransform PlayerHUDPanel;
    public GameObject PlayerHUDprefab;

    public List<GameObject> PartyMembers = new List<GameObject>(); //to hold the game objects
    public List<UnitInfo> PassMembers = new List<UnitInfo>(); // to get their info easier
    int PartyTurn;
    int EnemyTurnCount;
    public List<UnitInfo>EnemyMembers = new List<UnitInfo>();
    public int enemyCount;
    public int deadCounter = 0;

    public GameObject enemyPrefab;
    [SerializeField] GameObject ActionPanel;
    [SerializeField] GameObject EnemySelectionPanel;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public TurnState turnState;

    public UnitInfo playerInfo;
    public UnitInfo enemyInfo;

    public BattleHUD playerHUD;
    public BattleHUD[] battleHUD;
    public EnemyHPSlider enemyHUD;

    DamageDisplay DamageDisplay;

    public EventDisplay eventDisplay;
    public GameObject BattleResultsScreen;
    public ActionSkills BasicAttack;

    public enum MenuOptions //for the first menu selection
    {
        Attack,
        Skills,
        Items,
        Pass
    }

    public TypeReaction Reaction;

    private void Awake()
    {
        battleHUD = new BattleHUD[PartyMembers.Count];
        PartyTurn = 0;
        EnemyTurnCount = 0;
    }

    void Start()
    {
        MainCamera.enabled = true;// Used for future implementation
        turnState = TurnState.Start;//Sets TurnSate to Start
        Debug.Log(turnState);
        enemyCount = Random.Range(1, 5); // determines the amount of Enemies 
        StartCoroutine(SetupBattle()); //Sets up our Battle
        
    }

    IEnumerator SetupBattle()
    {
        //Party Member Creation
        for (int index = 0; index < PartyMembers.Count; index++)
        {
            PassMembers[index] = CreatePartyMember(index);
            //Assigns a UI element for each Party Memeber
            battleHUD[index] = CreatePartyHUDs(PassMembers[index]);
            //Updates Party Members Location on the map
            playerBattleStation.GetComponent<XAxisLayoutGroup3D>().UpdateLayout();
        }

        //Enemy Creation based on random amount
        for (int i = 0; i < enemyCount; i++)
        {
            EnemyMembers.Add(CreateEnemies(i));
            //Upates the Enemies Location on the map
            enemyBattleStation.GetComponent<XAxisLayoutGroup3D>().UpdateLayout();
        }

        yield return new WaitForEndOfFrame();
        turnState = TurnState.PlayerTurn; //Sets our first real TurnState to the Player's
        PlayerTurn(); //Starts the player's turn
    }

    void PlayerTurn()
    {
        Debug.Log(turnState);
        EnemyTurnCount = 0;
        //Determines what Party Member's Turn it is
        if (PartyTurn < PassMembers.Count)
        {
            playerInfo = PassMembers[PartyTurn];
            if (PassMembers[0].currHP == 0)//Our lose condition
            {
                turnState = TurnState.Lost;
                EndBattle();
            }
            else if (PassMembers[PartyTurn].currHP == 0 && PassMembers[0].currHP != 0)
            {
                PartyTurn++;
                PlayerTurn();//Restarts the TurnSelect to next Party Member
            }
            else
            {
                Debug.Log("Party Member " + PartyTurn);
                ActionPanel.SetActive(true); //Activates the player's command window
            }
        }
    }

    IEnumerator NormalAttack(UnitInfo user, int damage, UnitInfo target)
    {
        Debug.Log("Normal Attack");
        //Damage with the base attack to target
        user.damage = damage;
        //Displays who attacks who in the eventDisplay
        eventDisplay.Enable(user.UnitName + " Attacked " + target.UnitName);
        //Finds the DamageDisplay component of the target that's being attacked
        DamageDisplay = target.transform.GetComponent<DamageDisplay>();
        user.animator.Play("HookPunch");//this is default attack animation
        if (AccuracyCheck(target) == true)//This is our accuracy check to see if we hit or not
        {
            if (turnState == TurnState.PlayerTurn)
            {
                //Get the Enemy HP Bar and then Enable it
                enemyHUD = target.transform.GetComponent<EnemyHPSlider>();
                yield return new WaitForSeconds(1.0f);
                enemyHUD.EnableBar();
                //check to see if enemy is dead
                bool isDead = target.TakeDamage(user.damage, ReturnReaction(BasicAttack, target));
                yield return new WaitForSeconds(1.0f);

                //update enemy Hud here and display damage dealt
                DamageDisplay.EnableText();
                DamageDisplay.DamageText(user.damage / (int)Mathf.Sqrt(target.endurance * 8 + target.armorDefense), ReturnReaction(BasicAttack, target));
                if (ReturnReaction(BasicAttack, target) != TypeReaction.Null)
                {
                    //this is how i update the enemy health bar and make it look animated
                    enemyHUD.ChangeHealth(damage / (int)Mathf.Sqrt(target.endurance * 8 + target.armorDefense), ReturnReaction(BasicAttack, target));
                    yield return new WaitWhile(() => enemyHUD.isDone == false);//waits until "animation" is done
                }
                yield return new WaitForSeconds(1.0f);
                enemyHUD.DisableBar(); //to disable the bar
                EndTurn(isDead);//Ends the turn and updates information based on if dead or not and TurnState.
            }
            else if (turnState == TurnState.EnemyTurn)
            {
                DamageDisplay.EnableText();
                DamageDisplay.DamageText(user.damage / (int)Mathf.Sqrt(target.endurance * 8 + target.armorDefense), ReturnReaction(BasicAttack, target));
                bool isDead = target.TakeDamage(user.damage, ReturnReaction(BasicAttack, target));
                int position = PassMembers.IndexOf(target);//this is to easily determine who got attacked on my end to update their HUD
                battleHUD[position].SetHUD(target);//updates the party member's HUD info with current info
                yield return new WaitForSeconds(1.0f);
                EndTurn(isDead);
            }
        }
        else
        {
            DamageDisplay.EnableText();
            DamageDisplay.Miss();//Displays that it was a MISS
            NextTurn();//cycle to the next turn
        }
    }

    IEnumerator SkillAttack(UnitInfo user, ActionSkills skill, int damage, UnitInfo target)//Lots of repeats from Normal Attack
    {
        Debug.Log("Skill Attack");
        //Damage with the base attack to enemy
        user.damage = DamageOnReaction(ReturnReaction(skill, target), damage);
        DamageDisplay = target.transform.GetComponent<DamageDisplay>();
        eventDisplay.Enable(skill.skillName);
        user.animator.Play("HookPunch");//this is default attack animation
        if (AccuracyCheck(target) == true)//This is our accuracy check to see if we hit or not
        {
            if (turnState == TurnState.PlayerTurn)
            {
                //Get the Enemy HP Bar and then Enable it
                enemyHUD = target.transform.GetComponent<EnemyHPSlider>();
                yield return new WaitForSeconds(1.0f);
                enemyHUD.EnableBar();
                //Deals damage to target with this function
                bool isDead = target.TakeDamage(user.damage, ReturnReaction(skill, target));
                yield return new WaitForSeconds(1.0f);

                //update enemy Hud here
                DamageDisplay.EnableText();
                DamageDisplay.DamageText(user.damage / (int)Mathf.Sqrt(target.endurance * 8 + target.armorDefense), ReturnReaction(skill, target));
                if (ReturnReaction(skill, target) != TypeReaction.Null)
                {
                    //this is how i update the enemy health bar and make it look animated
                    enemyHUD.ChangeHealth(user.damage / (int)Mathf.Sqrt(target.endurance * 8 + target.armorDefense), ReturnReaction(skill, target));
                    yield return new WaitWhile(() => enemyHUD.isDone == false);
                }
                yield return new WaitForSeconds(1.0f);
                enemyHUD.DisableBar(); //to disable the bar
                EndTurn(isDead);//ends the turn
            }
            else if (turnState == TurnState.EnemyTurn)
            {
                //eventDisplay.Enable(user.UnitName + " Attacks " + target.UnitName + " with " + skill.skillName);
                bool isDead = target.TakeDamage(user.damage, ReturnReaction(skill, target));

                yield return new WaitForSeconds(1.0f);

                DamageDisplay.EnableText();
                DamageDisplay.DamageText(user.damage / (int)Mathf.Sqrt(target.endurance * 8 + target.armorDefense), ReturnReaction(skill, target));
                int position = PassMembers.IndexOf(target);
                battleHUD[position].SetHUD(target);
                yield return new WaitForSeconds(1.0f);
                EndTurn(isDead);//ends the turn
            }
        }
        else
        {
            DamageDisplay.EnableText();
            DamageDisplay.Miss();//Displays that it was a MISS
            NextTurn();//cycle to the next turn
        }
    }


    void EndBattle() //Not finished yet
    {
        if(turnState == TurnState.Won) 
        {
            //Temp
            Debug.Log("Fight Over: Win");
            BattleResultsScreen.SetActive(true);
        }
        else if (turnState == TurnState.Lost)
        {
            //Temp
            Debug.Log("You lost");
            BattleResultsScreen.SetActive(true);
        }
    }


    public int RandomPartyMember()//calls for random party memeber for the enemy to attack
    {
        int random;
        random = Random.Range(0, PassMembers.Count - 1);
        return random;
    }

    public void EnemyTurn()
    {
        PartyTurn = 0;//This is to reset the Player's Turns
        Debug.Log(turnState);

        if (EnemyTurnCount < EnemyMembers.Count)
        {
            enemyInfo = EnemyMembers[EnemyTurnCount];
            if (EnemyMembers[EnemyTurnCount].currHP == 0)
            {
                Debug.Log("Enemy: " + EnemyTurnCount + " Can't Attack!");
                EnemyTurnCount++;
                EnemyTurn();//Repeats function until there is an enemy with HP
            }
            else
            {
                Debug.Log("Enemy " + EnemyTurnCount + "'s Turn");
                EnemyActionSelection();//Where the enemy makes it's actual turn information
            }
        }
        else
        {
            turnState = TurnState.PlayerTurn;
            PlayerTurn();
        }
    }

    public void EnemyActionSelection()
    {
        //determining who to hit
        int Attacked = RandomPartyMember(); // randomly selects from the members availble to hit
        playerInfo = PassMembers[Attacked]; // sets who gets hit

        if (playerInfo.currHP == 0)
        {
            Debug.Log("Selected Dead Memember");
            while (playerInfo.currHP == 0)// finds a player who's not dead already
            {
                Attacked = RandomPartyMember();
                playerInfo = PassMembers[Attacked];
            }
        }

        Debug.Log(playerInfo.name + " is Attacked!");
        int randomAction = Random.Range(0, 100);// I set a high limit just for range to be wider to maybe add other actions
        if (randomAction >= 50)//Normal Attack
        {
            StartCoroutine(NormalAttack(enemyInfo, (int)(Mathf.Sqrt(enemyInfo.weaponPower / 2) * Mathf.Sqrt(enemyInfo.strength)), playerInfo));
        }
        else //Skill Attack
        {
            ActionSkills selectedSkill;
            if (enemyInfo.SkillList != null)//checks to see if enemy even has skills
            {
                int randomSkill = Random.Range(0, enemyInfo.SkillList.Count - 1); //selects random skill
                selectedSkill = enemyInfo.SkillList[randomSkill];
                if (SkillCostCheck(enemyInfo, selectedSkill) == true)
                {
                    switch(selectedSkill.costType)//Math behind how much skills cost to the enemy and starts the SkillAttack
                    {
                        case ActionSkills.CostType.MP:
                            Debug.Log(selectedSkill.name + " Selected");
                            enemyInfo.currMP = enemyInfo.currMP - selectedSkill.cost;
                            StartCoroutine(SkillAttack(enemyInfo, selectedSkill, (int)(Mathf.Sqrt(selectedSkill.damageValue) * Mathf.Sqrt(enemyInfo.magic)), playerInfo));
                            break;
                        case ActionSkills.CostType.HP:
                            Debug.Log(selectedSkill.name + " Selected");
                            enemyInfo.currHP = enemyInfo.currHP - Mathf.RoundToInt((enemyInfo.baseHP * selectedSkill.cost) / 100);
                            StartCoroutine(SkillAttack(enemyInfo,selectedSkill, (int)(Mathf.Sqrt(selectedSkill.damageValue) * Mathf.Sqrt(enemyInfo.strength)),playerInfo));
                            break;
                    }
                }
                else //If the enemy had no MP to do the skill it will revert back to a normal attack
                {
                    Debug.Log("Override to Normal Attack");
                    StartCoroutine(NormalAttack(enemyInfo, (int)(Mathf.Sqrt(enemyInfo.weaponPower / 2) * Mathf.Sqrt(enemyInfo.strength)), playerInfo));
                }
            }
            else //If the enemy had no skills it will revert back to a normal attack
            {
                Debug.Log("Override to Normal Attack");
                StartCoroutine(NormalAttack(enemyInfo, (int)(Mathf.Sqrt(enemyInfo.weaponPower / 2) * Mathf.Sqrt(enemyInfo.strength)), playerInfo));
            }
        }
    }


    //Function to easily determine next turn
    public void NextTurn()
    {
        if (turnState == TurnState.PlayerTurn)
        {
            PartyTurn++;
            if (PartyTurn < PassMembers.Count)
            {
                PlayerTurn();
            }
            else
            {
                turnState = TurnState.EnemyTurn;
                EnemyTurn();
            }
        }
        else if (turnState == TurnState.EnemyTurn)
        {
            EnemyTurnCount++;
            if (EnemyTurnCount < EnemyMembers.Count)
            {
                EnemyTurn();
            }
            else
            {
                turnState = TurnState.PlayerTurn;
                PlayerTurn();
            }
        }
    }

    public void EndTurn(bool isDead)
    {
        if (turnState == TurnState.PlayerTurn)
        {
            if (isDead)
            {
                deadCounter++;
                //End the battle if all is dead
                if (deadCounter == EnemyMembers.Count)
                {
                    turnState = TurnState.Won;
                    EndBattle();
                }
                else
                {
                    //End Turn
                    NextTurn();
                }

            }
            else
            {
                //End Turn
                NextTurn();
            }
        }
        else if (turnState == TurnState.EnemyTurn)
        {
            if (isDead)
            {
                //End the battle if Player 1 is dead
                if (PassMembers[0].currHP == 0)
                {
                    turnState = TurnState.Lost;
                    EndBattle();
                }
                else
                {
                    NextTurn();
                }
            }
            else
            {
                NextTurn();
            }
        }
    }

    //Function to pass turn to next party memeber
    public void TurnPass()
    {
        PartyTurn++;
        if (PartyTurn < PassMembers.Count)
        {
            ActionPanel.SetActive(false);
            PlayerTurn();
        }
        else
        {
            ActionPanel.SetActive(false);
            turnState = TurnState.EnemyTurn;
            EnemyTurn();
        }
    }

    //Party Creation happens here
    UnitInfo CreatePartyMember(int i)
    {
        var SpawnIn = Instantiate(PartyMembers[i], playerBattleStation); ;
        var Member = SpawnIn.GetComponent<UnitInfo>();
        Member.name = "Member " + (i+1).ToString() + ": " + Member.UnitName;
        return Member;
    }

    BattleHUD CreatePartyHUDs(UnitInfo member)
    {
        var HUD = Instantiate(PlayerHUDprefab, PlayerHUDPanel);
        var PlayerHUD = HUD.GetComponent<BattleHUD>();
        PlayerHUD.name = member.name + "'s HUD";
        PlayerHUD.SetHUD(member);
        return PlayerHUD;
    }

    //Enemy party creation
    UnitInfo CreateEnemies(int i)
    {
        var SpawnIn = Instantiate(enemyPrefab, enemyBattleStation); ;
        var Member = SpawnIn.GetComponent<UnitInfo>();
        Member.name = "Enemy " + (i + 1).ToString();
        Member.UnitName = "Eve " + (i + 1).ToString();
        return Member;
    }


    /// <summary>
    /// The UI button functions section
    /// </summary>


    //Basic Attack Button function
    public void OnAttackButton()
    {
        Debug.Log(turnState);
        
        int damage = (int)Mathf.Sqrt(playerInfo.weaponPower / 2) * (int)Mathf.Sqrt(playerInfo.strength);
        // to artifically change turn
        if (turnState != TurnState.PlayerTurn)
        {
            return;
        }

        StartCoroutine(NormalAttack(playerInfo,damage, enemyInfo));
    }

    //Basic Skill Attack Button funciton
    public void OnSkillButton(ActionSkills Skill)
    {
        int damage = 0;
        Debug.Log(turnState);

        //here will be skill damage version
        
        switch(Skill.costType)
        {
            case ActionSkills.CostType.MP:

                playerInfo.currMP = playerInfo.currMP - Skill.cost;
                battleHUD[PartyTurn].SetHUD(playerInfo);
                damage = (int)Mathf.Sqrt(Skill.damageValue) * (int)Mathf.Sqrt(playerInfo.magic);
                Debug.Log("Skill damage: " + damage);
                break;

            case ActionSkills.CostType.HP:

                playerInfo.currHP = playerInfo.currHP - Mathf.RoundToInt((playerInfo.baseHP * Skill.cost)/100);//subtract perentage from hp
                battleHUD[PartyTurn].SetHUD(playerInfo);
                damage = (int)Mathf.Sqrt(Skill.damageValue) * (int)Mathf.Sqrt(playerInfo.strength);
                Debug.Log("Skill damage: " + damage);
                break;
        }

        if (turnState != TurnState.PlayerTurn)
        {
            return;
        }

        StartCoroutine(SkillAttack(playerInfo,Skill,damage,enemyInfo));
    }
    
    //checking is user can even use the skill
    public bool SkillCostCheck(UnitInfo user, ActionSkills Skill)
    {
        switch(Skill.costType)
        {
            default:
                if (user.currHP - Mathf.RoundToInt((user.baseHP * Skill.cost) / 100) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case ActionSkills.CostType.MP:
                if (user.currMP - Skill.cost >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
    }


    //Needs further Refining
    public bool AccuracyCheck(UnitInfo target)
    {
        int Accuracy = Random.Range(0, 100);
        if (Accuracy >= target.agility + (target.luck/4))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //This is how Elemental Type Reactions work
    public TypeReaction ReturnReaction(ActionSkills skill, UnitInfo target)
    {
        if (target.typeWeak.HasFlag(skill.damageType))
        {
            Debug.Log("Weak");
            return TypeReaction.Weak;
        }
        else if (target.typeResist.HasFlag(skill.damageType))
        {
            Debug.Log("Resist");
            return TypeReaction.Resist;
        }
        else if (target.typeNull.HasFlag(skill.damageType))
        {
            Debug.Log("Null");
            return TypeReaction.Null;
        }
        else if (target.typeDrain.HasFlag(skill.damageType))
        {
            Debug.Log("Drain");
            return TypeReaction.Drain;
        }
        else
        {
            return TypeReaction.Normal;
        }
    }

    // Determines the damage value based on Reaction
    public int DamageOnReaction(TypeReaction reaction, int damage)
    {
        switch (reaction)
        {
            default: //Normal I think
                return damage;
            case TypeReaction.Weak:
                damage = damage * 2;
                return damage;
            case TypeReaction.Resist:
                damage = damage / 2;
                return damage;
            case TypeReaction.Null:
                damage = 0;
                return damage;
            case TypeReaction.Drain:
                return damage;
        }
    }
}