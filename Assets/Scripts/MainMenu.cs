using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Button variables.
    public Button play;
    public Button options;
    public Button quit;

    // Colorblind Mode variables
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    void Start()
    {
        play.onClick.AddListener(PlayMaze);
        quit.onClick.AddListener(QuitMaze);
    }

    public void PlayMaze()
    {
        if (colorblindMode.isOn == true)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;

        } else {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene("Maze");
    }

    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
