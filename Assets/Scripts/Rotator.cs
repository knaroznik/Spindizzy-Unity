using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public Vector3 rotateVector;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotateVector);
    }
}
