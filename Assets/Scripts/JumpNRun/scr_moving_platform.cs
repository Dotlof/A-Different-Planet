using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class scr_moving_platform : MonoBehaviour
{
    public float pos1;
    public float pos2;
    public float speed;
    bool dir = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == true)
        {
            if (transform.position.x > pos1)
            {
                transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * speed;
            }
            else dir = false;
        }
        else
        {
            if (transform.position.x < pos2)
            {
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
            }
            else dir = true;
        }
    }
}
