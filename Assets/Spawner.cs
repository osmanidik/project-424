using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public int count;
    public float frequency; // One spawn per seconds.
    public float spread;

    private int internalCounter;
    // Start is called before the first frame update
    void Start()
    {
        internalCounter = count;

        Invoke("spawn", frequency);
    }

    void spawn()
    {
        if (internalCounter > 0)
        {
            Vector3 spreadVector = new Vector3(Random.Range(0f, spread), 0f, Random.Range(0f, spread));
            Instantiate(spawnee, this.transform.position + spreadVector, Quaternion.identity);
            internalCounter--;
            Invoke("spawn", frequency);
        }
    }
}
