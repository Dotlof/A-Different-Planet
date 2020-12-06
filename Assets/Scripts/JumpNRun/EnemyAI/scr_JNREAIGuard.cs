using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNREAIGuard : MonoBehaviour
{
    int HP = 10;
    public float MoveSpeed = 640F;
    public float P1;
    public float P2;
    public GameObject This;
    public GameObject Head;
    string Direction = "Right";
    Animator animator;

    AudioSource audioSource;

    IEnumerator Dmg()
    {
        audioSource.Play();
        animator.SetBool("Dmg", true);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("Dmg", false);
        //Debug.Log("lel");
    }

    IEnumerator Death()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.1F);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            
            HP--;
            StartCoroutine(Dmg());
        }
    }

    public void LoadVolume()
    {
        PlayerData data = SaveSystem.LoadVolume();

        audioSource.volume = data.sfx;

    }

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        LoadVolume();
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction == "Right")
        {
            This.transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(Direction == "Left")
        {
            This.transform.position -= new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(This.transform.position.x >= P2)
        {
            Direction = "Left";
        }

        if (This.transform.position.x <= P1)
        {
            Direction = "Right";
        }

        if(HP <= 0)
        {
            StartCoroutine(Death());
        }

        if (Head.gameObject.GetComponent<scr_Head_Trigger>().Triggered == true)
        {
            Destroy(gameObject);
        }
    }
}
