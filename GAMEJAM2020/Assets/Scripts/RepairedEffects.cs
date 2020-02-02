using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RecieveParts))]
public class RepairedEffects : MonoBehaviour
{
    public Effects effect;
    bool effectTriggeredFlag;
    RecieveParts partReciever;
    // Start is called before the first frame update
    void Start()
    {
        effectTriggeredFlag = false;
        partReciever = GetComponent<RecieveParts>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!effectTriggeredFlag)
        {
            if(effect==Effects.removeCollBox)
            {
                if (partReciever.repaired)
                {
                    BoxCollider coll;
                    TryGetComponent(out coll);
                    if (coll)
                    {
                        coll.enabled = false;
                    }
                }
            }
        }
    }
    public enum Effects {removeCollBox, other}
}
