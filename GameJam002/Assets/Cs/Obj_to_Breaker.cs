using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_to_Breaker : MonoBehaviour
{
    //V A R I A B L E S
    public bool canHold = true;
    public GameObject obj;
    public GameObject wire_1;
    public GameObject wire_2;
    public GameObject door_1;
    public GameObject door_2;
    bool wire_1_Destroyed;
    bool wire_2_Destroyed;



    void Update()
    {
        //checks to see if breaker box has enough wire_1s to power the door
        if(wire_1_Destroyed == true && wire_2_Destroyed == true)
        {
            Destroy(door_1);
            Destroy(door_2);
        }
        
    }
    //wire_1 is blue
    //wire_2 is red
    //wire_3 is green
    //wire_4 is yellow

    //takes wire_1 from player and destroys it when colliding with breaker box
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "wire_1")
        {
            obj = col.gameObject;
            Destroy(wire_1);
            GameObject Wire_1 = GameObject.FindWithTag("wire_1");
            Destroy(Wire_1);
            Debug.Log("wire 1 moved");
            wire_1_Destroyed = true;
        }


        if (col.gameObject.tag == "wire_2")
        {
            obj = col.gameObject;
            Destroy(wire_2);
            GameObject Wire_2 = GameObject.FindWithTag("wire_2");
            Destroy(Wire_2);
            Debug.Log("Wire 2 moved");
            wire_2_Destroyed = true;
        }
    }






}
