namespace _Project.Scripts.Player
{
    public class Turning
    {
        private readonly Character _character;
        private readonly GunHolder _gunHolder;

        public Turning(Character character, GunHolder gunHolder)
        {
            _character = character;
            _gunHolder = gunHolder;
        }

        public void CorrectFlip(int posX)
        {
            _gunHolder.SpotTarget();
            
            if (_gunHolder.TargetScanner.HasTarget)
            {
                _character.spriteWeapon.flipY = !((int)_gunHolder.TargetScanner.ClosestTarget.Position.x > (int)_character.transform.position.x);
                _character.spriteCharacter.flipX = !((int)_gunHolder.TargetScanner.ClosestTarget.Position.x > (int)_character.transform.position.x);
            }
            else if (posX != 0)
            {
                _character.spriteCharacter.flipX = posX < 0;
            }
        }
    }
}