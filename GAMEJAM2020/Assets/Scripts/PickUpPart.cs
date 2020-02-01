using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownController))]
public class PickUpPart : MonoBehaviour
{
    public LayerMask partLayer;

    bool holdingObj;
    GameObject currentHighlighted;
    TopDownController controller;
    public Transform selectColl;
    Highlightable highlight;
    Highlightable highlightOld;


    // Start is called before the first frame update
    void Start()
    {
        holdingObj = false;
        controller = GetComponent<TopDownController>();
    }

    // Update is called once per frame
    void Update()
    {
        //This changes the position of the box depending on direction. FIND A WAY TO MAKE IT LERP TO POSITION
        if (!controller.movingDown && !controller.movingUp)
        {
            if (controller.currentDirectionX >= 0)
            {
                Vector3 newPos = new Vector3(.5f, 0, 0);
                selectColl.localPosition = newPos;
            }
            else
            {
                Vector3 newPos = new Vector3(-.5f, 0, 0);
                selectColl.localPosition = newPos;
            }
        }
        else
        {
            if(controller.movingUp)
            {
                Vector3 newPos = new Vector3(0, 1.25f, 0);
                selectColl.localPosition = newPos;
            }
            else if(controller.movingDown)
            {
                Vector3 newPos = new Vector3(0, -1, 0);
                selectColl.localPosition = newPos;
            }
        }
    }
 

    private void OnCollisionEnter(Collision collision)
    {
        if (!holdingObj)
        {
            if (partLayer == (partLayer.value | 1 << collision.gameObject.layer))
            {
                //highlights only the most recent object
                currentHighlighted = collision.gameObject;
                if(highlight!=null)
                {
                    highlightOld = highlight;
                    highlightOld.SetAlternateSprite(false);
                    
                }
                highlight = currentHighlighted.GetComponent<Highlightable>();
                highlight.SetAlternateSprite(true);
                
               

            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!holdingObj)
        {
            if (partLayer == (partLayer.value | 1 << collision.gameObject.layer))
            {
                if (currentHighlighted = collision.gameObject)
                {
                    if(highlight!=null)
                    {
                        highlight.SetAlternateSprite(false);
                    }
                    if (highlightOld != null)
                    {
                        highlightOld.SetAlternateSprite(false);
                    }
                    currentHighlighted = null;
                }

               
            }
        }
    }
}
