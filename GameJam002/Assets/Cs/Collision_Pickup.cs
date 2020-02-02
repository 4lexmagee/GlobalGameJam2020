using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Pickup : MonoBehaviour
{

    //V A R I A B L E S 
    //public GameObject wire_1;
    //public GameObject wire_2;
    public Transform guide;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //When object that script is on collides with declared tag, item(gameObject var) is moved to hand(guide)
    void OnTriggerEnter(Collider col)
    {
        //First wire collision if
        if (col.transform.tag == "wire_1")
        {
            //We set the object parent to our guide empty object.
            col.transform.SetParent(guide);

            //Set gravity to false while holding it
            col.GetComponent<Rigidbody>().useGravity = false;

            //we apply the same rotation our main object (Camera) has.
            col.transform.localRotation = transform.rotation;
            //We re-position the wire on our guide object 
            col.transform.position = guide.position;
        }

        //Second wire collision if
        if (col.transform.tag == "wire_2")
        {
            //We set the object parent to our guide empty object.
            col.transform.SetParent(guide);

            //Set gravity to false while holding it
            col.GetComponent<Rigidbody>().useGravity = false;

            //we apply the same rotation our main object (Camera) has.
            col.transform.localRotation = transform.rotation;
            //We re-position the wire on our guide object 
            col.transform.position = guide.position;
        }
        //Debug.Log("Collided");
    }

}

//public class Collision_Pickup : MonoBehaviour
//{

//    //V A R I A B L E S 
//    public GameObject wire_1;
//    public GameObject wire_2;
//    public Transform guide;


//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    //When object that script is on collides with declared tag, item(gameObject var) is moved to hand(guide)
//    void OnTriggerEnter(Collider col)
//    {
//        //First wire collision if
//        if (col.transform.tag == "wire_1")
//        {
//            //We set the object parent to our guide empty object.
//            wire_1.transform.SetParent(guide);

//            //Set gravity to false while holding it
//            wire_1.GetComponent<Rigidbody>().useGravity = false;

//            //we apply the same rotation our main object (Camera) has.
//           // wire_1.transform.localRotation = transform.rotation;
//            //We re-position the wire on our guide object 
//            wire_1.transform.position = guide.position;
//        }

//        //Second wire collision if
//        if (col.transform.tag == "wire_2")
//        {
//            //We set the object parent to our guide empty object.
//            wire_2.transform.SetParent(guide);

//            //Set gravity to false while holding it
//            wire_2.GetComponent<Rigidbody>().useGravity = false;

//            //we apply the same rotation our main object (Camera) has.
//          //  wire_2.transform.localRotation = transform.rotation;
//            //We re-position the wire on our guide object 
//            wire_2.transform.position = guide.position;
//        }
//        Debug.Log("Collided");
//    }

//}
