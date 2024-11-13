using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject AboutCanvas;
    // Start is called before the first frame update
    void Start()
    {
        AboutCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        Application.LoadLevel("Level1Scene");
    }

    public void AboutButton() 
    {
        AboutCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
