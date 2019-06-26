using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerald : MonoBehaviour
{

    float x;
    float y;

    Vector3 rawForward;

    public bool grounded;
    public RaycastHit hitInfo;
    public LayerMask layerMask;

    public Rigidbody rb;
    private float slowDown = 0.9f;

    private GeraldGravity gravity = new GeraldGravity();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        Move();

        gravity.Update(this.gameObject, grounded);

    }

    void CheckGround()
    {
        Debug.DrawLine(transform.position, transform.position - Vector3.up * 0.5f, Color.green);
        bool updateGrounded = Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 0.5f, layerMask);
        if (updateGrounded != grounded)
        {
            grounded = updateGrounded;
        }
    }

    private void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");


        rawForward = new Vector3(x, 0f, y);
        Vector3 newMovement = rawForward;
        if (grounded)
        {
            Vector3 temp;
            temp = Quaternion.Euler(new Vector3(0, 90, 0)) * rawForward; //Vector right
            temp = Vector3.Cross(temp, hitInfo.normal);
            if(temp.x >=0 && temp.y >= 0 && temp.z >= 0)
            {
                newMovement = temp;
            }
        }

        Debug.DrawLine(transform.position, transform.position + newMovement, Color.red);

        rb.AddForce(newMovement * 10);
    }

    private void DefaultSlow()
    {
        float newX = rb.velocity.x, newZ = rb.velocity.z;

        if(x == 0)
        {
            newX = rb.velocity.x * slowDown;
        }

        if(y== 0)
        {
            newZ = rb.velocity.z * slowDown;
        }

        rb.velocity = new Vector3(newX, 0, newZ);
    }
}
