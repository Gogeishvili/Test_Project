using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name+"Coll");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name+"trige");
    }
}
