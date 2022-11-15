using UnityEngine;

namespace TarodevController {
    [CreateAssetMenu]
    public class ScriptableStats : ScriptableObject {
        [Header("MOVEMENT")] [Tooltip("The players capacity to gain speed")]
        public float Acceleration = 120;

        [Tooltip("The top horizontal movement speed")]
        public float MaxSpeed = 14;

        [Tooltip("The pace at which the player comes to a stop")]
        public float Deceleration = 60;

        [Tooltip("Movement loss after stopping input mid-air")]
        public float AirDecelerationPenalty = 0.5f;

        [Tooltip("A constant downward force applied while grounded. Helps on vertical moving platforms and slopes")] [Range(0, -10)]
        public float GroundingForce = -1.5f;

        [Tooltip("Allow speed creeping on a controller. Lightly tilt for slow speed.")]
        public bool AllowCreeping;

        [Header("CROUCHING")] [Tooltip("A dead-zone for controllers to prevent unintended crouching")]
        public float CrouchInputThreshold = -0.5f;

        [Tooltip("A speed multiplier while crouching")]
        public float CrouchSpeedPenalty = 0.5f;

        [Tooltip("The amount of frames it takes to hit the full crouch speed penalty. Higher values provide more crouch sliding")]
        public int CrouchSlowdownFrames = 20;

        [Tooltip("Detection height offset from the top of the standing collider. Smaller values risk collisions when standing up")]
        public float CrouchBufferCheck = 0.1f;

        [Header("JUMP")] [Tooltip("Enable double jump")]
        public bool AllowDoubleJump;

        [Tooltip("The immediate velocity applied when jumping")]
        public float JumpPower = 36;

        [Tooltip("Clamps the maximum fall speed")]
        public float MaxFallSpeed = 40;

        [Tooltip("The players capacity to gain fall speed")]
        public float FallSpeed = 110;

        [Tooltip("The gravity multiplier added when jump is released early")]
        public float JumpEndEarlyGravityModifier = 3;

        [Tooltip("The fixed frames before coyote jump becomes unusable. Coyote jump allows jump to execute even after leaving a ledge")]
        public int CoyoteFrames = 7;

        [Tooltip("The amount of fixed frames we buffer a jump. This allows jump input before actually hitting the ground")]
        public int JumpBufferFrames = 7;

        [Header("DASH")] [Tooltip("Allows the player to dash")]
        public bool AllowDash;

        [Tooltip("The velocity of the dash")] public float DashVelocity = 30;

        [Tooltip("How many fixed frames the dash will last")]
        public int DashDurationFrames = 5;

        [Tooltip("The horizontal speed retained when dash has completed")]
        public float DashEndHorizontalMultiplier = 0.25f;
        
        [Header("WALLS")] 
        [Tooltip("Allow wall sliding & jumping")]
        public bool AllowWalls;
        
        [Tooltip("Only wall slide when you're physically pushing against the wall")]
        public bool RequireInputPush;
        
        [Tooltip("Allow up input to climb walls")]
        public bool CanClimbWalls;
        
        [Tooltip("How fast you climb walls.")]
        public float WallClimbSpeed = 4;

        [Tooltip("Bounds for detecting walls on either side. Ensure it horizontally overflows your collider")]
        public Vector2 WallDetectorSize = new(0.75f,1);
        
        [Tooltip("Set this to the layer climbable walls are on")]
        public LayerMask ClimbableLayer;
        
        [Tooltip("How fast you descend walls. 0 = stick to wall")]
        public float WallFallSpeed = 8;

        [Tooltip("Clamps the maximum fall speed")]
        public float MaxWallFallSpeed = 8;

        [Tooltip("The immediate velocity horizontal velocity applied when wall jumping")]
        public Vector2 WallJumpPower = new(30, 25);
        
        [Tooltip("The frames before full horizontal movement is returned after a wall jump")]
        public int WallJumpInputLossFrames = 20;
        
        [Header("COLLISIONS")] [Tooltip("The detection distance for grounding and roof detection")]
        public float GrounderDistance = 0.1f;

        [Tooltip("Set this to the layer your player is on")]
        public LayerMask PlayerLayer;

        [Header("ATTACK")] [Tooltip("The fixed frame cooldown of your players basic attack")]
        public int AttackFrameCooldown = 15;

        [Header("EXTERNAL")] [Tooltip("The rate at which external velocity decays")]
        public int ExternalVelocityDecay = 100;

        [Header("GIZMOS")] [Tooltip("Color: White")]
        public bool ShowWallDetection;
    }
}