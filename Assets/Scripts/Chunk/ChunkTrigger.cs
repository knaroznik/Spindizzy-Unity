using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{

    ChunkController chunkController;

    private void Start()
    {
        chunkController = transform.GetComponentInParent<ChunkController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.transform.position.z > this.transform.position.z + 4f)
            {
                chunkController.ChangeChunk(0);
            }
            else if (other.transform.position.z < this.transform.position.z - 4f)
            {
                chunkController.ChangeChunk(2);
            }
            else if(other.transform.position.x > this.transform.position.x + 4f)
            {
                chunkController.ChangeChunk(1);
            }
            else if (other.transform.position.x < this.transform.position.x - 4f)
            {
                chunkController.ChangeChunk(3);
            }
        }
    }
}
