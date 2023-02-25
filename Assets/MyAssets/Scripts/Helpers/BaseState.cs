using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Project
{
    public abstract class BaseState<T>
    {
        protected T _main;

        protected BaseState(T i_main)
        {
            _main = i_main;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}