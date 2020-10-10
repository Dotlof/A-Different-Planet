using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Starship : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Enemy")
        {
            health--;
            Debug.Log("skrr");
        }
    }

    IEnumerator AutoShoot()
    {
        spamSchutz = false;
        Projectile.GetComponent<scr_Laser>().Direction = Direction;
        Instantiate(Projectile, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        spamSchutz = true;
    }

    


    Vector3 movement;
    public float MovementSpeed = 2;
    public float FakeSpeed;
    public int Direction;
    public int health = 3;
    public GameObject Projectile;
    bool spamSchutz = true;
    int Drehung;


    void Start()
    {
        
    }


    void Update()
    {

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
        //Debug.Log(Drehung);

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
