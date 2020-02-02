using UnityEngine;

public class PassToRight : MonoBehaviour
{

    //public GameObject ThisWire;
    public GameObject WirePrefab;
    //public GameObject RightSpawnLocation;

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("trigger enter ");
        if (coll.gameObject.name == "LeftCollider")
        {
            GameObject SpawnLoc = GameObject.Find("RightSpawnLoc");
            Debug.Log("coll with PassObj");
            Destroy(this.gameObject);
            Instantiate(WirePrefab, new Vector3(SpawnLoc.transform.position.x, SpawnLoc.transform.position.y, SpawnLoc.transform.position.z), Quaternion.identity);
        }
    }

}
