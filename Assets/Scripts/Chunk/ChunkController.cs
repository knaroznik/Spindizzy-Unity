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
        StartCoroutine(IChangeChunk(direction));   
    }

    private IEnumerator IChangeChunk(int direction)
    {
        Vector3 velocity = gerald.rb.velocity;
        gerald.rb.velocity = Vector3.zero;
        gerald.GetComponent<Movement>().enabled = false;

        yield return StartCoroutine(activeChunk.DeActivate()); //KORUTYNA

        activeChunk = nextChunks[direction];

        mainCamera.transform.position = activeChunk.transform.position + cameraOffset;
        yield return StartCoroutine(activeChunk.Activate());
        nextChunks = new Chunk[4] { activeChunk.NorthChunk, activeChunk.EastChunk, activeChunk.SouthChunk, activeChunk.WestChunk };

        this.gameObject.transform.position = activeChunk.transform.position;



        //Włączenie
        gerald.rb.velocity = velocity;
        gerald.GetComponent<Movement>().enabled = true;
    }
}
