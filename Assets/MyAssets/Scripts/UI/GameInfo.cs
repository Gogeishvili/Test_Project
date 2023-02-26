using UnityEngine;
using TMPro;

namespace Test_Project
{
    public class GameInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _bulletsText;

        public void SetLevel(int i_level)
        {
            _levelText.text = $"LEVEL {i_level}";
        }

        public void SetBullets(int i_bulletsInLevel, int i_usedBullets)
        {
            _bulletsText.text = $"{i_bulletsInLevel} / {i_usedBullets}";
        }
    }
}