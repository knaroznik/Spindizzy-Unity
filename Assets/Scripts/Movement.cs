using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody rb;
    private float slowDown = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rb.AddForce(new Vector3(x * 10, 0, y * 10));

        DefaultSlow(x, y);



    }

    void DefaultSlow(float x, float y)
    {
        float newX = rb.velocity.x, newZ = rb.velocity.z;
        if(x == 0)
        {
            newX = rb.velocity.x * slowDown;
        }

        if(y == 0)
        {
            newZ = rb.velocity.z * slowDown;
        }
        rb.velocity = new Vector3(newX, 0f, newZ);
    }
}
