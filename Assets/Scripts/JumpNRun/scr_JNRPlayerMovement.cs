using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRPlayerMovement : MonoBehaviour
{
    public GameObject Weapon;
    public GameObject Bullet;
    public GameObject Player;
    public Rigidbody2D rb;
    public float MoveSpeed = 10F;
    public float RunningSpeed = 20F;
    public float JumpSpeed = 30F;
    public int ShootDirection;
    public int HP = 3;
    bool Shooting = false;
    bool Jumping = false;
    bool OnCoolDown = false;
    bool WallJumping = false;
    float direction;

    public float hight;
    public GameObject CamTrigger1;


    // Start is called before the first frame update
    void Start()
    {
        ShootDirection = 1;
    }

    //CamColliders
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform" && Jumping)
        {
            //Jumping = false;
            transform.parent = collision.gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
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
        Instantiate(Bullet, transform.position, transform.rotation);
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
        //Debug.Log(Triggered);

        hight = transform.position.y;

        //Player Viewing Direction
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            direction = Input.GetAxisRaw("Horizontal");
        }
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
        //if (direction > 0) ShootDirection = 5;
        //else if (direction < 0) ShootDirection = 5;
        if (Input.GetAxisRaw("HorizontalShoot") != 0 || Input.GetAxisRaw("VerticalShoot") != 0)
        {
            if(OnCoolDown == false) StartCoroutine(Cooldown());
        }


        //right = 1, right/down = 2, down = 3, left/down = 4, left = 5, left/top = 6, top = 7, right/top = 8 

        if (direction > 0)
        {
            if ((Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") > 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 6;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") < 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 4;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") > 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 8;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") < 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 2;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") == 0)
            {
                ShootDirection = 5;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") == 0)
            {
                ShootDirection = 1;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") > 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                ShootDirection = 7;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") < 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                ShootDirection = 3;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -135);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") == 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if (direction < 0)
        {
            if ((Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") > 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 6;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") < 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 4;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") > 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 8;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") < 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 2;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") == 0)
            {
                ShootDirection = 5;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") == 0)
            {
                ShootDirection = 1;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") > 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                ShootDirection = 7;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") < 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                ShootDirection = 3;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 135);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") == 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }

        }
    }
}
