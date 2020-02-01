using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RecieveParts))]
public class DoorRepaired : MonoBehaviour
{

    BoxCollider coll;
    RecieveParts partsReciever;
    bool open;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider>();
        partsReciever = GetComponent<RecieveParts>();
        open = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!open)
        {
            if (partsReciever.repaired)
            {
                coll.enabled = false;
                open = true;
            }
        }
    }
}
