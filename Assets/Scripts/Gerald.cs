using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerald : MonoBehaviour
{

    public int points = 0;

    float x;
    float y;

    Vector3 rawForward;
    Vector3 calculatedForward;

    public bool grounded;
    public RaycastHit hitInfo;
    public LayerMask layerMask;

    public Rigidbody rb;

    private GeraldGravity gravity = new GeraldGravity();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckGround();

        GetInput();
        CalculateForward();
        Move();


        Debug.DrawLine(transform.position, transform.position + calculatedForward, Color.red);
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


        if(grounded && Vector3.Distance(transform.position, hitInfo.point) < 0.5f)
        {
            float add = 0.5f - Vector3.Distance(transform.position, hitInfo.point);
            this.transform.position += new Vector3(0, add, 0);
        }
    }


    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");


        Vector3 input = new Vector3(x, 0f, y);
        if (input != Vector3.zero)
        {
            rawForward = input;
        }
    }

    private void CalculateForward()
    {
        calculatedForward = rawForward;
        if(grounded)
        {
            Vector3 temp;
            temp = Quaternion.Euler(new Vector3(0, 90, 0)) * rawForward; //Vector right
            temp = Vector3.Cross(temp, hitInfo.normal);
            if (temp.x >= 0 && temp.y >= 0 && temp.z >= 0)
            {
                calculatedForward = temp;
            }
        }
    }

    private void Move()
    {
        if(x != 0 || y != 0)
        {
            rb.AddForce(calculatedForward * 10);
        }
        
    }

    //Zjeżdzanie z wyskoczni TODO
    private void DefaultSlow()
    {

        if (grounded && x== 0 && y == 0)
        {
            if (Vector3.Angle(Vector3.up, hitInfo.normal) > 20 && rb.velocity.magnitude < 1)
            {
                Debug.Log("XD");
                Vector3 temp = Quaternion.Euler(90, 180, 0) * calculatedForward;
                Debug.DrawLine(transform.position, transform.position + temp, Color.green);
                rb.velocity = new Vector3(temp.x, 0, temp.z);
            }
        }

        
    }
}
