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
    public Transform guide;
    int counter = 0;



    void Update()
    {
        //checks to see if breaker box has enough wire_1s to power the door
        if(counter == 2)
        {
            Destroy(door_1);
            Destroy(door_2);
        }
        
    }

    //takes wire_1 from player and destroys it when colliding with breaker box
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "wire_1")
        {
            obj = col.gameObject;


            Destroy(wire_1);
            //startcoroutine(examplecoroutine());
            counter++;
            Debug.Log("wire 1 moved");
        }


        if (col.gameObject.tag == "wire_2")
        {
            obj = col.gameObject;
            Destroy(wire_2);
            //StartCoroutine(ExampleCoroutine());
            counter++;
            Debug.Log("Wire 2 moved");
        }
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }





}
