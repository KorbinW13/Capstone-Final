//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSystem.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputSystem : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""6c023988-c955-4f15-a71c-8c041b47e77e"",
            ""actions"": [
                {
                    ""name"": ""Primary Action"",
                    ""type"": ""Button"",
                    ""id"": ""162d449d-545f-4212-8750-7a2ff2e2f7be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""0da24fe9-6cd5-496a-ac64-6b0f5e6d75e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""6f2c8af6-1982-41ea-907d-4e4e241c24ae"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Alt Primary Action"",
                    ""type"": ""Button"",
                    ""id"": ""f2172a27-4b25-412e-83ed-2ad154318e6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll Up"",
                    ""type"": ""Button"",
                    ""id"": ""fe1a4896-8fd8-4c0c-9689-626346c8cb12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll Down"",
                    ""type"": ""Button"",
                    ""id"": ""01eedaf7-9d0f-4de3-9e0f-167165da1fd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""0da2515c-e545-4cb3-9e8a-e1b81c2cc720"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Scroll Left"",
                    ""type"": ""Button"",
                    ""id"": ""9371b05b-e53c-4519-9578-cdf08d4739ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll Right"",
                    ""type"": ""Button"",
                    ""id"": ""d5f85f0a-abba-47c4-a57f-083c07e734be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Debug Key"",
                    ""type"": ""Button"",
                    ""id"": ""c6259345-26c6-4c5e-a160-4c541b356e98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ab4efec8-09af-4ddd-9de0-d536bf77d33e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Primary Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6cef189-f9c0-4a77-aa59-494b05bf463c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Primary Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0257792-9ff8-4d5e-b2e3-f7e1c5659cbd"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b14e7f8-56d1-43f3-bd80-70fd48106ddf"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a6d0e8af-e1dc-4c91-9cb6-de72869e8698"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4347fa27-70fe-4ee3-8f27-2a064f72eba8"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""caf95293-ee06-4b91-8865-4b3de04417b6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Alt Primary Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""238cf55a-c0d6-49f6-bfaf-8a86c01b7910"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Scroll Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54094022-b5eb-479a-ac2d-a60389e22db1"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Scroll Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fc8dc44-a6d2-46ce-a989-8c15db76434e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Scroll Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87464f75-aba5-4ea7-8d5d-c539515cc14f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Scroll Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd70334e-dc36-4ba7-ba08-ea2f6aaddede"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Scroll Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df7a0b36-ea0f-4be0-bddb-103bff3b5e50"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Scroll Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""188825b9-16b2-47a7-b73a-67adba6174cf"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8313d18b-ac21-420b-b3c6-0c6e782a9c89"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Scroll Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""120b58e0-c8fc-4800-99a0-6b08e51ed965"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Scroll Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a509d22-6394-447c-bfb9-6e7d1060d858"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Debug Key"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_PrimaryAction = m_UI.FindAction("Primary Action", throwIfNotFound: true);
        m_UI_Back = m_UI.FindAction("Back", throwIfNotFound: true);
        m_UI_Scroll = m_UI.FindAction("Scroll", throwIfNotFound: true);
        m_UI_AltPrimaryAction = m_UI.FindAction("Alt Primary Action", throwIfNotFound: true);
        m_UI_ScrollUp = m_UI.FindAction("Scroll Up", throwIfNotFound: true);
        m_UI_ScrollDown = m_UI.FindAction("Scroll Down", throwIfNotFound: true);
        m_UI_MousePosition = m_UI.FindAction("MousePosition", throwIfNotFound: true);
        m_UI_ScrollLeft = m_UI.FindAction("Scroll Left", throwIfNotFound: true);
        m_UI_ScrollRight = m_UI.FindAction("Scroll Right", throwIfNotFound: true);
        m_UI_DebugKey = m_UI.FindAction("Debug Key", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_PrimaryAction;
    private readonly InputAction m_UI_Back;
    private readonly InputAction m_UI_Scroll;
    private readonly InputAction m_UI_AltPrimaryAction;
    private readonly InputAction m_UI_ScrollUp;
    private readonly InputAction m_UI_ScrollDown;
    private readonly InputAction m_UI_MousePosition;
    private readonly InputAction m_UI_ScrollLeft;
    private readonly InputAction m_UI_ScrollRight;
    private readonly InputAction m_UI_DebugKey;
    public struct UIActions
    {
        private @InputSystem m_Wrapper;
        public UIActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryAction => m_Wrapper.m_UI_PrimaryAction;
        public InputAction @Back => m_Wrapper.m_UI_Back;
        public InputAction @Scroll => m_Wrapper.m_UI_Scroll;
        public InputAction @AltPrimaryAction => m_Wrapper.m_UI_AltPrimaryAction;
        public InputAction @ScrollUp => m_Wrapper.m_UI_ScrollUp;
        public InputAction @ScrollDown => m_Wrapper.m_UI_ScrollDown;
        public InputAction @MousePosition => m_Wrapper.m_UI_MousePosition;
        public InputAction @ScrollLeft => m_Wrapper.m_UI_ScrollLeft;
        public InputAction @ScrollRight => m_Wrapper.m_UI_ScrollRight;
        public InputAction @DebugKey => m_Wrapper.m_UI_DebugKey;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @PrimaryAction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPrimaryAction;
                @PrimaryAction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPrimaryAction;
                @PrimaryAction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPrimaryAction;
                @Back.started -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @Scroll.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScroll;
                @AltPrimaryAction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnAltPrimaryAction;
                @AltPrimaryAction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnAltPrimaryAction;
                @AltPrimaryAction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnAltPrimaryAction;
                @ScrollUp.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollUp;
                @ScrollUp.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollUp;
                @ScrollUp.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollUp;
                @ScrollDown.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollDown;
                @ScrollDown.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollDown;
                @ScrollDown.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollDown;
                @MousePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePosition;
                @ScrollLeft.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollLeft;
                @ScrollLeft.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollLeft;
                @ScrollLeft.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollLeft;
                @ScrollRight.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollRight;
                @ScrollRight.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollRight;
                @ScrollRight.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollRight;
                @DebugKey.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDebugKey;
                @DebugKey.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDebugKey;
                @DebugKey.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDebugKey;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryAction.started += instance.OnPrimaryAction;
                @PrimaryAction.performed += instance.OnPrimaryAction;
                @PrimaryAction.canceled += instance.OnPrimaryAction;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
                @AltPrimaryAction.started += instance.OnAltPrimaryAction;
                @AltPrimaryAction.performed += instance.OnAltPrimaryAction;
                @AltPrimaryAction.canceled += instance.OnAltPrimaryAction;
                @ScrollUp.started += instance.OnScrollUp;
                @ScrollUp.performed += instance.OnScrollUp;
                @ScrollUp.canceled += instance.OnScrollUp;
                @ScrollDown.started += instance.OnScrollDown;
                @ScrollDown.performed += instance.OnScrollDown;
                @ScrollDown.canceled += instance.OnScrollDown;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @ScrollLeft.started += instance.OnScrollLeft;
                @ScrollLeft.performed += instance.OnScrollLeft;
                @ScrollLeft.canceled += instance.OnScrollLeft;
                @ScrollRight.started += instance.OnScrollRight;
                @ScrollRight.performed += instance.OnScrollRight;
                @ScrollRight.canceled += instance.OnScrollRight;
                @DebugKey.started += instance.OnDebugKey;
                @DebugKey.performed += instance.OnDebugKey;
                @DebugKey.canceled += instance.OnDebugKey;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IUIActions
    {
        void OnPrimaryAction(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnAltPrimaryAction(InputAction.CallbackContext context);
        void OnScrollUp(InputAction.CallbackContext context);
        void OnScrollDown(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnScrollLeft(InputAction.CallbackContext context);
        void OnScrollRight(InputAction.CallbackContext context);
        void OnDebugKey(InputAction.CallbackContext context);
    }
}
