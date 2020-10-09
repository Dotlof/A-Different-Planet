using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRPlayerMovement : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public float MoveSpeed = 20F;
    public float JumpHeight = 5f;
    float direction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");

        if(direction == 0 || direction > 0)
        {
            Player.transform.localScale = new Vector3(1, 1, 1);
        }
        else Player.transform.localScale = new Vector3(1, 1, 1);
    }
}
