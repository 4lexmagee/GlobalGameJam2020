using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownController))]
public class PickUpPart : MonoBehaviour
{
    public LayerMask selectableLayer;

    GameObject heldObj;
    Highlightable heldObjHighlight;
    GameObject currentHighlightedObj;
    GameObject firstCollision;
    TopDownController controller;
    Rigidbody rigbody;
    public Transform selectColl;
    public Transform handsTransform;
    Highlightable highlight;
    Highlightable highlightOld;
    float currentTimeToBoxReorient;
    Vector3 lastPos;
    bool gyrate;
    bool performedInteraction;
    bool holdingObj;
    int numberOfCollisions;
    int numberOfCollisionOld;
    float firstCollYPos;
    float secondCollYPos;
    // Start is called before the first frame update
    void Start()
    {
      
        controller = GetComponent<TopDownController>();
        rigbody = GetComponent<Rigidbody>();
        currentTimeToBoxReorient =0;
        gyrate = false;
        performedInteraction = false;
        holdingObj = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        HandledInteract();
        HandleSelection();
    }
    private void LateUpdate()
    {
        numberOfCollisionOld = numberOfCollisions;
        numberOfCollisions = 0;
        secondCollYPos = 0;
        firstCollYPos = 0;
        firstCollision = null;

        
    }

