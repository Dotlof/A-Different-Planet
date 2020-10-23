using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Boss_Geschutz : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            StartCoroutine(dmg());
        }
    }

    IEnumerator dmg()
    {
        health--;
        spriteRenderer.sprite = damage;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = normal;
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(0.5f);
        projectile.GetComponent<scr_Boss_projectile>().richtung = Abstand.transform.position;
        Instantiate(projectile, transform.position, transform.rotation);
        if (shot == 2)
        {
            StartCoroutine(shoot());
        }
        
    }

    public GameObject Boss;
    public GameObject Abstand;
    public GameObject projectile;
    public GameObject Score;
    public SpriteRenderer spriteRenderer;
    public Sprite normal;
    public Sprite damage;
    int shot;
    int health = 20;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Score = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        shot = Boss.gameObject.GetComponent<scr_Boss>().shoot;
        if (shot == 1)
        {
            StartCoroutine(shoot());
        }

        if(health <= 0)
        {
            Score.gameObject.GetComponent<scr_Score>().score = Score.gameObject.GetComponent<scr_Score>().score + 150;
            Destroy(gameObject);
        }
    }
}
