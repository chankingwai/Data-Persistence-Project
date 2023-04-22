using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.IO;//for JSON

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public int H_Points;
    public string NameHighest;
    public string NameP;

    private void Awake()
    {
        //Ensure this static exists only once throughout
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //Ensure this static exists and won't be destroyed on load
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadName();
    }

    //Following class and 2 methods use Json to save and retrieve saved player name and best score
    [System.Serializable]
    class SaveData
    {
        public string NameHighest;
        public int H_Points;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.NameHighest = NameHighest;
        data.H_Points = H_Points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            NameHighest = data.NameHighest;
            H_Points = data.H_Points;
        }
    }
 
}
