using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void quitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void backToMain()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
