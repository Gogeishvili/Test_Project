using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Windows.Input;

namespace Test_Project
{
    public  class PlayerActiveState : BaseState<Player>
    {
        public PlayerActiveState(Player i_main) : base(i_main)
        {
        }

        public override void Enter()
        {
            
        }

        public override void Update()
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                Debug.Log("Donw");
            }

            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                Debug.Log("Up");
            }
        }

        public override void Exit()
        {
           
        }
    }
}