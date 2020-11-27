using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ItemText : MonoBehaviour
{
    public GameObject Player;
    public Text text;
    int objects;
    int GesObj;
    string objectsString;
    string GesObjString;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        GesObj = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    // Update is called once per frame
    void Update()
    {
        objects = Player.gameObject.GetComponent<scr_JNRPlayerMovement>().Items;

        objectsString = objects.ToString();
        GesObjString = GesObj.ToString();
        text.text = objectsString + " / " + GesObjString;
    }
}
