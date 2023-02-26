using System;
using UnityEngine;

namespace Test_Project
{
    public class LevelPath : MonoBehaviour
    {
        
        [SerializeField] private Transform _visual;

        public void SetScale(float i_scale)
        {
            _visual.localScale = new Vector3(i_scale, _visual.localScale.y, _visual.localScale.z);
        }
        
    }
}