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
    private bool changing = false;

    private void Start()
    {
        nextChunks = new Chunk[4] { activeChunk.NorthChunk, activeChunk.EastChunk, activeChunk.SouthChunk, activeChunk.WestChunk };
    }

    private void Update()
    {

        if (changing) return;

        if (gerald.transform.position.z > this.transform.position.z + 4.5f)
        {
            ChangeChunk(0);
        }
        else if (gerald.transform.position.z < this.transform.position.z - 3.5f)
        {
            ChangeChunk(2);
        }
        else if (gerald.transform.position.x > this.transform.position.x + 3.5f)
        {
            ChangeChunk(1);
        }
        else if (gerald.transform.position.x < this.transform.position.x - 4.5f)
        {
            ChangeChunk(3);
        }
    }

    public void ChangeChunk(int direction)
    {
        StartCoroutine(IChangeChunk(direction));   
    }

    private IEnumerator IChangeChunk(int direction)
    {
        Debug.Log(direction);
        changing = true;
        Vector3 velocity = gerald.rb.velocity;
        bool useGravity = gerald.rb.useGravity;

        gerald.rb.velocity = Vector3.zero;
        gerald.rb.useGravity = false;
        gerald.enabled = false;


        yield return StartCoroutine(activeChunk.DeActivate()); //KORUTYNA

        activeChunk = nextChunks[direction];

        mainCamera.transform.position = activeChunk.transform.position + cameraOffset;
        yield return StartCoroutine(activeChunk.Activate());
        nextChunks = new Chunk[4] { activeChunk.NorthChunk, activeChunk.EastChunk, activeChunk.SouthChunk, activeChunk.WestChunk };

        this.gameObject.transform.position = activeChunk.transform.position;
        //Włączenie
        gerald.enabled = true;
        gerald.rb.velocity = velocity;
        gerald.rb.useGravity = useGravity;
        changing = false;
    }
}
