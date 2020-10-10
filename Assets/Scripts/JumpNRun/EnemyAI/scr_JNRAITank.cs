using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRAITank : MonoBehaviour
{
    float MoveSpeed = 320F;
    public GameObject This;
    public GameObject checkpoint1;
    public GameObject checkpoint2;
    string Direction = "Right";

    // Update is called once per frame
    void Update()
    {
        if (Direction == "Right")
        {
            This.transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Direction == "Left")
        {
            This.transform.position -= new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
        }

        if (This.transform.position.x >= checkpoint2.transform.position.x)
        {
            Direction = "Left";
        }

        if (This.transform.position.x <= checkpoint1.transform.position.x)
        {
            Direction = "Right";
        }

    }
}
