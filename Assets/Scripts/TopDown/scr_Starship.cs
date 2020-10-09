using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Starship : MonoBehaviour
{

    Vector3 movement;
    public float MovementSpeed = 2;

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
    }
}