    void HandleSelection()
    {
        if (gyrate)
        {
            rigbody.velocity += new Vector3(.001f, 0, 0);
            gyrate = false;
        }
        else
        {
            rigbody.velocity -= new Vector3(.001f, 0, 0);
            gyrate = true;
        }//forces the rigidbody to be awake (the SetAwake method did not work)

        if (!controller.movingDown && !controller.movingUp)
        {
            if (controller.currentDirectionX >= 0)
            {

                
                if (holdingObj)
                {
                    ReorientSelectBox(new Vector3(.75f + heldObjHighlight.carryDist, 0, 0));
                    handsTransform.localPosition = new Vector3(.5f + heldObjHighlight.carryDist, 0, 0);
                    controller.controller.center = new Vector3(.5f+heldObjHighlight.carryDist,0,0);
                    heldObj.transform.localPosition = handsTransform.localPosition;
                }
                else
                {
                    ReorientSelectBox(new Vector3(.75f, 0, 0));
                    handsTransform.localPosition = new Vector3(.5f, 0, 0);
                }
              

            }
            else
            {
                
                if (holdingObj)
                {
                    ReorientSelectBox(new Vector3(-.75f - heldObjHighlight.carryDist, 0, 0));
                    handsTransform.localPosition = new Vector3(-.5f - heldObjHighlight.carryDist, 0, 0);
                    controller.controller.center = new Vector3(-.5f-heldObjHighlight.carryDist, 0, 0);
                    heldObj.transform.localPosition = handsTransform.localPosition;
                }
                else
                {
                    ReorientSelectBox(new Vector3(-.75f, 0, 0));
                    handsTransform.localPosition = new Vector3(-.5f, 0, 0);
                }
            }
        }
        else
        {
            if (controller.movingUp)
            {


                if (holdingObj)
                {
                    ReorientSelectBox(new Vector3(0, 1.25f + heldObjHighlight.carryDist, 0));
                    handsTransform.localPosition = new Vector3(0, .5f + heldObjHighlight.carryDist, 0);
                    controller.controller.center = new Vector3(0, .5f + heldObjHighlight.carryDist, 0);
                    heldObj.transform.localPosition = handsTransform.localPosition;
                }
                else
                {
                    ReorientSelectBox(new Vector3(0, 1.25f , 0));
                    handsTransform.localPosition = new Vector3(0, .5f, 0);
                }


            }
            else if (controller.movingDown)
            {

               
                if (holdingObj)
                {
                    ReorientSelectBox(new Vector3(0, -1 - heldObjHighlight.carryDist, 0));
                    handsTransform.localPosition = new Vector3(0, -.5f - heldObjHighlight.carryDist, 0);
                    controller.controller.center = new Vector3(0, -.5f-heldObjHighlight.carryDist, 0);
                    heldObj.transform.localPosition = handsTransform.localPosition;
                }
                else
                {
                    ReorientSelectBox(new Vector3(0, -1, 0));
                    handsTransform.localPosition = new Vector3(0, -.5f, 0);
                }
            }
        }

        if(!holdingObj)
        {
            controller.controller.center = new Vector3(0, 0, 0);
           
        }
    }
    void ReorientSelectBox(Vector3 pos)
    {
        if (lastPos != pos)
        {
            lastPos = pos;
            currentTimeToBoxReorient = 0;
        }

        currentTimeToBoxReorient += Time.deltaTime * 10;
        currentTimeToBoxReorient = Mathf.Clamp01(currentTimeToBoxReorient);
        Vector3 newPos = Vector3.Lerp(selectColl.localPosition, pos, currentTimeToBoxReorient);


        selectColl.localPosition = pos;
        
    }
    void HandledInteract()
    {
        if (((controller.playerOne && Input.GetAxisRaw("InteractOne") == 1) || (!controller.playerOne && Input.GetAxisRaw("InteractTwo") == 1)) && !performedInteraction)
        {

            if (currentHighlightedObj != null)
            {
                InteractionType type = highlight.interactionType;
                switch (type)
                {
                    case InteractionType.PickUp:
                        if (heldObj == null)
                        {
                            performedInteraction = true;
                            holdingObj = true;
                            heldObj = currentHighlightedObj;
                            heldObjHighlight = highlight;
                            heldObj.transform.parent = transform;
                            heldObj.transform.localPosition = handsTransform.localPosition;
                            currentHighlightedObj = null;
                            highlight.SetAlternateSprite(false);
                        }
                        break;

                    case InteractionType.Activate:
                        //actions possible if you are holding or not holding a part

                        


                        if (heldObj!=null)//actions only possible while holding parts
                        {
                            performedInteraction = true;
                            //checks to see if you can use a part to repair
                            RecieveParts partsReciver;
                            currentHighlightedObj.TryGetComponent(out partsReciver);
                            if(partsReciver!=null)
                            {
                                if (partsReciver.RecivePart(heldObjHighlight.partID))
                                {
                                    performedInteraction = true;
                                    holdingObj = false;
                                    controller.controller.center = new Vector3(0, 0, 0);
                                    Destroy(heldObj);
                                   
                                    if(highlight!=null)
                                    {
                                        highlight.SetAlternateSprite(false);
                                        currentHighlightedObj = null;
                                        highlight = null;
                                    }
                                    heldObjHighlight = null;
                                    heldObj = null;
                                    return;
                                }
                            }
                            //checks to see if you can activate a light breaker
                            ChangeLight changeLight;
                            currentHighlightedObj.TryGetComponent(out changeLight);
                            if (changeLight)
                            {
                                performedInteraction = true;
                                changeLight.SwitchLights(transform.position);
                                return;
                            }
                            //checks to see if you can pass a part
                            PassPart partsPasser;
                            currentHighlightedObj.TryGetComponent(out partsPasser);
                            if(partsPasser!=null)
                            {

                                if (partsPasser.TransferPart(heldObj, transform.position))
                                {
                                    performedInteraction = true;
                                    holdingObj = false;
                                    controller.controller.center = new Vector3(0, 0, 0);
                                    heldObj.transform.parent = null;
                                    heldObjHighlight = null;
                                    heldObj = null;
                                    return;
                                }
                            }

                        }
                        else//actions only possible while not holding parts
                        {
                            //checks to see if you can activate a light breaker
                            ChangeLight changeLight;
                            currentHighlightedObj.TryGetComponent(out changeLight);
                            if (changeLight)
                            {
                                performedInteraction = true;
                                changeLight.SwitchLights(transform.position);

                            }
                        }
                        break;


                    default:
                        Debug.Log("error for " + currentHighlightedObj.name);
                        break;

                }



            }

            if (currentHighlightedObj == null && !performedInteraction)//put down an object
            {
                if (heldObj != null)
                {
                    performedInteraction = true;
                    holdingObj = false;
                    controller.controller.center = new Vector3(0, 0, 0);
                    heldObj.transform.parent = null;
                    heldObjHighlight = null;
                    heldObj = null;

                }
            }
           

        }

        if (((controller.playerOne && Input.GetAxisRaw("InteractOne") == 0) || (!controller.playerOne && Input.GetAxis("InteractTwo") == 0))&&performedInteraction)
        {

            performedInteraction = false;
        }


        
    }

 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == heldObj&& holdingObj)
        {
            return;
        }

        if (selectableLayer == (selectableLayer.value | 1 << collision.gameObject.layer))
            {
                if(numberOfCollisionOld==0)
                { return; }

                //highlights only the most recent object
                currentHighlightedObj = collision.gameObject;
                if(highlight!=null)
                {
                    highlightOld = highlight;
                    highlightOld.SetAlternateSprite(false);
                    
                }
                highlight = currentHighlightedObj.GetComponent<Highlightable>();
            if (highlight.highlightable)
            {
                highlight.SetAlternateSprite(true);
            }
            else
            {
                highlight = null;
                currentHighlightedObj = null;
            }
                
               

            }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == heldObj&& holdingObj)
        {
            return;
        }

        if (selectableLayer == (selectableLayer.value | 1 << collision.gameObject.layer))
            {
                ++numberOfCollisions;
                
                if(numberOfCollisions>1)//checks the y pos, of the objects. then it only highlights the lowest one.
                {
                    secondCollYPos = collision.gameObject.transform.position.y;
                    if(highlightOld!=null)
                    {
                        highlightOld.SetAlternateSprite(false);
                    }
                    if (highlight != null)
                    {
                        highlightOld = highlight;
                        highlightOld.SetAlternateSprite(false);

                    }

                    if (secondCollYPos<firstCollYPos)
                    {

                        currentHighlightedObj = collision.gameObject;
                        highlight = currentHighlightedObj.GetComponent<Highlightable>();
                    if (highlight.highlightable)
                    {
                        highlight.SetAlternateSprite(true);
                    }
                    else
                    {
                        highlight = null;
                        currentHighlightedObj = null;
                    }


                }
                    else
                    {

                        currentHighlightedObj = firstCollision;
                        highlight = currentHighlightedObj.GetComponent<Highlightable>();
                     if (highlight.highlightable)
                    {
                        highlight.SetAlternateSprite(true);
                    }
                    else
                    {
                        highlight = null;
                        currentHighlightedObj = null;
                    }
                }

                    return;
                }
                else
                {
                    firstCollYPos = collision.gameObject.transform.position.y;
                    firstCollision = collision.gameObject;
                    if (numberOfCollisionOld > 1||numberOfCollisionOld==0)
                    {
                        return;
                    }
                }
               

                if (collision.gameObject != currentHighlightedObj)
                {
                    //highlights only the most recent object
                    currentHighlightedObj = collision.gameObject;
                    if (highlight != null)
                    {
                        highlightOld = highlight;
                        highlightOld.SetAlternateSprite(false);

                    }
                    highlight = currentHighlightedObj.GetComponent<Highlightable>();
                if (highlight.highlightable)
                {
                    highlight.SetAlternateSprite(true);
                }
                else
                {
                    highlight = null;
                    currentHighlightedObj = null;
                }
            }


            }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == heldObj&& holdingObj)
        {
            return;
        }

        if (selectableLayer == (selectableLayer.value | 1 << collision.gameObject.layer))
            {
                if (currentHighlightedObj = collision.gameObject)
                {
                    if(highlight!=null)
                    {
                        highlight.SetAlternateSprite(false);
                    }
                    if (highlightOld != null)
                    {
                        highlightOld.SetAlternateSprite(false);
                    }
                    currentHighlightedObj = null;
                }

               
            }
        
    }
}
