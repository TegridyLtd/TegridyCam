// GENERATED AUTOMATICALLY FROM 'Assets/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""db31b45f-7a25-46cc-be37-46256cc6ee53"",
            ""actions"": [
                {
                    ""name"": ""ChangeCamRig"",
                    ""type"": ""Button"",
                    ""id"": ""57c0138f-c08a-4e34-9ffa-251e88cbb2ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeCamConfig"",
                    ""type"": ""Button"",
                    ""id"": ""4d6ef189-43b4-473c-8d78-00821defa5b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeMode"",
                    ""type"": ""Button"",
                    ""id"": ""5cc80181-5b7a-401d-9e26-3106d7bd37d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeModeConfig"",
                    ""type"": ""Button"",
                    ""id"": ""d2cd918a-1135-48c7-ab14-31e59223eaa4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CamZoom"",
                    ""type"": ""Value"",
                    ""id"": ""8e11db45-6588-4d82-8429-5504c1b073b9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""16a35da3-a475-4c8b-9331-038d4a9b3487"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4ab2146e-41ab-4681-bb98-3e32742fd39e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""76570fdb-01a6-41bd-9cbd-dbd01ec5f719"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5ac4e3c6-1e36-4106-9591-f1180a7d4efa"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCamRig"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c15f0d2d-c2e8-457b-853b-e2e393c6475c"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCamRig"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e5400b1-2a30-4626-9685-56c0f716f393"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a861e9bd-e6c9-46ba-a1a3-7ed9236d3c39"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCamConfig"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4dd01be-bdba-4c7b-a35c-3fa0adb57daf"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCamConfig"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""542e3d48-c1f6-4901-bf32-edbdfc6b02aa"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94282006-3095-455f-aa02-8d3baff7fdf7"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.05,y=0.05)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b96fb656-2443-4865-8f29-c2e663646406"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5514bafb-3808-4585-9570-262d9be5f210"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeModeConfig"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c110aa2-7391-4e3b-bdab-af50dae46eae"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""2efa9318-76b2-48ea-92e9-989777fcf71e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5c075403-1fb1-4f37-aa00-60db9469b7b6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""22250672-23d3-4a76-b730-b46682d5d136"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d2d1de4a-aa78-47ac-85fc-6625abf609a0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a9c3e0d1-4c6b-4736-95ec-fe2a225730ba"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a42259b8-d1ab-470a-835e-1ab7dc12ae72"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""499597f8-7e64-45a3-9c45-07a2c31b74d6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f851e75b-5b63-448e-b6cf-38709f2bf0fc"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
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
        }
    ]
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_ChangeCamRig = m_Camera.FindAction("ChangeCamRig", throwIfNotFound: true);
        m_Camera_ChangeCamConfig = m_Camera.FindAction("ChangeCamConfig", throwIfNotFound: true);
        m_Camera_ChangeMode = m_Camera.FindAction("ChangeMode", throwIfNotFound: true);
        m_Camera_ChangeModeConfig = m_Camera.FindAction("ChangeModeConfig", throwIfNotFound: true);
        m_Camera_CamZoom = m_Camera.FindAction("CamZoom", throwIfNotFound: true);
        m_Camera_Look = m_Camera.FindAction("Look", throwIfNotFound: true);
        m_Camera_Move = m_Camera.FindAction("Move", throwIfNotFound: true);
        m_Camera_Rotate = m_Camera.FindAction("Rotate", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_ChangeCamRig;
    private readonly InputAction m_Camera_ChangeCamConfig;
    private readonly InputAction m_Camera_ChangeMode;
    private readonly InputAction m_Camera_ChangeModeConfig;
    private readonly InputAction m_Camera_CamZoom;
    private readonly InputAction m_Camera_Look;
    private readonly InputAction m_Camera_Move;
    private readonly InputAction m_Camera_Rotate;
    public struct CameraActions
    {
        private @NewControls m_Wrapper;
        public CameraActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChangeCamRig => m_Wrapper.m_Camera_ChangeCamRig;
        public InputAction @ChangeCamConfig => m_Wrapper.m_Camera_ChangeCamConfig;
        public InputAction @ChangeMode => m_Wrapper.m_Camera_ChangeMode;
        public InputAction @ChangeModeConfig => m_Wrapper.m_Camera_ChangeModeConfig;
        public InputAction @CamZoom => m_Wrapper.m_Camera_CamZoom;
        public InputAction @Look => m_Wrapper.m_Camera_Look;
        public InputAction @Move => m_Wrapper.m_Camera_Move;
        public InputAction @Rotate => m_Wrapper.m_Camera_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @ChangeCamRig.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeCamRig;
                @ChangeCamRig.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeCamRig;
                @ChangeCamRig.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeCamRig;
                @ChangeCamConfig.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeCamConfig;
                @ChangeCamConfig.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeCamConfig;
                @ChangeCamConfig.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeCamConfig;
                @ChangeMode.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeMode;
                @ChangeMode.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeMode;
                @ChangeMode.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeMode;
                @ChangeModeConfig.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeModeConfig;
                @ChangeModeConfig.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeModeConfig;
                @ChangeModeConfig.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeModeConfig;
                @CamZoom.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnCamZoom;
                @CamZoom.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnCamZoom;
                @CamZoom.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnCamZoom;
                @Look.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLook;
                @Move.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ChangeCamRig.started += instance.OnChangeCamRig;
                @ChangeCamRig.performed += instance.OnChangeCamRig;
                @ChangeCamRig.canceled += instance.OnChangeCamRig;
                @ChangeCamConfig.started += instance.OnChangeCamConfig;
                @ChangeCamConfig.performed += instance.OnChangeCamConfig;
                @ChangeCamConfig.canceled += instance.OnChangeCamConfig;
                @ChangeMode.started += instance.OnChangeMode;
                @ChangeMode.performed += instance.OnChangeMode;
                @ChangeMode.canceled += instance.OnChangeMode;
                @ChangeModeConfig.started += instance.OnChangeModeConfig;
                @ChangeModeConfig.performed += instance.OnChangeModeConfig;
                @ChangeModeConfig.canceled += instance.OnChangeModeConfig;
                @CamZoom.started += instance.OnCamZoom;
                @CamZoom.performed += instance.OnCamZoom;
                @CamZoom.canceled += instance.OnCamZoom;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    private int m_PlayerSchemeIndex = -1;
    public InputControlScheme PlayerScheme
    {
        get
        {
            if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
            return asset.controlSchemes[m_PlayerSchemeIndex];
        }
    }
    public interface ICameraActions
    {
        void OnChangeCamRig(InputAction.CallbackContext context);
        void OnChangeCamConfig(InputAction.CallbackContext context);
        void OnChangeMode(InputAction.CallbackContext context);
        void OnChangeModeConfig(InputAction.CallbackContext context);
        void OnCamZoom(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}
