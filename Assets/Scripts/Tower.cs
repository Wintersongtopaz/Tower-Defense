using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [RequireComponent(typeof(Animator))]
    public class Tower : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemiesInRange = new List<GameObject>();
        public Tower_SO towerType;
        private bool firing = false;
        public GameObject enemyTarget;
        Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void DamageTarget()
        {
            if (!enemyTarget) return;
            Health.TryDamage(enemyTarget, towerType.damage);
        }
        // when enemy is not in range it wont fire at it
        private void RemoveDestroyedEnemies()
        {
            int i = 0;
            while(i < enemiesInRange.Count)
            {
                if (enemiesInRange[i]) i++;
                else enemiesInRange.RemoveAt(i);
            }
        }
        // tower will fire at enemy when in range and will wait to fire again
        IEnumerator DamageEnemyTarget()
        {
            firing = true;

            while(enemiesInRange.Count > 0)
            {
                RemoveDestroyedEnemies();
                if (enemiesInRange.Count > 0)
                {
                    enemyTarget = enemiesInRange[0];
                    animator.SetTrigger("Fire");
                }
                
                yield return new WaitForSeconds(towerType.fireRate);
            }

            firing = false;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy")) enemiesInRange.Add(other.gameObject);

            if (!firing) StartCoroutine(DamageEnemyTarget());
        }
        // when enemy makes it to the end it will be removed
        private void OnTriggerExit(Collider other)
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}

