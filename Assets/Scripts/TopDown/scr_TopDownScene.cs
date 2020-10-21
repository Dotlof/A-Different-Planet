using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_TopDownScene : MonoBehaviour
{
    public void ChangeScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("loading");
    }

    IEnumerator bossTest()
    {
        yield return new WaitForSeconds(0.5f);
        gegner = GameObject.FindGameObjectsWithTag("mini_boss").Length;
        if (spawned == false)
        {
            StartCoroutine(bossTest());
        }
        else
        {
            Instantiate(Boss, new Vector3(5000, 0, 0), transform.rotation);
        }
        
    }

    public GameObject Meteor;
    public GameObject Enemys;
    public GameObject Boss;

    float randomX;
    float randomY;
    int zahler;
    int zahler2;
    public int gegner;
    bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bossTest());
    }

    // Update is called once per frame
    void Update()
    {

        randomX = Random.Range(-8000f, 8000f);
        randomY = Random.Range(-8000f, 8000f);

        if (zahler <= 700)
        {
            Instantiate(Meteor, new Vector3(randomX, randomY, 0), Quaternion.identity);
            zahler++;
        }
        if (zahler2 <= 100)
        {
            Instantiate(Enemys, new Vector3(randomX, randomY, 0), Quaternion.identity);
            zahler2++;
        }

        if (gegner == 0)
        {
            spawned = true;
            gegner--;
            
        }
        Debug.Log(gegner + "lol");
    }
}
