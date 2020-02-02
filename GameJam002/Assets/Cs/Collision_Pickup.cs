using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Pickup : MonoBehaviour
{

    //V A R I A B L E S 
    public GameObject obj;
    public GameObject wire_1;
    public GameObject wire_2;
    public Transform guide;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "wire_1")
        {
            //We set the object parent to our guide empty object.
            wire_1.transform.SetParent(guide);

            //Set gravity to false while holding it
            wire_1.GetComponent<Rigidbody>().useGravity = false;

            //we apply the same rotation our main object (Camera) has.
            wire_1.transform.localRotation = transform.rotation;
            //We re-position the wire on our guide object 
            wire_1.transform.position = guide.position;
        }
        Debug.Log("Collided");
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "hand")
    //    {
    //        obj = col.gameObject;


    //        Destroy(wire_1);
    //        //startcoroutine(examplecoroutine());

    //        Debug.Log("wire 1 moved");
    //    }


    //    if (col.gameObject.tag == "hand")
    //    {
    //        obj = col.gameObject;
    //        Destroy(wire_2);
    //        //StartCoroutine(ExampleCoroutine());

    //        Debug.Log("Wire 2 moved");
    //    }
    //}
}
