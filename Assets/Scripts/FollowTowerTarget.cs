using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class FollowTowerTarget : MonoBehaviour
    {
        Tower tower; // Tower Component reference.
        public bool pitch = true; // Whether to rotate on pitch axis.
        public bool yaw = true; // Whether on rotate on y axis.

        // Start is called before the first frame update
        void Start()
        {
            tower = GetComponentInParent<Tower>();
        }

        // Update is called once per frame
        void Update()
        {
            // In order to get enemyTarget from tower we have to make it public.
            if (!tower.enemyTarget) return; // If target is null stop right there.

            // Rotate this GameObject towards enemyTarget.
            // Get direction (target.position - transform.position).
            Vector3 direction = tower.enemyTarget.transform.position - transform.position;

            // Get rotation from direction and convert to eulers.
            Vector3 eulerRotation = Quaternion.LookRotation(direction).eulerAngles;

            // Whether this object should rotate up and down.
            // Good for bow and arrow and bad for cannon.
            eulerRotation.x = pitch ? eulerRotation.x : 0f;
            eulerRotation.y = yaw ? eulerRotation.y : 0f;

            // Assign rotation to transform by converting euler back into question.
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}