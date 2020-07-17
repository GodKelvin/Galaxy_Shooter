using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    public float speed = 5.0f;
    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("X pos: " + transform.position.x);
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("X pos: " + transform.position.x);

        //Move player to left and right
        horizontalInput = Input.GetAxis("Horizontal");
        //new Vector3(1,0,0) * 1(TD) * inputUser(1 or -1) * speed
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        //Move player to up and down
        verticalInput = Input.GetAxis("Vertical");
        //new Vector3(0,1,0) * 1(TD) * inputUser(1 or -1) * speed
        transform.Translate(Vector3.up * Time.deltaTime * verticalInput * speed);
    }
}
