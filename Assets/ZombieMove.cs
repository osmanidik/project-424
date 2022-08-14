using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    public float radius;
    GameObject[] players;

    private int health = 3;
    private Color[] skins = new Color[] { new Color(0.3f, 0.8f, 1f), new Color(0.3f, 0.8f, 1f), new Color(0.5f, 1f, 1f), Color.white };
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("ZombieSkin"))
                child.GetComponent<Renderer>().material.SetColor("_Color",skins[health]);
        }
        
        if (goal != null)
        {
            agent.destination = goal.position;

            if (players.Length > 0)
            {
                foreach (GameObject p in players)
                {
                    if (p == null)
                        continue;

                    float distance = Vector3.Distance(p.transform.position, this.transform.position);
                    float oldDistance = Vector3.Distance(this.transform.position, agent.destination);

                    if (distance <= radius && distance < oldDistance)
                    {
                        agent.destination = p.transform.position;
                    }
                }
            }
        }
        else
            agent.destination = this.transform.position;
    }

    public void gotHit()
    {
        health--;

        if (health == 0)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMove>().gotHit();
        }
    }
}
