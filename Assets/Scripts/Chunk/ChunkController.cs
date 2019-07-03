using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChunkController : MonoBehaviour
{
    public Chunk activeChunk;

    public GameObject contentObject;
    public GameObject imagePrefab;

    Chunk[] nextChunks;

    public Gerald gerald;
    private Vector3 cameraOffset = new Vector3(3, 11, -3);
    public Camera mainCamera;
    private bool changing = false;

    private void Start()
    {
        activeChunk.Visited = true;
        nextChunks = new Chunk[4] { activeChunk.NorthChunk, activeChunk.EastChunk, activeChunk.SouthChunk, activeChunk.WestChunk };

        Draw(activeChunk, new Vector3(0, 0, 0));
    }

    private void Update()
    {

        if (changing) return;

        if (gerald.transform.position.z > this.transform.position.z + 4.5f)
        {
            ChangeChunk(0, new Vector3(0, -60, 0));
            
        }
        else if (gerald.transform.position.z < this.transform.position.z - 3.5f)
        {
            ChangeChunk(2, new Vector3(0, 60, 0));
            
        }
        else if (gerald.transform.position.x > this.transform.position.x + 3.5f)
        {
            ChangeChunk(1, new Vector3(-60, 0, 0));
            
        }
        else if (gerald.transform.position.x < this.transform.position.x - 4.5f)
        {
            ChangeChunk(3, new Vector3(60, 0, 0));
        }
    }

    private void Draw(Chunk currentChunk, Vector3 position)
    {
        if (currentChunk == null) return;
        if (currentChunk.Drawn) return;

        GameObject x = Instantiate(imagePrefab, contentObject.transform);
        x.transform.localPosition = position;

        if (!currentChunk.Visited)
        {
            x.GetComponent<Image>().color = Color.grey;
        }
        currentChunk.chunkImage = x.GetComponent<Image>();
        currentChunk.Drawn = true;

        Draw(currentChunk.NorthChunk, position + new Vector3(0, 60, 0));
        Draw(currentChunk.EastChunk, position + new Vector3(60, 0, 0));
        Draw(currentChunk.SouthChunk, position + new Vector3(0, -60, 0));
        Draw(currentChunk.WestChunk, position + new Vector3(-60, 0, 0));
    }

    public void ChangeChunk(int direction, Vector3 mapOffset)
    {
        StartCoroutine(IChangeChunk(direction, mapOffset));   
    }

    //Przesuwanie mapy, odkrywanie mapy
    private IEnumerator IChangeChunk(int direction, Vector3 mapoffset)
    {
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
        activeChunk.chunkImage.color = Color.white;
        contentObject.transform.position += mapoffset;
        gerald.enabled = true;
        gerald.rb.velocity = velocity;
        gerald.rb.useGravity = useGravity;
        changing = false;
    }
}
