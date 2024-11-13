namespace _Project.Scripts.Player
{
    public class Turning
    {
        private readonly Character _character;
        private readonly TargetScanner _scanner;

        public Turning(Character character, TargetScanner scanner)
        {
            _character = character;
            _scanner = scanner;
        }

        public void CorrectFlip(int posX)
        {
            if (_scanner.HasTarget)
            {
                _character.spriteWeapon.flipY = !((int)_scanner.ClosestTarget.Position.x > (int)_character.transform.position.x);
                _character.spriteCharacter.flipX = !((int)_scanner.ClosestTarget.Position.x > (int)_character.transform.position.x);
            }
        
            else if (posX != 0)
            {
                _character.spriteCharacter.flipX = posX < 0;
            }
        }
    }
}