using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelManager : MonoBehaviour
{

    public string NextLevel;
    public bool IsComplete;

    void Update()
    {
        if (IsComplete == true)
        {
            SceneManager.LoadScene(NextLevel.Trim());

        }
    }

}
