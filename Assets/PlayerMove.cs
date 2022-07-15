using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    private int hdir;
    private int vdir;
    private int hcount;
    private int vcount;
    private bool moving;
    private int counterLimit = 3;

    private static Quaternion[] directions;
    
    // Start is called before the first frame update
    void Start()
    {
        hdir = 1;
        vdir = 1;
        hcount = 0;
        vcount = 0;
        
        int[] temp = new int[] {45, 0, -45, 90, 0, -90, 135, 180, -135};

        directions = new Quaternion[temp.Length];

        for (int i = 0; i < temp.Length; i++)
        {
            directions[i] = Quaternion.Euler(0, temp[i], 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;

        //hcount vcount is to make it easier to leave player at a diagonal position.
        if (hcount == 0)
            hdir = 1;
        else
        { 
            hcount--;
            Debug.Log(hcount);
        }

        if (vcount == 0)
            vdir = 1;
        else
            vcount--;

        //hdiff vdiff: temp values to determine which keys are pressed, later added to hdir if necessary
        int hdiff = 1;
        int vdiff = 1;

        if (Input.GetKey(KeyCode.A))
        {
            hdiff += 1;
            moving = true;
            hcount = counterLimit;
        }

        if (Input.GetKey(KeyCode.D))
        {
            hdiff -= 1;
            moving = true;
            hcount = counterLimit;
        }

        if (Input.GetKey(KeyCode.W))
        {
            vdiff -= 1;
            moving = true;
            vcount = counterLimit;
        }

        if (Input.GetKey(KeyCode.S))
        {
            vdiff += 1;
            moving = true;
            vcount = counterLimit;
        }

        if (moving)
        {
            if (hdir != hdiff)
                hdir = hdiff;
            if (vdir != vdiff)
                vdir = vdiff;

            if (hdir != 1 || vdir != 1)
                {
                    transform.rotation = directions[3 * vdir + hdir];
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
        }
    }
}
