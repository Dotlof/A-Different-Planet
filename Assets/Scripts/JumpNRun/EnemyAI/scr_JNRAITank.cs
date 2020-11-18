using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRAITank : MonoBehaviour
{
    float MoveSpeed = 320F;
    public float P1;
    public float P2;
    public GameObject This;
    string Direction = "Right";

    // Update is called once per frame
    void Update()
    {
        if (Direction == "Right")
        {
            This.transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Direction == "Left")
        {
            This.transform.position -= new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (This.transform.position.x >= P2)
        {
            Direction = "Left";
        }

        if (This.transform.position.x <= P1)
        {
            Direction = "Right";
        }

    }
}
