using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Project
{
    
    public class MenuUI : BaseMode<List<GameObject>>
    {
        public MenuUI(List<GameObject> i_main) : base(i_main)
        {
        }

        public override void Off()
        {
            foreach (var item in _main)
            {
                item.SetActive(false);
            }
        }

        public override void On()
        {
            foreach (var item in _main)
            {
                item.SetActive(true);
            }
        }
    }
}