using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This script attaches to the bowls in the scene
 * it instantiates and deletes the sound waves
 * it starts and stops the tones
 */
public class BowlBehavior : MonoBehaviour
{
    private float timer;
    private float startTime;
    private bool isTouching;
    private bool ringInstantiated = false;

    public GameObject ring;
    public GameObject ringClone;

    public AudioSource tone;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the bowl and stick are touching start the timer which is used later for expanding the ring
        //also instantiate a new ring if a ring hasn't already been instantiated and sets ringInstantiated to true
        //this is to prevent new rings instantiating every frame the bowl and stick are touching
        //
        if(isTouching)
        {
            timer = Time.deltaTime - startTime;
            if (!ringInstantiated)
            {
                ringClone = Instantiate(ring);
                PlayTone();
                ringInstantiated = true;
            }
        }
        //once the bowl and stick aren't touching, set ringInstantiated to false so a new one will spawn next time they touch
        //Also start the coroutine for fading the sound
        //and destroy the clone of the ring we instantiated
        if(!isTouching)
        {
            ringInstantiated = false;
            StartCoroutine("Fade");
            Destroy(ringClone);
        }
    }
    //This function runs when the bowl collides with another object with a collider
    //It checks that the other object is tagged as stick because we only want things to happen when the bowl and stick touch
    //it sets the start time to the time the function is called and sets isTouching to true.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stick"))
        {
            Debug.Log("Enter");
            startTime = Time.deltaTime;
            isTouching = true;
        }
    }
    //This function runs when the bowl and other object are no longer touching. We don't care about whether it stopped touching the stick or not
    //this sets isTouching to false
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        isTouching = false;
    }
    //this is a short function to start the tone if the tone is not already playing
    private void PlayTone()
    {
        if(!tone.isPlaying)
        {
            tone.volume = 1;
            tone.Play();
        }
    }
    //this is a coroutine which fades the music out over a short amount of time and then stops the music
    IEnumerator Fade()
    {
        while(tone.volume > 0.01f)
        {
            tone.volume -= Time.deltaTime / 2.0f;
            yield return null;
        }
        tone.volume = 0;
        tone.Stop();
    }
}
