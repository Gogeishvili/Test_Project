
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;


namespace Test_Project
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _scaleTime = 0.1f;
        [SerializeField] private Transform _visual;
        [SerializeField] private Bullet _bulletPref;
        [SerializeField] private float _initScaleValue;
        private Vector3 _initScale;


        private void Awake()
        {
            _initScaleValue =_visual.localScale.x;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _visual.localScale -= Vector3.one * (_scaleTime * Time.deltaTime);
            }

            if (Input.GetMouseButtonUp(0))
            {
                float currentScaleValue = _visual.localScale.x;
                Bullet bullet = Instantiate(_bulletPref, transform.position, quaternion.identity);
                float scale = _initScaleValue - currentScaleValue;
                bullet.transform.localScale = new Vector3(scale, scale, scale);
                _initScaleValue = _visual.localScale.x;
            }
        }

        [Button]
        public void SetInitScale()
        {
            _initScale = _visual.localScale;
        }

        [Button]
        public void Resest()
        {
            _visual.localScale = _initScale;
        }
    }
}