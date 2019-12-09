using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    public Canvas uiCanvas;
    public Button startButton;
    public Text tutorialText;
    public Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }
    public void StartGame()
    {
        Time.timeScale = 1.0f;
        uiCanvas.enabled = false;
        startButton.enabled = false;
        tutorialText.enabled = false;
        buttonText.enabled = false;
    }
}
