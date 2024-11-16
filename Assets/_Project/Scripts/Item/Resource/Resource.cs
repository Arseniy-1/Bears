using UnityEngine;

namespace _Project.Scripts.Item.Resource
{
    public class Resource : Item
    {
        private static bool _isFirstView = true;
        
        public override void ViewAction()
        {
            if (_isFirstView)
            {
                _isFirstView = false;
                Debug.LogError("Ты можешь это: " + name + " поднять!");
            }
        }

        public virtual void Put()
        {
            Destroy(gameObject);
        }
    }
}