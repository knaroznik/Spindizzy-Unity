using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chunk : MonoBehaviour
{
    public Chunk NorthChunk;
    public Chunk EastChunk;
    public Chunk SouthChunk;
    public Chunk WestChunk;

    public bool Drawn = false;
    public bool Visited = false;
    public Image chunkImage;

    public IEnumerator Activate()
    {
        this.gameObject.SetActive(true);
        for(int i=0; i<8; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator DeActivate()
    {
        for (int i = 0; i < 8; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.05f);
        }
        this.gameObject.SetActive(false);
    }
}
