using System;
using UnityEngine;

namespace Test_Project
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> onEnemyDeathEvent;

        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _deathMaterial,_activeMaterial;
        [SerializeField] private Transform _visual;
        [SerializeField] private Collider _collider;
        
        public void TakeDamage()
        {
            _collider.enabled = false;
            _meshRenderer.material = _deathMaterial;
            
            this.Invoke(Explosion,1f);
            
        }

        void Explosion()
        {
            _visual.gameObject.SetActive(false);
            onEnemyDeathEvent?.Invoke(this);
        }

        public void ResetEnemy()
        {
            _visual.gameObject.SetActive(true);
            _collider.enabled = true;
            _meshRenderer.material = _activeMaterial;
        }
        
        
    }
}