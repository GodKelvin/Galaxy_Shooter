using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
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
        //Debugs
        Debug.Log("X pos: " + transform.position.x + ", Y pos: " + transform.position.y);
        //Debug.Log("Y pos: " + transform.position.y);

        //Move player to left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        //new Vector3(1,0,0) * 1(TD) * inputUser(1 or -1) * speed
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        //Move player to up and down
        float verticalInput = Input.GetAxis("Vertical");
        //new Vector3(0,1,0) * 1(TD) * inputUser(1 or -1) * speed
        transform.Translate(Vector3.up * Time.deltaTime * verticalInput * speed);

        //Delimite space to moving player
        float max_x_range = 8.08f;
        float min_x_range = -8.02f;
        float max_y_range = 3.91f;
        float min_y_range = -3.97f;

        if(transform.position.x < min_x_range)
        {
            transform.position = new Vector3(min_x_range, transform.position.y, 0);
        }
        else if(transform.position.x > max_x_range)
        {
            transform.position = new Vector3(max_x_range, transform.position.y, 0);
        }
        
        if(transform.position.y < min_y_range)
        {
            transform.position = new Vector3(transform.position.x, min_y_range, 0);
        }
        else if(transform.position.y > max_y_range)
        {
            transform.position = new Vector3(transform.position.x, max_y_range, 0);
        }
    }
}
