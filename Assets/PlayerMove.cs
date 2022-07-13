using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 0.5f;
    public float turnspeed = 1f;

    private int hdir;
    private int vdir;
    private int turningDirection = 0;
    private bool turning;

    private static int[] DIRECTIONS = new int[] {45, 0, -45, 90, 0, -90, 135, 180, -135};
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turning = false;
        
        hdir = 1;
        vdir = 1;

        if (Input.GetKey(KeyCode.A))
        {
            hdir -= 1;
            turning = true;
            //Debug.Log("A");
        }

        if (Input.GetKey(KeyCode.D))
        {
            hdir += 1;
            turning = true;
            //Debug.Log("D");
        }

        if (Input.GetKey(KeyCode.W))
        {
            vdir += 1;
            turning = true;
            //Debug.Log("W");
        }

        if (Input.GetKey(KeyCode.S))
        {
            vdir -= 1;
            turning = true;
            //Debug.Log("S");
        }

        if (turning)
        {
            turningDirection = DIRECTIONS[3 * vdir + hdir];
        }

        int turnScale = turningDirection < transform.eulerAngles.y ? -1 : 1;

        transform.Rotate(0, turnScale * turnspeed, 0, Space.Self);
    }
}
