using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * this class attaches to the instantiated rings, it holds the info the ring needs for scaling
 * lerping is too much to explain in comments
 */
public class RingBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startScale = new Vector3(.01f, .01f, .01f);
    private Vector3 endScale = new Vector3(20, 20, 20);
    public Vector3 startPosition;
    //the rate the ring expands
    public float speed = 1f;
    //holds the time the ring is instantiated
    public float startTime;
    //holds the distance between the start and end position
    public float distance;

    void Start()
    {
        transform.position = startPosition;
        //sets the start scale of the object this is attacted to to the start scale
        transform.localScale = startScale;
        //sets the start time
        startTime = Time.time;
        //calculates the distance
        distance = Vector3.Distance(startScale, endScale);
    }

    // Update is called once per frame
    void Update()
    {
        //calculates how much the ring has scaled over each frame
        float distanceCovered = (Time.time - startTime) * speed;
        //holds a value between 0 and 1 which defines how far on the path the ring is
        float t = distanceCovered / distance;
        //lerps the scale of the object based on the start scale, end scale, and how far along
        //honestly, if you want to know more about lerping, the unity API has way more info
        transform.localScale = Vector3.Lerp(startScale, endScale, t);
    }
}
