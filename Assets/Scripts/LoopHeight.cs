using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopHeight : MonoBehaviour
{
    public AnimationCurve curve;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, curve.Evaluate(Time.time % curve.length), transform.position.z);
    }
}
