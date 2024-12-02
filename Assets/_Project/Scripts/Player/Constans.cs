using UnityEngine;

static class Constans
{
    public static class AnimatorConstans
    {
        public const string LongInactivity = nameof(LongInactivity);
        public const string IdleInWeapon = nameof(IdleInWeapon);
        public const string Run = nameof(Run);
        public const string RunInWeapon = nameof(RunInWeapon);

        public static readonly int ActivityAnimation = Animator.StringToHash(LongInactivity);
        public static readonly int IdleAnimation = Animator.StringToHash(IdleInWeapon);
        public static readonly int RunningAnimation = Animator.StringToHash(Run);
        public static readonly int RunInWeaponAnimation = Animator.StringToHash(RunInWeapon);
    }
}