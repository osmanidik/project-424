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
        Invoke("spawn", frequency);
    }

    void spawn()
    {
        if (count > 0)
        {
            Vector3 spreadVector = new Vector3(Random.Range(0f, spread), 0f, Random.Range(0f, spread));
            GameObject z = Instantiate(spawnee, this.transform.position + spreadVector, Quaternion.identity);

            ZombieMove zs = z.GetComponent<ZombieMove>();
            zs.radius = Random.Range(5f, 15f);

            count--;
            Invoke("spawn", frequency);
        }
    }
}
