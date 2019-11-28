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
    public RingBehavior ringBehavior;
    public AudioSource tone;

    private Vector3 startPosition;
    private Rigidbody rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Plane")
        {
            Debug.Log("Hit");
            isTouching = true;
            ringBehavior.startPosition = new Vector3(transform.position.x, ring.transform.position.y, transform.position.z);
            startTime = Time.deltaTime;
            if (!ringInstantiated)
            {
                ringClone = Instantiate(ring);
                PlayTone();
                ringInstantiated = true;
                StartCoroutine("RingTimer");
                
            }
        }
    }

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

    IEnumerator RingTimer()
    {
        yield return new WaitForSeconds(5);
        ringInstantiated = false;
        StartCoroutine("Fade");
        Destroy(ringClone);
    }
}
