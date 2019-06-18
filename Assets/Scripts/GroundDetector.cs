using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Gerald mainObject;
    
    void OnTriggerEnter(Collider other)
    {
        mainObject.rb.useGravity = false;
    }

    void OnTriggerExit(Collider other)
    {
        mainObject.rb.useGravity = true;
    }
}
