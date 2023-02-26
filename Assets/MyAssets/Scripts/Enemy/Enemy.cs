using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Test_Project
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> onEnemyDeathEvent;

        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _deathMaterial,_activeMaterial;
        [SerializeField] private Transform _visual;
        [SerializeField] private Collider _collider;
        [SerializeField] private List<EnemyFracture> _enemyFractures = new List<EnemyFracture>();

        public void TakeDamage()
        {
            _collider.enabled = false;
            _meshRenderer.material = _deathMaterial;
            
            this.Invoke(Explosion,0.5f);
            
        }

        void Explosion()
        {
            _visual.gameObject.SetActive(false);
            onEnemyDeathEvent?.Invoke(this);
            foreach (var enemyFracture in _enemyFractures)
            {
                enemyFracture.ExplisionEffect();
            }
        }

        public void ResetEnemy()
        {
            _visual.gameObject.SetActive(true);
            _collider.enabled = true;
            _meshRenderer.material = _activeMaterial;
            foreach (var enemyFracture in _enemyFractures)
            {
                enemyFracture.ResetPostion();
            }
        }
        
        
    }
}