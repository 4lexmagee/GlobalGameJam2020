using UnityEngine;

public class PassToLeft : MonoBehaviour
{

    //public GameObject ThisWire;
    public GameObject WirePrefab;
    //public GameObject LeftSpawnLocation;

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("trigger enter ");
        if (coll.gameObject.name == "RightCollider")
        {
            GameObject SpawnLoc = GameObject.Find("LeftSpawnLoc");
            Debug.Log("coll with PassObj");
            Destroy(this.gameObject);
            Instantiate(WirePrefab, new Vector3(SpawnLoc.transform.position.x, SpawnLoc.transform.position.y, SpawnLoc.transform.position.z), Quaternion.identity);
        }
    }

}
