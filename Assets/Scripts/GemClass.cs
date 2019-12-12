using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is a class to store values for each gem
//it holds the values for the red, green, and blue and bools for if the colors are active or not
public class GemClass : MonoBehaviour
{
    public float rValue;
    public float gValue;
    public float bValue;

    public bool rActive = false;
    public bool gActive = false;
    public bool bActive = false;

    public bool allActive = false;
}
