using System;
using UnityEngine;

namespace TarodevController {
    public struct FrameInput {
        public float X, Y;
        public bool JumpDown;
        public bool JumpHeld;
        public bool DashDown;
    }

    public interface IPlayerController {
        public FrameInput Input { get; }
        public Vector2 RawMovement { get; }
        public bool Grounded { get; }

        public event Action<bool> OnGroundedChanged;
        public event Action OnJumping, OnDoubleJumping;
        public event Action<bool> OnDashingChanged;
        public event Action<bool> OnCrouchingChanged;

        /// <summary>
        /// Add force to the character
        /// </summary>
        /// <param name="force">Force to be applied to the controller</param>
        /// <param name="mode">The force application mode</param>
        /// <param name="cancelMovement">Cancel the current velocity of the player to provide a reliable reaction</param>
        public void AddForce(Vector2 force, PlayerForce mode = PlayerForce.Burst, bool cancelMovement = true);
    }

    public interface IPlayerEffector {
        public Vector2 EvaluateEffector();
    }

    public enum PlayerForce {
        /// <summary>
        /// Added directly to the players movement speed, to be controlled by the standard deceleration
        /// </summary>
        Burst,

        /// <summary>
        /// An additive force handled by the decay system
        /// </summary>
        Decay
    }
}