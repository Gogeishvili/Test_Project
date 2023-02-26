using UnityEngine;

namespace Test_Project
{
    public class InGameCamera : BaseMode<Animator>
    {
        public InGameCamera(Animator i_main) : base(i_main)
        {
        }

        public override void On()
        {
            _main.Play("InGameCamera");
        }

        public override void Off()
        {
            
        }
    }
}