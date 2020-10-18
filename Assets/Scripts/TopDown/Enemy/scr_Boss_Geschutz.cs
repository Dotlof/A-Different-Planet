using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Boss_Geschutz : MonoBehaviour
{
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
    int shot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shot = Boss.gameObject.GetComponent<scr_Boss>().shoot;
        if (shot == 1)
        {
            StartCoroutine(shoot());
        }
    }
}
