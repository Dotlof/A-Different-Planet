using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int Items = 0;
    int GesObj;
    bool Shooting = false;
    bool Jumping = false;
    bool OnCoolDown = false;
    bool WallJumping = false;
    bool OnPlatform = false;
    bool invinceble = false;
    public bool GamePaused = false;
    public bool GameEnd = false;
    public bool GameWon = false;
    float direction;
    Vector3 Deathpos;
    bool deathbool = false;
    AudioSource audioSource;
    public AudioClip Jumpin;
    public AudioClip collectItem;
    public AudioClip OneUP;
    public AudioClip schoosch;

    Animator animator;

    SpriteRenderer spriteRenderer;

    public float hight;
    public GameObject CamTrigger1;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ShootDirection = 1;
        GesObj = GameObject.FindGameObjectsWithTag("Collectible").Length;
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
        LoadVolume();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform" && Jumping)
        {
            Jumping = false;
            transform.parent = collision.gameObject.transform;
            OnPlatform = true;
        }

        if (collision.gameObject.tag == "Enemy" && invinceble == false)
        {
            HP--;
            Debug.Log("Schaden");
            StartCoroutine(getDmg());
        }

        if (collision.gameObject.tag == "Collectible")
        {
            Items++;
            audioSource.clip = collectItem;
            audioSource.Play();
            if (Items == GesObj / 3 || Items == (GesObj / 3) * 2 || Items == GesObj)
            {
                HP++;
            }
        }
        if (collision.gameObject.tag == "1UP")
        {
            if (HP < 3)
            {
                HP++;
            }
            Destroy(collision.gameObject);
            audioSource.clip = OneUP;
            audioSource.Play();
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
            transform.position = collision.gameObject.transform.position;
            spriteRenderer.enabled = false;
            Destroy(Weapon.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
            OnPlatform = false;
        }
    }

    IEnumerator getDmg()
    {
        invinceble = true;
        for (int i = 0; i < 10; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        invinceble = false;
    }

    public void LoadVolume()
    {
        PlayerData data = SaveSystem.LoadVolume();

        audioSource.volume = data.sfx;

    }

    public void Continue()
    {
        GamePaused = false;
        Time.timeScale = 1;
    }

    //Methods for PlayerJump
    void Jump()
    {
        if(Jumping == false)
        {
            Jumping = true;
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
            audioSource.clip = Jumpin;
            audioSource.Play();
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
        audioSource.clip = schoosch;
        audioSource.Play();
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
        //Debug.Log(HP);

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
            animator.SetBool("walk", true);
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
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("walk", false);
        }

        //Player Jump
        if (rb.velocity.y < 0 && OnPlatform == false) Jumping = true;

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


        if (HP <= 0)
        {
            GameEnd = true;
            if (deathbool == false)
            {
                deathbool = true;
                Deathpos = transform.position;
            }
            transform.position = Deathpos;
            spriteRenderer.enabled = false;
            Destroy(Weapon.gameObject);
        }


        //right = 1, right/down = 2, down = 3, left/down = 4, left = 5, left/top = 6, top = 7, right/top = 8 

        if (direction > 0 && Weapon.gameObject != null)
        {
            if ((Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") > 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 6;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") < 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 4;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") > 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 8;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") < 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 2;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") == 0)
            {
                ShootDirection = 5;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") == 0)
            {
                ShootDirection = 1;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") > 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                ShootDirection = 7;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") < 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                ShootDirection = 3;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") == 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if (direction < 0 && Weapon.gameObject != null)
        {
            if ((Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") > 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 6;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") < 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 4;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") > 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 8;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") < 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
            {
                ShootDirection = 2;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetAxisRaw("HorizontalShoot") < 0 && Input.GetAxisRaw("VerticalShoot") == 0)
            {
                ShootDirection = 5;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("HorizontalShoot") > 0 && Input.GetAxisRaw("VerticalShoot") == 0)
            {
                ShootDirection = 1;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Weapon.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") > 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                ShootDirection = 7;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") < 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                ShootDirection = 3;
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetAxisRaw("VerticalShoot") == 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
            {
                Weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Weapon.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }

        }
        if (transform.position.y <= -500)
        {
            HP = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton9) && GameEnd == false)
        {
            if (GamePaused == false)
            {
                GamePaused = true;
                Time.timeScale = 0;
            }
            else
            {
                GamePaused = false;
                Time.timeScale = 1;
            }
        }
        if (transform.position.y >= 30000)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
