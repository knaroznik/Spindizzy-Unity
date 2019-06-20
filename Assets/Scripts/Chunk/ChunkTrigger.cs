using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    public int direction;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("XD");
            transform.GetComponentInParent<ChunkController>().ChangeChunk(direction);
        }
        
    }
}
