using UnityEngine;

static class Constants
{
    public static class AnimatorConstants
    {
        public const string LongInactivity = nameof(LongInactivity);
        public const string IdleWithWeapon = nameof(IdleWithWeapon);
        public const string Run = nameof(Run);
        public const string RunWithWeapon = nameof(RunWithWeapon);
        public const string Collecting = nameof(Collecting);
        public const string Jump = nameof(Jump);

        public static readonly int ActivityAnimation = Animator.StringToHash(LongInactivity);
        public static readonly int IdleWithWeaponAnimation = Animator.StringToHash(IdleWithWeapon);
        public static readonly int RunningAnimation = Animator.StringToHash(Run);
        public static readonly int RunWithWeaponAnimation = Animator.StringToHash(RunWithWeapon);
        public static readonly int CollectAnimation = Animator.StringToHash(Collecting);
        public static readonly int JumpAnimation = Animator.StringToHash(Jump);
    }
}