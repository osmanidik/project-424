using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popsicle : MonoBehaviour
{
    public float health = 50f;
    public GameObject manager;
    private bool isHit;
    
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Zombie"))
        {
            gotHit();
        }
    }

    public void gotHit()
    {
        if (!isHit)
        {
            health--;

            if (health == 0)
            {
                manager.GetComponent<LevelManager>().gameOver();
            }
            isHit = true;

            Invoke("recover", 0.25f);
        }
        
    }

    void recover()
    {
        isHit = false;
    }
}
