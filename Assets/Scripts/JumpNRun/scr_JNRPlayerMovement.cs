using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRPlayerMovement : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;
    public Rigidbody2D rb;
    public float MoveSpeed = 20F;
    public float JumpSpeed = 10f;
    bool Jumping = false;
    float direction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Methods for PlayerJump
    void Jump()
    {
        if(Jumping == false)
        {
            Jumping = true;
            rb.velocity = Vector2.up * JumpSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") Jumping = false;   
    }

    //Methods for Player Shoot
    void Shoot()
    {
        Instantiate(Bullet, Player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //Player Viewing Direction
        direction = Input.GetAxisRaw("Horizontal");
        if(direction > 0)
        {
            Player.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(direction < 0) Player.transform.localScale = new Vector3(-1, 1, 1);


        //Player Movement in X Direction
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            Player.transform.position += new Vector3(Input.GetAxisRaw("Horizontal") *MoveSpeed * Time.deltaTime, 0, 0); 
        }

        //Player Jump
        if (Input.GetAxisRaw("Jump") != 0) {

            Jump(); 
        
        }


        //Player Shoot
        if (Input.GetAxisRaw("Fire1") != 0) Shoot();
    }
}
