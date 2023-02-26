using System;
using UnityEngine;

namespace Test_Project
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> onEnemyDeathEvent; 

        [SerializeField] private Transform _visual;
        [SerializeField] private Collider _collider;
        
        public void TakeDamage()
        {
            _visual.gameObject.SetActive(false);
            _collider.enabled = false;
            onEnemyDeathEvent?.Invoke(this);
        }

        public void ResetEnemy()
        {
            _visual.gameObject.SetActive(true);
            _collider.enabled = true;
        }
        
        
    }
}