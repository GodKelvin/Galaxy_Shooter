using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
//using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    public float speed = 5.0f;


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
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
