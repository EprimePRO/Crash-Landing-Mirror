using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button exit;
    public Button play;
    GameObject mainMenu;
    GameObject levelSelect;

    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(ExitGame);
        play.onClick.AddListener(LoadLevel);
        mainMenu = GameObject.FindGameObjectWithTag("Main");
        levelSelect = GameObject.Find("LevelSelect");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LoadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void ExitGame()
    {
        Application.Quit();
    }
    
}
