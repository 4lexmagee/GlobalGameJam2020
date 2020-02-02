using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class EscapeDetector : MonoBehaviour
{
    public int numberEscaped;
    public LayerMask playerLayer;
    public GameObject doorL;
    public GameObject doorR;
    RecieveParts partsL;
    RecieveParts partsR;
    bool deletedDoors;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        partsL = doorL.GetComponent<RecieveParts>();
        partsR = doorR.GetComponent<RecieveParts>();
        numberEscaped = 0;
        deletedDoors = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!deletedDoors)
        {
            if (partsL.repaired && partsR.repaired)
            {
                Destroy(doorL);
                Destroy(doorR);
                deletedDoors = true;
            }
        }

            if (numberEscaped >= 2)
            {
            SceneManager.LoadScene(nextScene);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (playerLayer == (playerLayer.value | 1 << other.gameObject.layer))
            {
                ++numberEscaped;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (playerLayer == (playerLayer.value | 1 << other.gameObject.layer))
            {
                --numberEscaped;
            }
        }
    }
