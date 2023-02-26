using System;
using System.Collections;
using UnityEngine;

namespace Test_Project
{
    public static class Extantions
    {
        public static void Invoke(this MonoBehaviour mb, Action i_function, float i_delay)
        {
            mb.StartCoroutine(InvokeRoutine(i_function, i_delay));
        }

        private static IEnumerator InvokeRoutine(System.Action i_function, float i_delay)
        {
            yield return new WaitForSeconds(i_delay);
            i_function();
        }
    }
}