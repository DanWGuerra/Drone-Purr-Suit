using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    public Transform target; // Assign this in the inspector with the object to point towards

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target); // Makes the cone's transform look at the target's current position
        }
    }
}
