using UnityEngine;
using UnityEngine.UI;

namespace HealthSystem
{
    public class HealthBar : HealthView
    {
        [SerializeField] protected Slider HealthBarView;

        protected override void ShowHealth(float currentHealth, float maxHealth)
        {
            HealthBarView.value = currentHealth / maxHealth;
        }
    }
}