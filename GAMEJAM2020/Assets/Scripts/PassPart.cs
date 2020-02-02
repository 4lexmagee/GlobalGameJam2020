using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPart : MonoBehaviour
{
    public Transform depositLeft;
    public Transform depositRight;

    float currentTransferTime;
    bool leftToRight;
    GameObject transferObj;
    // Start is called before the first frame update
    void Start()
    {
        currentTransferTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transferObj != null)
        {
            TransferPart();
        }
    }

    public bool TransferPart(GameObject part, Vector3 position)
    {
        bool transfering = false;
        
        leftToRight = (Vector3.Distance(position, depositLeft.position) < Vector3.Distance(position, depositRight.position)) ? true : false;
        if (transferObj == null)
        {
            transferObj = part;
            transfering = true;
            currentTransferTime = 0;
        }
        return transfering;
    }
    public void TransferPart()
    {

        if (currentTransferTime < .3f)
        {
            currentTransferTime += Time.deltaTime;

            currentTransferTime = Mathf.Clamp01(currentTransferTime);
            float percent = currentTransferTime / .3f;
            Vector3 newPos = Vector3.zero;
            if (leftToRight)
            {
                Vector3 newDeposit = depositRight.position;
                newDeposit.z = -3;
                 newPos = Vector3.Lerp(depositLeft.position, newDeposit, percent);
            }
            else
            {
                Vector3 newDeposit = depositLeft.position;
                newDeposit.z = -3;
                newPos = Vector3.Lerp(depositRight.position, newDeposit, percent);
            }
            transferObj.transform.position = newPos;
        }
        else
        {
            transferObj = null;
            currentTransferTime = 0;
        }



    }


}
