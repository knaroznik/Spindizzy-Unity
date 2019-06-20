using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Chunk NorthChunk;
    public Chunk EastChunk;
    public Chunk SouthChunk;
    public Chunk WestChunk;

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        this.gameObject.SetActive(false);
    }
}
