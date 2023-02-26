using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Serialization;


namespace Test_Project
{
    public class Level : MonoBehaviour
    {
        public Vector3 bulletTarget => _bulletTarget.position;
        public LevelPath LevelPath => _levelPath;
        public int level => _level;

        [SerializeField] private LevelPath _levelPath;
        [SerializeField] private int _level = 1;
        [SerializeField] private Transform _bulletTarget;
        [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
        [SerializeField] private Collider _playerPathCollider;


        private Enemy _enemy;
        private readonly Dictionary<GameObject, Enemy> _enemiesDictionaty = new Dictionary<GameObject, Enemy>();
        private readonly Dictionary<GameObject, Enemy> _enemiesOnPathDictionaty = new Dictionary<GameObject, Enemy>();
        
        
        public void On()
        {
            gameObject.SetActive(true);

            _enemiesDictionaty.Clear();
            _enemiesOnPathDictionaty.Clear();
            
            foreach (var enemy in _enemies)
            {
                enemy.ResetEnemy();
                enemy.onEnemyDeathEvent += RemoveEnemy;
                _enemiesDictionaty.Add(enemy.gameObject,enemy);
            }
            
            _playerPathCollider.OnTriggerEnterAsObservable().Where(c => c.gameObject.layer == MyStatics.ENEMY_LAYER)
                .Subscribe(c =>
                {
                   
                });
        }

        [Button]
        public void Testttt()
        {
           
        }
       
        public void Off()
        {
            foreach (var enemy in _enemies)
            {
                enemy.ResetEnemy();
            }
            gameObject.SetActive(false);
            
        }

        void RemoveEnemy(Enemy i_enemy)
        {
            if (_enemiesDictionaty.ContainsKey(i_enemy.gameObject))
            {
                i_enemy.onEnemyDeathEvent -= RemoveEnemy;
                _enemiesDictionaty.Remove(i_enemy.gameObject);
            }
            if (_enemiesOnPathDictionaty.ContainsKey(i_enemy.gameObject))
            {
                i_enemy.onEnemyDeathEvent -= RemoveEnemy;
                _enemiesOnPathDictionaty.Remove(i_enemy.gameObject);
                if (_enemiesOnPathDictionaty.Count <= 0)
                {
                    Debug.Log("All enemy is death on path");
                } 
            }
        }
        
        public Enemy GetEnemyRef(GameObject i_key)
        {
            if (_enemiesDictionaty.ContainsKey(i_key))
            {
                _enemy = _enemiesDictionaty[i_key];
            }

            return _enemy;
        }

    }
}