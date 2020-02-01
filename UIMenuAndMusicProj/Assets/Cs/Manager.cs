using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public bool LevelComplete;

    //public AudioSource audioSource;

    //public AudioClip MenuMusic;
    //public AudioClip SettingsMusic;
    //public AudioClip LevelMusic;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        //DontDestroyOnLoad(audioSource);
    }

    void Update()
    {

        Scene a = SceneManager.GetActiveScene();

        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("esc key was pressed (pause fn)");
        }

        if (LevelComplete == true)
        {
            //get order for next level

            //set complete to false

            //goto that next levl

        }


        //audio

        //if (a.name == "MainMenu")
        //{
        //    if (audioSource.clip.name != MenuMusic.name)
        //    {
        //        audioSource.clip = MenuMusic;
        //        Debug.Log("Music change main menu");
        //    }

        //}

        //if (a.name == "SettingsMenu")
        //{
        //    if (audioSource.clip.name != SettingsMusic.name)
        //    {
        //        audioSource.clip = SettingsMusic;
        //        Debug.Log("Music change settings menu");
        //    }

        //}

        //if (a.name.ToLower().Contains("level"))
        //{
        //    if (audioSource.clip.name != LevelMusic.name)
        //    {
        //        audioSource.clip = LevelMusic;
        //        Debug.Log("Music change level menu");
        //    }

        //}

    }

}
