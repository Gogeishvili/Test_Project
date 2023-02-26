
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Test_Project
{
    
    public class GameManager : MonoBehaviour
    {
        
        
        
        public void Lose()
        {
            Debug.Log("Lose");
        }

        [Button]
        public void Load()
        {
            SceneManager.LoadScene(0);
        }
    }
}