using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerald : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ChangeGravity(bool _value)
    {
        rb.useGravity = _value;
    }
}
