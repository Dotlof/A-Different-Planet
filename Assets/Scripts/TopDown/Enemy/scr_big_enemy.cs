using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_big_enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser" && destroyed == 0)
        {
            health--;
            StartCoroutine(dmg());
            if (health == 0)
            {
                Instantiate(UP, transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
    }

    IEnumerator dmg()
    {
        spriteRenderer.sprite = damage;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = normal;
    }

    int health = 10;
    public int destroyed = 5;
    public SpriteRenderer spriteRenderer;
    public Sprite damage;
    public Sprite normal;
    public GameObject Score;
    public GameObject UP;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Score = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Score.gameObject.GetComponent<scr_Score>().score = Score.gameObject.GetComponent<scr_Score>().score + 250;
            Destroy(gameObject);
        }
        //Debug.Log(destroyed);
    }
}
