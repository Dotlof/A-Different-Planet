using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Starship : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Boss" || collision.gameObject.tag == "mini_boss" || collision.gameObject.tag == "Enemy") && invincebility == false)
        {
            health--;
            //Debug.Log("skrr");
            if (health != 0 && GameEnd == false)
            {
                StartCoroutine(respawn());
            }

        }
        if (collision.gameObject.tag == "Wall")
        {
            health--;
            //Debug.Log("skrr");
            if (health != 0)
            {
                StartCoroutine(respawn());
            }
        }
        if (collision.gameObject.tag == "1UP" && health < 3)
        {
            audioData.clip = OneUP;
            audioData.Play();
            health++;
            Destroy(collision.gameObject);
        }
    }

    public void LoadVolume()
    {
        PlayerData data = SaveSystem.LoadVolume();

        audioData.volume = data.sfx;

    }

    public void Continue()
    {
        GamePaused = false;
        Time.timeScale = 1;
    }


    IEnumerator AutoShoot()
    {
        spamSchutz = false;
        Projectile.GetComponent<scr_Laser>().Direction = Direction;
        Instantiate(Projectile, this.transform.position, Quaternion.identity);
        if (!audioData.isPlaying)
        {
            audioData.clip = Laser;
        }
        if (audioData.clip != OneUP)
        {
            audioData.clip = Laser;
            audioData.Play(0);
        }
        yield return new WaitForSeconds(0.2f);
        spamSchutz = true;
    }

    IEnumerator respawn()
    {
        invincebility = true;
        for (int wait = 0; wait <= 12; wait++)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.125f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.125f);
        }
        invincebility = false;
    }

    IEnumerator spawn()
    {
        invincebility = true;
        MovementSpeed = 0;
        for (int wait = 0; wait <= 20; wait++)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.125f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.125f);
        }
        invincebility = false;
        MovementSpeed = 500;
    }

    IEnumerator Abilitys()
    {
        if (Input.GetKeyDown(KeyCode.Space) && AbilityCooldown >= 6 && GameEnd == false && AbilityCooldown != 7 && GameWon == false)
        {
            switch (ability)
            {
                case 1:
                    MovementSpeed = 2000;
                    invincebility = true;
                    AbilityCooldown = 0;
                    yield return new WaitForSeconds(1f);
                    MovementSpeed = 500;
                    yield return new WaitForSeconds(0.5f);
                    invincebility = false;
                    break;
                case 2:
                    Instantiate(Bombe, this.transform.position, Quaternion.identity);
                    AbilityCooldown = 0;
                    break;
                case 3:
                    MovementSpeed = 200;
                    AbilityCooldown = 7;
                    Strahl.GetComponent<scr_Strahl>().Dir = Drehung;
                    for (int i = 120; i > 0; i--)
                    {
                        Instantiate(Strahl, this.transform.position, Quaternion.identity);
                        yield return new WaitForSeconds(0.0000001f);
                        //Debug.Log("Instanciated");
                    }
                    MovementSpeed = 500;
                    AbilityCooldown = 0;
                    break;
            }
        }
    }
    


    Vector3 movement;
    public float MovementSpeed = 2;
    public float FakeSpeed;
    public int Direction;
    public int health = 3;
    public GameObject Projectile;
    public GameObject Meteor;
    public GameObject Bombe;
    public GameObject LaserTag;
    public GameObject Strahl;
    public SpriteRenderer spriteRenderer;
    bool spamSchutz = true;
    bool invincebility = false;
    public bool GameEnd = false;
    public bool GamePaused = false;
    public bool GameWon = false;
    int Drehung;
    public int ability = 1;
    public float AbilityCooldown = 0;
    AudioSource audioData;
    public AudioClip Laser;
    public AudioClip OneUP;


    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(spawn());
        audioData = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        LoadVolume();
    }


    void Update()
    {
        LaserTag = GameObject.FindWithTag("Laser");

        FakeSpeed = MovementSpeed / Mathf.Sqrt(2);

        if ((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") != 0) || (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") == 0))
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(movement.x, 0, 0) * Time.deltaTime * MovementSpeed;

            movement.y = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(0, movement.y, 0) * Time.deltaTime * MovementSpeed;

        }
        else if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(movement.x, 0, 0) * Time.deltaTime * FakeSpeed;

            movement.y = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(0, movement.y, 0) * Time.deltaTime * FakeSpeed;

        }



        if ((Input.GetAxisRaw("Horizontal") <= 0 && Input.GetAxisRaw("Vertical") >= 0) && Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, 45);
            Drehung = 5;
        }
        else if ((Input.GetAxisRaw("Horizontal") <= 0 && Input.GetAxisRaw("Vertical") <= 0) && Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, 135);
            Drehung = 6;
        }
        else if ((Input.GetAxisRaw("Horizontal") >= 0 && Input.GetAxisRaw("Vertical") >= 0) && Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, -45);
            Drehung = 7;
        }
        else if ((Input.GetAxisRaw("Horizontal") >= 0 && Input.GetAxisRaw("Vertical") <= 0) && Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, -135);
            Drehung = 8;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            this.transform.localRotation = Quaternion.Euler(0, 0, 90);
            Drehung = 2;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            this.transform.localRotation = Quaternion.Euler(0, 0, -90);
            Drehung = 1;
        }
        else if (Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Drehung = 3;
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            this.transform.localRotation = Quaternion.Euler(0, 0, -180);
            Drehung = 4;
        }
        else
        {
            if (Drehung == 1)
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, -90);
            }
            else if (Drehung == 2)
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Drehung == 3)
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Drehung == 4)
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, -180);
            }
            else if (Drehung == 5)
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, 45);
            }
            else if (Drehung == 6)
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, 135);
            }
            else if (Drehung == 7)
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, -45);
            }
            else if (Drehung == 8)
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, -135);
            }
        }


        if ((Input.GetAxisRaw("HorizontalShoot") <= 0 && Input.GetAxisRaw("VerticalShoot") >= 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
        {
            Direction = 5;
        }
        if ((Input.GetAxisRaw("HorizontalShoot") <= 0 && Input.GetAxisRaw("VerticalShoot") <= 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
        {
            Direction = 6;
        }
        if ((Input.GetAxisRaw("HorizontalShoot") >= 0 && Input.GetAxisRaw("VerticalShoot") >= 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
        {
            Direction = 7;
        }
        if ((Input.GetAxisRaw("HorizontalShoot") >= 0 && Input.GetAxisRaw("VerticalShoot") <= 0) && Input.GetAxisRaw("HorizontalShoot") != 0 && Input.GetAxisRaw("VerticalShoot") != 0)
        {
            Direction = 8;
        }
        if (Input.GetAxisRaw("HorizontalShoot") <= 0 && Input.GetAxisRaw("VerticalShoot") == 0)
        {
            Direction = 2;
        }
        if (Input.GetAxisRaw("HorizontalShoot") >= 0 && Input.GetAxisRaw("VerticalShoot") == 0)
        {
            Direction = 1;
        }
        if (Input.GetAxisRaw("VerticalShoot") >= 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
        {
            Direction = 3;
        }
        if (Input.GetAxisRaw("VerticalShoot") <= 0 && Input.GetAxisRaw("HorizontalShoot") == 0)
        {
            Direction = 4;
        }


        if ((Input.GetAxisRaw("HorizontalShoot") != 0 || Input.GetAxisRaw("VerticalShoot") != 0) && spamSchutz == true)
        {
            StartCoroutine(AutoShoot());

        }
        //Debug.Log(AbilityCooldown);

        if (health <= 0)
        {
            GameEnd = true;
            MovementSpeed = 0f;
            spriteRenderer.enabled = false;
        }

        StartCoroutine(Abilitys());

        if (AbilityCooldown < 6)
        {
            AbilityCooldown += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (ability == 3)
            {
                ability = 1;
            }
            else
            {
                ability++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
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

        if (GameWon == true)
        {
            MovementSpeed = 0;
        }
        //Debug.Log(Application.persistentDataPath);
        //Debug.Log(ability);
    }
}
