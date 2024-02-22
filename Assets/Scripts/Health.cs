using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{ 
public class Health : MonoBehaviour
{
        [SerializeField] private int currentHealth = 10;

        public UnityEvent OnTakeDamage = new UnityEvent();
        public UnityEvent OnZeroHealth = new UnityEvent();
        // when enemy amkes it to the end lose health
        public void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", currentHealth);
            OnTakeDamage.Invoke();

            if (currentHealth <= 0)
            {
                OnZeroHealth.Invoke();
                Destroy(gameObject);
            }
        }
        // when enemy is hit it takes damage
        public static void TryDamage(GameObject target, int damageAmount)
        {
            Health health = target.GetComponent<Health>();

            if (health) health.TakeDamage(damageAmount);
        }
}
}
