using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Project
{
    public class MenuCamera : BaseMode<Animator>
    {
        public MenuCamera(Animator i_main) : base(i_main)
        {
        }

        public override void On()
        {
            _main.Play("MenuCamera");
        }

        public override void Off()
        {
            
        }
    }
}