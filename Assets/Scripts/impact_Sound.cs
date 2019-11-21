// Sound controller script for cave project
//
// References/ tutorials used:
// https://www.youtube.com/watch?v=OrJXjnNcyE0 
// https://asyncaudio.com/blogs/tutorials/how-to-create-a-simple-audio-impact-collision-trigger-with-unity 
//
//
//--------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impact_Sound : MonoBehaviour {

   public AudioSource source;

        // Awaken the sound
        void Awake() {
        if (source == null)
        source = GetComponent<AudioSource>();

        }

    //--------------------------------------------------------------

    //  On collision between the two objects, call the play sound function.
    private void OnCollisionEnter(Collision collision){
        playSound();
        
        }


    //  When contact between the two sounds ends, call the play sound function.
    private void OnCollisionExit(Collision collision)
    {
            if (source.isPlaying) {
            StartCoroutine("fadeSound");
 
            }
        }

    //--------------------------------------------------------------

    //Play the sounds
    private void playSound(){
        if (!source.isPlaying){
            source.volume = 1;
            source.Play();
        }
    }

    //Stop the sounds
    private void stopSound(){
        source.Stop();

    }

    //--------------------------------------------------------------

    //Coroutine
    IEnumerator fadeSound(){
            while (source.volume > 0.01f) {
                source.volume -= Time.deltaTime / 2f;
                yield return null;
            }
            source.volume = 0;
            source.Stop();

        }

    }