using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 20f;
    //public float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{
    //    //Vector3 pos = transform.position;

    //    //if (Input.GetKey("w"))
    //    //{
    //    //    Debug.Log("afsdfasdfd");
    //    //    pos.z += speed;// * Time.deltaTime;
    //    //}
    //    //if (Input.GetKey("s"))
    //    //{
    //    //    pos.z -= speed * Time.deltaTime;
    //    //}
    //    //if (Input.GetKey("d"))
    //    //{
    //    //    pos.x += speed * Time.deltaTime;
    //    //}
    //    //if (Input.GetKey("a"))
    //    //{
    //    //    pos.x -= speed * Time.deltaTime;
    //    //}


    //}


    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            //rb.AddForce(Vector3.left);
            rb.velocity= - transform.right * speed;
        if (Input.GetKey(KeyCode.D))
            rb.velocity = transform.right * speed;
        if (Input.GetKey(KeyCode.W))
            //rb.AddForce(Vector3.up);
            rb.velocity = new Vector3(0,0,1) * speed;
        if (Input.GetKey(KeyCode.S))
            //rb.AddForce(Vector3.down);
            rb.velocity = new Vector3(0, 0, -1) * speed;

    }


}
