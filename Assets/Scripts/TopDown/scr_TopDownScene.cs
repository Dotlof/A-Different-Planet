using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TopDownScene : MonoBehaviour
{
    public GameObject Meteor;
    public GameObject Enemys;

    float randomX;
    float randomY;
    int zahler;
    int zahler2;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        randomX = Random.Range(-8000f, 8000f);
        randomY = Random.Range(-8000f, 8000f);

        if (zahler <= 1000)
        {
            Instantiate(Meteor, new Vector3(randomX, randomY, 0), Quaternion.identity);
            zahler++;
        }
        if (zahler2 <= 100)
        {
            Instantiate(Enemys, new Vector3(randomX, randomY, 0), Quaternion.identity);
            zahler2++;
        }
    }
}
