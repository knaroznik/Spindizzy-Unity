using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Gerald mainObject;

    private float distToGround;
    private bool grounded;

    private void Start()
    {
        distToGround = GetComponent<BoxCollider>().bounds.extents.y;
    }

    private void Update()
    {
        bool updateGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

        if(updateGrounded != grounded)
        {
            grounded = updateGrounded;

            mainObject.rb.useGravity = !grounded;
        }
    }
}
