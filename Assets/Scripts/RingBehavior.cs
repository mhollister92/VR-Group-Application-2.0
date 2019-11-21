using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPosition = new Vector3(0, 0, 0);
    private Vector3 endPosition = new Vector3(20, 20, 20);

    public float speed = 1f;
    public float startTime;
    public float distance;

    void Start()
    {
        transform.localScale = startPosition;
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, endPosition);
    }

    // Update is called once per frame
    void Update()
    {

        float distanceCovered = (Time.time - startTime) * speed;
        float t = distanceCovered / distance;
        transform.localScale = Vector3.Lerp(startPosition, endPosition, t);
    }
}
