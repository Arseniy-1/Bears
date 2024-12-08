using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace PlayerSystem
{
    public class Flipper : MonoBehaviour
    {
        [SerializeField] private Character _character;

        public void CorrectFlip(float posX)
        {
            if (_character.TargetScanner.HasTarget)
            {
                var isFlipped = !((int)_character.TargetScanner.ClosestTarget.Position.x >
                                  (int)_character.transform.position.x);
                transform.localScale = isFlipped ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
                _character.WeaponHolder.transform.localScale = isFlipped ? new Vector3(-1, -1, 1) : new Vector3(1, 1, 1);
            }
            else if (posX != 0)
            {
                transform.localScale = posX > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
            }
        }
    }
}