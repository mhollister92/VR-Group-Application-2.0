using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public AudioSource lows;
    public AudioSource mids;
    public AudioSource high;

    public float volume;

    public int gemCount = 0;
    public int gemTotal = 10;
    //129

    // Start is called before the first frame update
    void Start()
    {
        redClone = Instantiate(redThrowable);
        greenClone = Instantiate(greenThrowable);
        blueClone = Instantiate(blueThrowable);
        volume = 0.2f;

        lows.volume = volume;
        mids.volume = volume;
        high.volume = volume;

        StartCoroutine("GameTimer");
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
                volume = 1f;
                lows.volume = volume;
                //Debug.Log(lows.volume);
                break;
            case "Green":
                volume = 1f;
                mids.volume = volume;
                //Debug.Log(mids.volume);
                break;
            case "Blue":
                volume = 1f;
                high.volume = volume;
                //Debug.Log(high.volume);
                break;
            default:
                break;
        }
        volume = 0.2f;
    }

    public void StopAudio(string color)
    {
        switch (color)
        {
            case "Red":
                volume = 0.2f;
                lows.volume = volume;
                break;
            case "Green":
                volume = 0.2f;
                mids.volume = volume;
                break;
            case "Blue":
                volume = 0.2f;
                high.volume = volume;
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
        yield return new WaitForSeconds(60);
        SceneManager.LoadScene(2);
    }

    public void AddCount()
    {
        gemCount++;
        Debug.Log(gemCount);
    }
}
