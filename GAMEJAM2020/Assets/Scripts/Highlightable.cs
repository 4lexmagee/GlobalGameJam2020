using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
    public Sprite spriteTwo;
    Sprite spriteOne;

    SpriteRenderer spRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        spriteOne = spRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAlternateSprite(bool currentlySelected)
    {
        if(currentlySelected)
        {
            spRenderer.sprite = spriteTwo;
        }
        else
        {
            spRenderer.sprite = spriteOne;
        }
    }
}
