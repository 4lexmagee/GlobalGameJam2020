using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class TopDownController : MonoBehaviour
{
    public float speed;
    public bool playerOne;
    CharacterController controller;
    [HideInInspector]
    public float currentDirectionX;
    [HideInInspector]
    public float currentDirectionY;
    [HideInInspector]
    public bool movingUp;
    [HideInInspector]
    public bool movingDown;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetVelocy = Vector2.zero;
        if (playerOne)
        {
            targetVelocy = new Vector3(Input.GetAxisRaw("HorizontalOne"), Input.GetAxisRaw("VerticalOne"));



        }
        else
        {
            targetVelocy = new Vector3(Input.GetAxisRaw("HorizontalTwo"), Input.GetAxisRaw("VerticalTwo"));
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
