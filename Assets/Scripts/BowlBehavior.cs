using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    public bool ringInstantiated = false;
    private Rigidbody rigidBody;

    public GameObject ring;
    public GameObject ringClone;
    public RingBehavior ringBehavior;

    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
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
                rigidBody.velocity = new Vector3(0, 0, 0);
                gameController.PlayAudio(this.tag);
                ringClone = Instantiate(ring);
                ringInstantiated = true;
                StartCoroutine("RingTimer");
            }
        }
    }

    //this is a coroutine which fades the music out over a short amount of time and then stops the music

    IEnumerator RingTimer()
    {
        yield return new WaitForSeconds(5);
        ringInstantiated = false;
        gameController.CreateThrowable(this.tag);
        gameController.StopAudio(this.tag);
        Destroy(this.gameObject);
        Destroy(ringClone);
    }
}
