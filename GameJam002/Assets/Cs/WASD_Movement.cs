using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Movement : MonoBehaviour
{
    public float speed = 20f;
    public GameObject hand;
    //public float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

    }


    private void Update()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(Vector3.left);
            rb.velocity = -transform.right * speed;


        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed;    

        }
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(Vector3.up);
            rb.velocity = new Vector3(0, 0, 1) * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddForce(Vector3.down);
            rb.velocity = new Vector3(0, 0, -1) * speed;
        }

    }


}
