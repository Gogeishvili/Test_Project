using UnityEngine;

namespace Test_Project
{
    public class WinCamera : BaseMode<Animator>
    {
        public WinCamera(Animator i_main) : base(i_main)
        {
        }

        public override void On()
        {
            _main.Play("WinCamera");
        }

        public override void Off()
        {
            
        }
    }
}