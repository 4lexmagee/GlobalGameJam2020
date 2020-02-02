using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class TopDownController : MonoBehaviour
{
    public float speed;
    public bool playerOne;
    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public float currentDirectionX;
    [HideInInspector]
    public float currentDirectionY;
    [HideInInspector]
    public bool movingUp;
    [HideInInspector]
    public bool movingDown;
    [HideInInspector]
     Vector2 targetVelocy;
    Animator anims;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anims = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        targetVelocy = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocy = Vector2.zero;
        if (playerOne)
        {
            targetVelocy = new Vector3(Input.GetAxisRaw("HorizontalOne"), Input.GetAxisRaw("VerticalOne"));

            if (Input.GetAxisRaw("VerticalOne") > 0)
            {
                anims.SetBool("Up", true);
                
            }
            else
            {
                anims.SetBool("Up", false);
            }

            if (Input.GetAxisRaw("VerticalOne") < 0)
            {
                anims.SetBool("Down", true);

            }
            else
            {
                anims.SetBool("Down", false);
            }

            if (Input.GetAxisRaw("HorizontalOne") > 0)
            {
                renderer.flipX = false;
            }
            else
            {
                renderer.flipX = true;
            }

            if(Input.GetAxisRaw("HorizontalOne")!=0)
            {
                anims.SetBool("Horizontal",true);
                anims.SetBool("Up", false);
                anims.SetBool("Down", false);
            }
            else
            {
                anims.SetBool("Horizontal", false);
                
            }

            
        }
        else
        {
            targetVelocy = new Vector3(Input.GetAxisRaw("HorizontalTwo"), Input.GetAxisRaw("VerticalTwo"));

            if (Input.GetAxisRaw("VerticalTwo") > 0)
            {
                anims.SetBool("Up", true);

            }
            else
            {
                anims.SetBool("Up", false);
            }

            if (Input.GetAxisRaw("VerticalTwo") < 0)
            {
                anims.SetBool("Down", true);

            }
            else
            {
                anims.SetBool("Down", false);
            }

            if (Input.GetAxisRaw("HorizontalTwo") > 0)
            {
                renderer.flipX = false;
            }
            else
            {
                renderer.flipX = true;
            }

            if (Input.GetAxisRaw("HorizontalTwo") != 0)
            {
                anims.SetBool("Horizontal", true);
                anims.SetBool("Up", false);
                anims.SetBool("Down", false);
            }
            else
            {
                anims.SetBool("Horizontal", false);

            }
        }
        targetVelocy *= speed * Time.deltaTime;
        if (targetVelocy.x != 0 && targetVelocy.y != 0)
        {
            targetVelocy *= .7f;
        }
        if (targetVelocy.x != 0)
        {
            currentDirectionX = Mathf.Sign(targetVelocy.x);
        }
        if (targetVelocy.y != 0)
        {
            currentDirectionY = Mathf.Sign(targetVelocy.y);
        }
        if (targetVelocy.x == 0)
        {
            if (targetVelocy.y > 0)
            {
                movingUp = true;
                movingDown = false;
            }
            else if (targetVelocy.y < 0)
            {
                movingUp = false;
                movingDown = true;
            }
           
        }
        else
        {
            movingUp = movingDown = false;
        }
     

        controller.Move(targetVelocy);
    }
}
