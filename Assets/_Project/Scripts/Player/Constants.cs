using UnityEngine;

static class Constants
{
    public static class AnimatorConstants
    {
        public const string LongInactivity = nameof(LongInactivity);
        public const string IdleWithGun = nameof(IdleWithGun);
        public const string Run = nameof(Run);
        public const string RunWithGun = nameof(RunWithGun);

        public static readonly int ActivityAnimation = Animator.StringToHash(LongInactivity);
        public static readonly int IdleAnimation = Animator.StringToHash(IdleWithGun);
        public static readonly int RunningAnimation = Animator.StringToHash(Run);
        public static readonly int RunInWeaponAnimation = Animator.StringToHash(RunWithGun);
    }
}