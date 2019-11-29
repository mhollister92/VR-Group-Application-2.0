using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    // Start is called before the first frame update
    void Start()
    {
        redClone = Instantiate(redThrowable);
        greenClone = Instantiate(greenThrowable);
        blueClone = Instantiate(blueThrowable);

        lows.volume = 0.2f;
        mids.volume = 0.2f;
        high.volume = 0.2f;
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
                lows.volume = 1;
                break;
            case "Green":
                mids.volume = 1;
                break;
            case "Blue":
                high.volume = 1;
                break;
            default:
                break;
        }
    }

    public void StopAudio (string color)
    {
        switch (color)
        {
            case "Red":
                lows.volume = 0.2f;
                break;
            case "Green":
                mids.volume = 0.2f;
                break;
            case "Blue":
                high.volume = 0.2f;
                break;
            default:
                break;
        }
    }
}
