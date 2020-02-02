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
    public Sprite lightOn;
    public Sprite lightOff;
    public SpriteRenderer bulbRendLeft;
    public SpriteRenderer bulbRendRight;
    // Start is called before the first frame update
    void Start()
    {
        if (startingLightLeft)
        {
            leftOn = true;
            leftLight.gameObject.SetActive(true);
            bulbRendLeft.sprite = lightOn;

            rightOn = false;
            rightLight.gameObject.SetActive(false);
            bulbRendRight.sprite = lightOff;
        }
        else
        {
            leftOn = false;
            leftLight.gameObject.SetActive(false);
            bulbRendLeft.sprite = lightOff;

            rightOn = true;
            rightLight.gameObject.SetActive(true);
            bulbRendRight.sprite = lightOn;
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
                bulbRendLeft.sprite = lightOn;

                rightOn = true;
                rightLight.gameObject.SetActive(true);
                bulbRendRight.sprite = lightOn;
                firstRepairedFlag = true;
            }
        }
    }

    public void SwitchLights(Vector3 position)
    {
        
        bool _leftOn = (Vector3.Distance(position, bulbRendLeft.gameObject.transform.position) > Vector3.Distance(position, bulbRendRight.gameObject.transform.position)) ? true : false;
        if (!firstRepairedFlag)
        {
            if (_leftOn)
            {
                leftOn = true;
                leftLight.gameObject.SetActive(true);
                bulbRendLeft.sprite = lightOn;

                rightOn = false;
                rightLight.gameObject.SetActive(false);
                bulbRendRight.sprite = lightOff;
            }
            else
            {

                leftOn = false;
                leftLight.gameObject.SetActive(false);
                bulbRendLeft.sprite = lightOff;


                rightOn = true;
                rightLight.gameObject.SetActive(true);
                bulbRendRight.sprite = lightOn;
            }
        }
        else
        {
            if(!_leftOn)
            {
                if(leftLight.gameObject.activeSelf)
                {
                    leftLight.gameObject.SetActive(false);
                    bulbRendLeft.sprite = lightOff;
                }
                else
                {
                    leftLight.gameObject.SetActive(true);
                    bulbRendLeft.sprite = lightOn;
                }
            }
            else
            {
                if (rightLight.gameObject.activeSelf)
                {
                    rightLight.gameObject.SetActive(false);
                    bulbRendRight.sprite = lightOff;
                }
                else
                {
                    rightLight.gameObject.SetActive(true);
                     bulbRendRight.sprite = lightOn;
                }
            }
        }
    }
}

