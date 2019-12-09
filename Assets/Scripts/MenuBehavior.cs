using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    public Canvas uiCanvas;
    public Text tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TutorialTimer");
    }

    IEnumerator TutorialTimer()
    {
        yield return new WaitForSeconds(10);
        uiCanvas.enabled = false;
        tutorialText.enabled = false;
    }
}
