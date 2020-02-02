using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Highlightable : MonoBehaviour
{
   // public Sprite spriteTwo;
    //Sprite spriteOne;
    public Light highlightGlow;
    public float lightRadius = 5;
    //SpriteRenderer spRenderer;
    public InteractionType interactionType;
    public float carryDist;
    public int partID;
    public bool highlightable=true;
    // Start is called before the first frame update
    void Start()
    {
        highlightGlow.range = lightRadius;
        highlightGlow.enabled = false;
        //spRenderer = GetComponent<SpriteRenderer>();
        //spriteOne = spRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAlternateSprite(bool currentlySelected)
    {
        if(currentlySelected)
        {
            //spRenderer.sprite = spriteTwo;
            highlightGlow.enabled = true;
        }
        else
        {
            highlightGlow.enabled = false;
            //spRenderer.sprite = spriteOne;
        }
    }

    
}
public enum InteractionType { PickUp, Activate }
