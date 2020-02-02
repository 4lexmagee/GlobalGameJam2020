using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RecieveParts))]
public class ConditionalRepair : MonoBehaviour
{
    public RecieveParts conditionalRepair;
    RecieveParts myReciveParts;
    public ConditionalType effect;
    bool effectDoneFlag;
    // Start is called before the first frame update
    void Start()
    {
        myReciveParts = GetComponent<RecieveParts>();
        effectDoneFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!effectDoneFlag)
            {
            if (effect == ConditionalType.Repair)
            {
                if (conditionalRepair.repaired)
                {

                    myReciveParts.SetRepaired();
                    effectDoneFlag = true;
                }
            }
        }
    }
}
public enum ConditionalType {Repair,other }
