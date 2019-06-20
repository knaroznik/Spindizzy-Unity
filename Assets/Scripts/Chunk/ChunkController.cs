using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour
{
    public Chunk activeChunk;

    Chunk[] nextChunks;

    public Gerald gerald;
    private Vector3 cameraOffset = new Vector3(3, 11, -3);
    public Camera mainCamera;

    private void Start()
    {
        nextChunks = new Chunk[4] { activeChunk.NorthChunk, activeChunk.EastChunk, activeChunk.SouthChunk, activeChunk.WestChunk };
    }

    public void ChangeChunk(int direction)
    {
        //Zmienić na korutynkę

        Vector3 velocity = gerald.rb.velocity;
        gerald.rb.velocity = Vector3.zero;
        activeChunk.DeActivate();

        if(nextChunks[direction] == null)
        {
            Debug.Log("LOST");
            return;
        }

        activeChunk = nextChunks[direction];

        this.gameObject.transform.position = activeChunk.transform.position;
        mainCamera.transform.position = activeChunk.transform.position + cameraOffset;

        activeChunk.Activate();
        nextChunks = new Chunk[4] { activeChunk.NorthChunk, activeChunk.EastChunk, activeChunk.SouthChunk, activeChunk.WestChunk };

        gerald.transform.position += velocity.normalized * 0.5f;
        gerald.rb.velocity = velocity;
    }
}
