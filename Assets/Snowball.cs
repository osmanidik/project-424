using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 direction;
    private Rigidbody rb;
    private float speed = 50f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (direction * speed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Zombie"))
        {
            collision.gameObject.GetComponent<ZombieMove>().gotHit();
        }
        Destroy(this.gameObject);
    }
}
