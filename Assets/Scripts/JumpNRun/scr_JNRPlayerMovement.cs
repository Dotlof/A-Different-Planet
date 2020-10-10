using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRPlayerMovement : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;
    public Rigidbody2D rb;
    public float MoveSpeed = 10F;
    public float RunningSpeed = 20F;
    public float JumpSpeed = 30F;
    public int ShootDirection;
    bool Shooting = false;
    bool Jumping = false;
    bool OnCoolDown = false;
    bool WallJumping = false;
    float direction;


    // Start is called before the first frame update
    void Start()
    {
        ShootDirection = 1;
    }

    //Methods for PlayerJump
    void Jump()
    {
        if(Jumping == false)
        {
            Jumping = true;
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }

        if((rb.velocity.x != 0 && rb.velocity.y == 0) && Jumping == true)
        {
            StartCoroutine(WallJump());
        }

    }

    IEnumerator WallJump()
    {
        WallJumping = true;
        Debug.Log(rb.velocity);
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + JumpSpeed);
        yield return new WaitForSeconds(0.1f);
        WallJumping = false;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") { Jumping = false; WallJumping = false; }
        //else if (collision.gameObject.tag == "Ground" && collision.gameObject.transform.position.y > gameObject.transform.position.y) { WallJumping = true; Jumping = true; }
    }

    //Methods for Player Shoot
    void Shoot()
    {
        Bullet.GetComponent<scr_JNRBullet>().Direction = ShootDirection;
        Instantiate(Bullet, Player.transform);
        Shooting = false;
    }

    IEnumerator Cooldown()
    {
        Shooting = true;
        //Cooldown for the Shooting
        OnCoolDown = true;
        yield return new WaitForSeconds(0.25f);
        Shoot();
        OnCoolDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Logs

        //Player Viewing Direction
        direction = Input.GetAxisRaw("Horizontal");
        if(direction > 0)
        {
            Player.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(direction < 0) Player.transform.localScale = new Vector3(-1, 1, 1);


        //Player Movement in X Direction
        if (Input.GetAxisRaw("Horizontal") != 0 && WallJumping == false)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (Shooting == false) rb.velocity = new Vector2(RunningSpeed, rb.velocity.y);
                else rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
            }

            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if (Shooting == false) rb.velocity = new Vector2(-RunningSpeed, rb.velocity.y);
                else rb.velocity = new Vector2(-MoveSpeed, rb.velocity.y);
            }
            
            //SpeedrunVersion
            //if(Shooting == true) Player.transform.position += new Vector3(Input.GetAxisRaw("Horizontal") *MoveSpeed * Time.deltaTime, 0, 0); 
            //else Player.transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * RunningSpeed * Time.deltaTime, 0, 0);

        }

        else rb.velocity = new Vector2(0, rb.velocity.y);

        //Player Jump
        if (rb.velocity.y < 0) Jumping = true;

        if (Input.GetAxisRaw("Jump") != 0) {

            Jump(); 
        
        }


        //Player Shoot
        if (direction > 0) ShootDirection = 1;
        else if (direction < 0) ShootDirection = 2;
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            if(OnCoolDown == false) StartCoroutine(Cooldown());
        }
    }
}
