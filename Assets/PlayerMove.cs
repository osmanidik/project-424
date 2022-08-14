using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public GameObject snowball;
    public GameObject manager;

    private Vector3 direction;
    private Vector3 lookingat;
    private Vector3 rotate;
    private bool move;
    private Rigidbody rb;
    private float[] degrees;
    private bool hasFired;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = false;
        direction = Vector3.zero;
        lookingat = Vector3.zero;
        rotate = Vector3.zero;
        hasFired = false;

        degrees = new float[] { 45f, 0f, -45f, 90f, 0f, -90f, 135f, 180f, -135f };
    }

    // Update is called once per frame
    void Update()
    {
        move = false;
        
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (direction != Vector3.zero)
        {
            lookingat = direction.normalized;
            rotate = new Vector3( 0f, degrees[3 * (int)(1-direction.z) + (int)(1-direction.x)], 0f );
            transform.eulerAngles = rotate;
            move = true;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            foreach (GameObject z in GameObject.FindGameObjectsWithTag("Zombie"))
            {
                Destroy(z);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!hasFired)
            {
                GameObject s = Instantiate(snowball);
                s.GetComponent<Snowball>().direction = lookingat;
                s.transform.position = this.transform.position + lookingat * 2;
                s.transform.eulerAngles = this.transform.eulerAngles;
            
                hasFired = true;
                Invoke("canFire", 0.3f);
            }
        }
    }
    private void FixedUpdate()
    {
        if (move)
            rb.MovePosition(transform.position + (direction.normalized * speed * Time.fixedDeltaTime));
    }

    public void gotHit()
    {
        manager.GetComponent<LevelManager>().gameOver();
    }

    private void canFire()
    {
        hasFired = false;
    }
}
