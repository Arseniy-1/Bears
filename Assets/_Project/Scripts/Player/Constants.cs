using UnityEngine;

static class Constants
{
    public static class AnimatorConstants
    {
        public const string LongInactivity = nameof(LongInactivity);
        public const string IdleWithWeapon = nameof(IdleWithWeapon);
        public const string Run = nameof(Run);
        public const string RunWithWeapon = nameof(RunWithWeapon);

        public static readonly int ActivityAnimation = Animator.StringToHash(LongInactivity);
        public static readonly int IdleAnimation = Animator.StringToHash(IdleWithWeapon);
        public static readonly int RunningAnimation = Animator.StringToHash(Run);
        public static readonly int RunWithWeaponAnimation = Animator.StringToHash(RunWithWeapon);
    }
}