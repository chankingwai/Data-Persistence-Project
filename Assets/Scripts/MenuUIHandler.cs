using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    //public static MenuUIHandler Instance;
    //public string namePlayer;
    public Text ScoreTextBestUI;

    //Start is called before the first frame update
    void Start()
    {
        ScoreTextBestUI.text = $"Best Score : {UIManager.Instance.NameHighest} : {UIManager.Instance.H_Points}";
    }

    public void ReadName(string s)
    {
        UIManager.Instance.NameP = s;
    }

    //attached to Start Button
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    //attached to Exit Button
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
