using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject popsicle;
    public GameObject scoreText;
    public GameObject middleText;

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
        
        Invoke("newWave", 2f);
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
                score = waveCount - remaining;
                scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString("000") + "00";

                if (remaining == 0)
                {
                    track = false;
                    Invoke("newWave", 2f);
                }
            }
        }
    }

    void newWave()
    {
        wave++;
        middleText.GetComponent<TextMeshProUGUI>().text = "Wave " + wave.ToString("00");
        Invoke("spawnWave", 4f);
    }

    void spawnWave()
    {
        middleText.GetComponent<TextMeshProUGUI>().text = "";
        
        int zombieCount = (int)(wave / 2f + 3) * 2;

        foreach(GameObject s in spawners)
        {
            Spawner script = s.GetComponent<Spawner>();
            script.count = zombieCount;
            script.frequency = 0.5f;
            script.spread = 3f;
            script.StartCoroutine("Start");
        }

        waveCount = spawners.Length * zombieCount + score;

        Invoke("startTracking", ((float)zombieCount)/2f);
    }

    void startTracking()
    {
        track = true;
    }
    void gameOver()
    {
        over = true;

    }
}
