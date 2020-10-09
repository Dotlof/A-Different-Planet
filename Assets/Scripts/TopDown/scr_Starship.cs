using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Starship : MonoBehaviour
{
    public void Shoot()
    {

        if (Input.GetAxisRaw("HorizontalShoot") != 0 || Input.GetAxisRaw("VerticalShoot") != 0) 
        {
            Debug.Log("lool");
            StartCoroutine(AutoShoot());
        }
    }

    


    Vector3 movement;
    public float MovementSpeed = 2;
    public int Direction;
    public GameObject Projectile;

    IEnumerator AutoShoot()
    {
        Projectile.GetComponent<scr_Laser>().Direction = Direction;
        Instantiate(Projectile, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Shoot();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement.x, 0, 0) * Time.deltaTime * MovementSpeed;

        movement.y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(0, movement.y, 0) * Time.deltaTime * MovementSpeed;



        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Direction = 1;
            transform.localScale = new Vector3(-1, 1, 1);
            this.transform.localRotation = Quaternion.Euler(0, 0, 45);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.localScale = new Vector3(1, 1, 1);
                this.transform.localRotation = Quaternion.Euler(0, 0, 45);
                Direction = 2;
            }

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, -45);
            Direction = 3;
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, 135);
                Direction = 4;
            }

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(AutoShoot());
        }


    }
}
