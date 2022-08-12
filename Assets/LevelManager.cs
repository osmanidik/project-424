using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject popsicle;

    private bool over;
    private bool track;
    private int wave;
    private int score;
    private int waveCount;
    // Start is called before the first frame update
    void Start()
    {
        over = false;
        track = false;
        wave = 0;
        waveCount = 0;

        Invoke("spawnWave", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (popsicle.GetComponent<Popsicle>().health == 0)
            gameOver();

        if (!over)
        {
            if (track)
            {
                int remaining = GameObject.FindGameObjectsWithTag("Zombie").Length;

                if (remaining == 0)
                {
                    track = false;
                    Invoke("spawnWave", 5f);
                }
            }
        }
    }

    void spawnWave()
    {
        wave++;
        int zombieCount = (int)(wave / 2f + 3) * 2;

        foreach(GameObject s in spawners)
        {
            Spawner script = s.GetComponent<Spawner>();
            script.count = zombieCount;
            script.frequency = 0.5f;
            script.spread = 3f;
            script.StartCoroutine("Start");
        }

        waveCount = spawners.Length * zombieCount;

        Invoke("startTracking", ((float)zombieCount)/2f);
    }

    void startTracking()
    {
        track = true;
        Debug.Log("start");
    }
    void gameOver()
    {
        over = true;
    }
}
