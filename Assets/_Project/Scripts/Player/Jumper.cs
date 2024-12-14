using Sirenix.OdinInspector;
using UnityEngine;

namespace PlayerSystem
{
    public class Jumper : MonoBehaviour
    {
        public float moveDistance = 1f; // Расстояние, на которое нужно переместить объект
        public float moveSpeed = 2f;   // Скорость перемещения

        private Vector3 startPosition;
        private Vector3 targetPosition;
        private bool isMoving = false;
        private float t = 0f;

        // Метод, который запускает движение

        [Button]
        public void Jump()
        {
            if (!isMoving)
            {
                startPosition = transform.position;
                targetPosition = startPosition + transform.right * moveDistance; // Вперед относительно направления объекта
                t = 0f;
                isMoving = true;
            }
        }

        void Update()
        {
            if (isMoving)
            {
                t += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);

                if (t >= 1f)
                {
                    transform.position = targetPosition; // Обеспечиваем точное попадание в конечную точку
                    isMoving = false;
                }
            }
        }
    }
}