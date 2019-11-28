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

    // Start is called before the first frame update
    void Start()
    {
        redClone = Instantiate(redThrowable);
        greenClone = Instantiate(greenThrowable);
        blueClone = Instantiate(blueThrowable);
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
}
