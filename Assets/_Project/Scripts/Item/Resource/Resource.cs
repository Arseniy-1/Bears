using UnityEngine;

namespace _Project.Scripts.Item.Resource
{
    public class Resource : Item
    {
        public static bool isFirstView = true;

        
        public override void ViewAction()
        {
            if (isFirstView)
            {
                isFirstView = false;
                Debug.LogError("Ты можешь это: " + name + " поднять!");
            }
        }
    }
}