using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_small_enemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser" && health != 0)
        {
            health--;
            Debug.Log("hit");
            StartCoroutine(Damageanim());
        }
        if (other.gameObject.tag == "Player")
        {
            health = 0;
            StartCoroutine(Damageanim());
        }
        if (other.gameObject.tag == "Bombe")
        {
            health = 0;
            StartCoroutine(Damageanim());
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.2f);
        projectile.GetComponent<scr_Enemy_projectile>();
        Instantiate(projectile, Gun1.transform.position, transform.rotation);
        projectile.GetComponent<scr_Enemy_projectile>();
        Instantiate(projectile, Gun2.transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        projectile.GetComponent<scr_Enemy_projectile>();
        Instantiate(projectile, Gun1.transform.position, transform.rotation);
        projectile.GetComponent<scr_Enemy_projectile>();
        Instantiate(projectile, Gun2.transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        projectile.GetComponent<scr_Enemy_projectile>();
        Instantiate(projectile, Gun1.transform.position, transform.rotation);
        projectile.GetComponent<scr_Enemy_projectile>();
        Instantiate(projectile, Gun2.transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        cooldown = true;
    }

    IEnumerator Damageanim()
    {
        animator.SetBool("Dmg", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Dmg", false);
        if (health == 0)
        {
            moveSpeed = 0f;
            animator.SetBool("Explosion", true);
            yield return new WaitForSeconds(0.2f);
            audioData.Play(0);
            yield return new WaitForSeconds(0.8f);
            if (Leben == 0)
            {
                Instantiate(UP, transform.position, Quaternion.Euler(0, 0, 0));
            }

            Score.gameObject.GetComponent<scr_Score>().score = Score.gameObject.GetComponent<scr_Score>().score + 50;
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    IEnumerator bossTest()
    {
        yield return new WaitForSeconds(0.5f);
        gegner = GameObject.FindGameObjectsWithTag("mini_boss").Length;
        StartCoroutine(bossTest());
    }

    IEnumerator spawn()
    {
        kill = true;
        yield return new WaitForSeconds(3f);
        kill = false;

    }

    public GameObject UP;
    public GameObject Gun1;
    public GameObject Gun2;
    public GameObject projectile;
    public GameObject Score;
    int gegner = 4;
    int health = 5;
    int Leben;
    public Transform Player;
    private Rigidbody2D rb;
    private Vector2 movement;
    float moveSpeed = 200f;
    Animator animator;
    AudioSource audioData;
    public AudioClip aud_shoot;
    public AudioClip aud_explode; 
    bool cooldown = true;
    bool kill = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(spawn());
        audioData = GetComponent<AudioSource>();
        StartCoroutine(bossTest());

        Leben = Random.Range(0, 10);
        Score = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        float dist = Vector3.Distance(Player.position, transform.position);


        if ((dist >= 750 && dist <= 850) && cooldown == true)
        {
            StartCoroutine(Shoot());
            cooldown = false;
        }

        if (dist <= 1000)
        {
            moveSpeed = 300;
        }
        else
        {
            moveSpeed = 0;
        }


        if (dist <= 1000 && kill == true)
        {
            Destroy(gameObject);
            Debug.Log("kill");
        }

        if (gegner == 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(gegner + "Dab");
    }

}
