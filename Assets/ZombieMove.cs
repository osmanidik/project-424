using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    public float maxRadius;
    public float minRadius;
    GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = goal.position;

        if (players.Length > 0)
        {
            foreach (GameObject p in players)
            {
                float distance = Vector3.Distance(p.transform.position, this.transform.position);
                float oldDistance = Vector3.Distance(this.transform.position, agent.destination);

                if (distance >= minRadius && distance <= maxRadius && distance < oldDistance)
                {
                    agent.destination = p.transform.position;
                }
            }
        }
    }
}
