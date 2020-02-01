using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIBtnClick : MonoBehaviour
{
    public string ToLevel;
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate () {
            Debug.Log("uievent, loading scene: " + ToLevel);
            SceneManager.LoadScene(ToLevel.Trim());
        });
    }
}
