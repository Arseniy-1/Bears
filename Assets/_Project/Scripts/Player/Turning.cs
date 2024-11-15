using Vector3 = UnityEngine.Vector3;

namespace _Project.Scripts.Player
{
    public class Turning
    {
        private readonly Character _character;

        public Turning(Character character)
        {
            _character = character;
        }

        public void CorrectFlip(int posX)
        {
            _character.GunHolder.SpotTarget();
            
            if (_character.GunHolder.TargetScanner.HasTarget)
            {
                _character.transform.localScale = !((int)_character.GunHolder.TargetScanner.ClosestTarget.Position.x > (int)_character.transform.position.x) ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
                _character.GunHolder.transform.localScale = !((int)_character.GunHolder.TargetScanner.ClosestTarget.Position.x > (int)_character.transform.position.x) ? new Vector3(-1, -1, 1) : new Vector3(1, 1, 1);
            }
            else if (posX != 0)
            {
                _character.transform.localScale = posX > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
            }
        }
    }
}