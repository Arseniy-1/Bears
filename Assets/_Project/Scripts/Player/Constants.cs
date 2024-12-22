using UnityEngine;

static class Constants
{
    public static class AnimatorConstants
    {
        public const string LongInactivity = nameof(LongInactivity);
        public const string IdleWithGun = nameof(IdleWithGun);
        public const string Run = nameof(Run);
        public const string RunWithGun = nameof(RunWithGun);
        public const string TakeDamage = nameof(TakeDamage);
        public const string TakeHeal = nameof(TakeHeal);
        public const string ItemPickup = nameof(ItemPickup);
        public const string ReverseWalk = nameof(ReverseWalk);
        public const string Dead = nameof(Dead);

        public static readonly int InactivityAnimation = Animator.StringToHash(LongInactivity);
        public static readonly int IdleAnimation = Animator.StringToHash(IdleWithGun);
        public static readonly int RunningAnimation = Animator.StringToHash(Run);
        public static readonly int RunInWeaponAnimation = Animator.StringToHash(RunWithGun);
        public static readonly int TakeDamageAnimation = Animator.StringToHash(TakeDamage);
        public static readonly int TakeHealAnimation = Animator.StringToHash(TakeHeal);
        public static readonly int ItemPickupAnimation = Animator.StringToHash(ItemPickup);
        public static readonly int ReverseWalkAnimation = Animator.StringToHash(ReverseWalk);
        public static readonly int DeadAnimation = Animator.StringToHash(Dead);
    }
}