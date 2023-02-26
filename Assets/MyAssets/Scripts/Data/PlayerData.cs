using UnityEngine;

namespace Test_Project
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public float scaleTime => _scaleTime;
        public Bullet bulletPref => _bulletPref;
        public float minScaleValue => _minScaleValue;
        public float initScale => _initScale;
        public LayerMask enemylayer => _enemyLayer;
        public float enemyDetectRadiusIncrement => _enemyDetectRadiusIncrement;


        [SerializeField] private float _scaleTime = 0.5f;
        [SerializeField] private Bullet _bulletPref;
        [SerializeField] private float _minScaleValue = 0.5f;
        [SerializeField] private float _initScale = 2;
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private float _enemyDetectRadiusIncrement = 2;
    }
}