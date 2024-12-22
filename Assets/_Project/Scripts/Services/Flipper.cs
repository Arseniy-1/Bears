using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace PlayerSystem
{
    public class Flipper : MonoBehaviour
    {
        [SerializeField] private Character _character;

        private void FixedUpdate()
        {
            CorrectFlip();
        }

        private void CorrectFlip()
        {
            float horizontalSpeed = _character.CharacterRigidbody2D.velocity.x;

            if (_character.TargetScanner.HasTarget)
            {
                var isFlipped = !((int)_character.TargetScanner.ClosestTarget.Position.x >
                                  (int)_character.transform.position.x);
                transform.localScale = isFlipped ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
                _character.WeaponHolder.transform.localScale = isFlipped ? new Vector3(-1, -1, 1) : new Vector3(1, 1, 1);
            }
            else if (horizontalSpeed != 0)
            {
                transform.localScale = horizontalSpeed > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
            }
        }
    }
}