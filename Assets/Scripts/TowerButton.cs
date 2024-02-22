using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    [RequireComponent(typeof(Button))]
    public class TowerButton : MonoBehaviour
    {
        Button button;
        Player player;

        public GameObject towerPrefab;

        private void Awake()
        {
            // Don't forget to get that component!
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);

            player = FindObjectOfType<Player>();
        }

        private void OnClick()
        {
            // Button has been clicked -> time to do something.
            Debug.Log("I'm a button and I've been clicked!");
            player.towerPrefab = towerPrefab;
        }
    }
}