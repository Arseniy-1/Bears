using UnityEngine;
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

        public void CorrectFlip(int direction)
        {
            if (_character.TargetScanner.HasTarget)
            {
                var isFlipped = !((int)_character.TargetScanner.ClosestTarget.Position.x >
                                  (int)_character.transform.position.x);
                _character.transform.localScale = isFlipped ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
                _character.WeaponHolder.transform.localScale = isFlipped ? new Vector3(-1, -1, 1) : new Vector3(1, 1, 1);
            }
            else if (direction != 0)
            {
                _character.transform.localScale = direction > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
            }
        }
    }
}