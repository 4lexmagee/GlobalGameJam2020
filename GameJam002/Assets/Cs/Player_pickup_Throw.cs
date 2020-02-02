using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_pickup_Throw : MonoBehaviour
{
    public float speed = 10;
    public bool canHold = true;
    public GameObject wire;
    public Transform guide;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!canHold)
                throw_drop();
            else
                Pickup();
        }//mause If

        if (!canHold && wire)
            wire.transform.position = guide.position;

    }//update

    //We can use trigger or Collision
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "wire")
            if (!wire) // if we don't have anything holding
                wire = col.gameObject;
    }

    //We can use trigger or Collision
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "wire")
        {
            if (canHold)
                wire = null;
        }
    }


    private void Pickup()
    {
        if (!wire)
            return;

        //We set the object parent to our guide empty object.
        wire.transform.SetParent(guide);

        //Set gravity to false while holding it
        wire.GetComponent<Rigidbody>().useGravity = false;

        //we apply the same rotation our main object (Camera) has.
        wire.transform.localRotation = transform.rotation;
        //We re-position the wire on our guide object 
        wire.transform.position = guide.position;

        canHold = false;
    }

    private void throw_drop()
    {
        if (!wire)
            return;

        //Set our Gravity to true again.
        wire.GetComponent<Rigidbody>().useGravity = true;
        // we don't have anything to do with our wire field anymore
        wire = null;
        //Apply velocity on throwing
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //Unparent our wire
        guide.GetChild(0).parent = null;
        canHold = true;
    }
}//class

