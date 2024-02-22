using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cursor : MonoBehaviour
    {
        Vector3Int GetTargetTile()
        // Moves the cursor prefab wherever the mouse is on the screen.
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3Int targetTile;
                targetTile = Grid.WorldToGrid(hit.point + hit.normal * 0.5f);
                return targetTile;
            }

            return Vector3Int.one;
        }

        // Update is called once per frame
        void Update()
        // Makes it shown where we're pointing the cursor at.
        {
            transform.position = GetTargetTile();
        }
    }

}
