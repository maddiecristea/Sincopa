using UnityEngine;
#if (ENABLE_INPUT_SYSTEM)
using UnityEngine.InputSystem;
#endif

namespace TarodevController {
    public class PlayerInput : MonoBehaviour {
#if (ENABLE_LEGACY_INPUT_MANAGER)
        public FrameInput GatherInput() {
            return new FrameInput {
                JumpDown = Input.GetButtonDown("Jump"),
                JumpHeld = Input.GetButton("Jump"),
                DashDown = Input.GetButtonDown("Dash"),

                X = Input.GetAxisRaw("Horizontal"),
                Y = Input.GetAxisRaw("Vertical")
            };
        }
#elif (ENABLE_INPUT_SYSTEM)
        private PlayerInputActions _actions;
        private InputAction _move, _jump, _dash;

        private void Awake() => _actions = new PlayerInputActions();

        private void OnEnable() {
            _move = _actions.Player.Move;
            _move.Enable();

            _jump = _actions.Player.Jump;
            _jump.Enable();

            _dash = _actions.Player.Dash;
            _dash.Enable();
        }

        private void OnDisable() {
            _move.Disable();
            _jump.Disable();
            _dash.Disable();
        }

        public FrameInput GatherInput() {
            return new FrameInput {
                JumpDown = _jump.WasPressedThisFrame(),
                JumpHeld = _jump.IsPressed(),
                DashDown = _dash.WasPressedThisFrame(),

                X = _move.ReadValue<Vector2>().x,
                Y = _move.ReadValue<Vector2>().y
            };
        }
#endif
    }
}