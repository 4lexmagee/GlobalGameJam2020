using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{

    public string ToLevel;
    public float SecondsDelay;

    void Start()
    {
        StartCoroutine(DelayStart());
        Debug.Log("Delay complete, loading main menu...");
        
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(SecondsDelay);
        SceneManager.LoadScene(ToLevel.Trim());
    }

}
