using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraldGravity
{

    public void Update(GameObject Gerald, bool _grounded)
    {
        if (!_grounded)
        {
            Gerald.GetComponent<Rigidbody>().useGravity = true;
        }
        else
        {
            Gerald.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
