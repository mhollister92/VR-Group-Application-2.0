using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlBehavior : MonoBehaviour
{
    private float timer;
    private float startTime;
    private bool isTouching;
    private bool ringInstantiated = false;

    public GameObject ring;
    public GameObject ringClone;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouching)
        {
            timer = Time.deltaTime - startTime;
            if (!ringInstantiated)
            {
                ringClone = Instantiate(ring);
                ringInstantiated = true;
            }
        }
        if(!isTouching)
        {
            ringInstantiated = false;
            Destroy(ringClone);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stick"))
        {
            Debug.Log("Enter");
            startTime = Time.deltaTime;
            isTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        isTouching = false;

    }
}
