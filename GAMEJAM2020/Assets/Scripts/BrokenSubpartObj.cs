using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenSubpartObj : MonoBehaviour
{
    SpriteRenderer spRenderer;
    public Sprite repairedSp;
    Sprite unrepairedSp;
    // Start is called before the first frame update
    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        unrepairedSp = spRenderer.sprite;
    }


    public void Repaired(bool repaired)
    {
        if(repaired)
        {
            spRenderer.sprite = repairedSp;
        }
        else
        {
            spRenderer.sprite = unrepairedSp;
        }
    }
}
