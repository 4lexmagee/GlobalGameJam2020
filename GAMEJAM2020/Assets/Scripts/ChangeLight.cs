using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    public bool startingLightLeft;
    [HideInInspector]
    public bool leftOn;
    [HideInInspector]
    public bool rightOn;
    public Light leftLight;
    public Light rightLight;
    RecieveParts partsReciver;
    bool firstRepairedFlag;
    // Start is called before the first frame update
    void Start()
    {
        if (startingLightLeft)
        {
            leftOn = true;
            leftLight.gameObject.SetActive(true);

            rightOn = false;
            rightLight.gameObject.SetActive(false);
        }
        else
        {
            leftOn = false;
            leftLight.gameObject.SetActive(false);

            rightOn = true;
            rightLight.gameObject.SetActive(true);
        }
        TryGetComponent(out partsReciver);
        firstRepairedFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        BothOn();
    }

    public void BothOn()
    {
        if (partsReciver != null)
        {
            if (partsReciver.repaired && !firstRepairedFlag)
            {
                leftOn = true;
                leftLight.gameObject.SetActive(true);

                rightOn = true;
                rightLight.gameObject.SetActive(true);
                firstRepairedFlag = true;
            }
        }
    }

    public void SwitchLights(Vector3 position)
    {
        bool _leftOn = (Vector3.Distance(position, leftLight.gameObject.transform.position) > Vector3.Distance(position, rightLight.gameObject.transform.position)) ? true : false;
        if (!firstRepairedFlag)
        {
            if (_leftOn)
            {
                leftOn = true;
                leftLight.gameObject.SetActive(true);


                rightOn = false;
                rightLight.gameObject.SetActive(false);
            }else
            {

                leftOn = false;
                leftLight.gameObject.SetActive(false);

                rightOn = true;
                rightLight.gameObject.SetActive(true);
            }
        }
        else
        {
            if(!_leftOn)
            {
                if(leftLight.gameObject.activeSelf)
                {
                    leftLight.gameObject.SetActive(false);
                }
                else
                {
                    leftLight.gameObject.SetActive(true);
                }
            }
            else
            {
                if (rightLight.gameObject.activeSelf)
                {
                    rightLight.gameObject.SetActive(false);
                }
                else
                {
                    rightLight.gameObject.SetActive(true);
                }
            }
        }
    }
}

