using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Valve.VR;

public class GameController : MonoBehaviour
{
    public GameObject redThrowable;
    public GameObject greenThrowable;
    public GameObject blueThrowable;

    public GameObject redClone;
    public GameObject greenClone;
    public GameObject blueClone;

    public Transform redStart;
    public Transform greenStart;
    public Transform blueStart;

    public AudioMixer audioMixer;

    public float softVolume;
    public float loudVolume;

    public int gemCount = 0;
    public int gemTotal = 130;
    //130

    // Start is called before the first frame update
    void Start()
    {
        redClone = Instantiate(redThrowable);
        greenClone = Instantiate(greenThrowable);
        blueClone = Instantiate(blueThrowable);

        softVolume = 0.1f;
        loudVolume = 5f;

        audioMixer.SetFloat("LowsVolume", softVolume);
        audioMixer.SetFloat("MidsVolume", softVolume);
        audioMixer.SetFloat("HighsVolume", softVolume);

        StartCoroutine("GameTimer");
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }


    }

    public void CreateThrowable (string color)
    {
        switch(color)
        {
            case "Red":
                Instantiate(redThrowable, redStart.position, Quaternion.identity);
                break;
            case "Green":
                Instantiate(greenThrowable, greenStart.position, Quaternion.identity);
                break;
            case "Blue":
                Instantiate(blueThrowable, blueStart.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    public void PlayAudio(string color)
    {
        switch (color)
        {
            case "Red":
                RaiseVolume("LowsVolume");
                break;
            case "Green":
                RaiseVolume("MidsVolume");
                break;
            case "Blue":
                RaiseVolume("HighsVolume");
                break;
            default:
                break;
        }
    }

    public void StopAudio(string color)
    {
        switch (color)
        {
            case "Red":
                LowerVolume("LowsVolume");
                break;
            case "Green":
                LowerVolume("MidsVolume");
                break;
            case "Blue":
                LowerVolume("HighsVolume");
                break;
            default:
                break;
        }
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(300);
        SceneManager.LoadScene(2);
    }

    public void AddCount()
    {
        gemCount++;
        Debug.Log(gemCount);
    }

    public void RaiseVolume(string parameter)
    {
        audioMixer.SetFloat(parameter, 5f);
        //audioMixer.GetFloat(parameter, out float value);
        //Debug.Log(value);
    }
    public void LowerVolume(string parameter)
    {
        audioMixer.SetFloat(parameter, -5f);
        //audioMixer.GetFloat(parameter, out float value);
        //Debug.Log(value);
    }
}
