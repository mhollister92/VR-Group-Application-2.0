using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * this class controls how the gems behave
 */
public class GemBehavior : MonoBehaviour
{
    //variables to hold references to the gem class and the renderer on the gem itself
    public GemClass gem;
    public Renderer gemRenderer;
    public Light gemLight;
    public bool alreadyCounted = false;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        //assigns the renderer on the object this script is attached to and assigns it to the gemMaterial variable
        gemRenderer = gameObject.GetComponent<Renderer>();
        gemLight = gameObject.GetComponent<Light>();

        gemLight.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsAllActive())
        {
            gemRenderer.material.color = new Color(gem.rValue / 255f, gem.gValue / 255f, gem.bValue / 255f, gemRenderer.material.color.a);
            gemLight.enabled = true;
            gem.allActive = true;
            if (!alreadyCounted)
            {
                gameController.AddCount();
                alreadyCounted = true;
            }
        }
    }
    //this function runs when something collides with the gem
    private void OnTriggerEnter(Collider other)
    {
        // if the object that collides with the gem is tagged red, check if the red value of the gem is already active,
        // if not, set the red value to the red value stored in the gem class for this gem and don't change the green or blue
        if (other.CompareTag("Red"))
        {
            if (!IsActive(1))
            {
                gemRenderer.material.color = new Color(gem.rValue / 255f, gemRenderer.material.color.g, gemRenderer.material.color.b, gemRenderer.material.color.a);
                gemLight.enabled = true;
                gem.rActive = true;
            }
        }
        //if the object is tagged green, check if green is active and if not, set the green value and dont change the red or blue
        else if (other.CompareTag("Green"))
        {
            if (!IsActive(2))
            {
                gemRenderer.material.color = new Color(gemRenderer.material.color.r, gem.gValue / 255f, gemRenderer.material.color.b, gemRenderer.material.color.a);
                gemLight.enabled = true;
                gem.gActive = true;
            }
        }
        //if the object is tagged blue, check if blue is active and if not, set the blue value and dont change the red or geen
        else if (other.CompareTag("Blue"))
        {
            if (!IsActive(3))
            {
                gemRenderer.material.color = new Color(gemRenderer.material.color.r, gemRenderer.material.color.g, gem.bValue / 255f, gemRenderer.material.color.a);
                gemLight.enabled = true;
                gem.bActive = true;
            }
        }
        //if all the colors are active, don't change the values

    }
    //this is a function that returns true or false, it takes an int and that decides which value it checks
    //if the int is 1, it checks if the red is active and returns true or false, and so on
    bool IsActive(int color)
    {
        if (color == 1)
        {
            return gem.rActive;
        }
        else if (color == 2)
        {
            return gem.gActive;
        }
        else if (color == 3)
        {
            return gem.bActive;
        }
        else
            return false;
    }
    //this is a function to check if all the colors in a gem are active
    bool IsAllActive()
    {
        if (gem.rActive && gem.gActive && gem.bActive)
        {
            return true;
        }
        else
            return false;
    }
}