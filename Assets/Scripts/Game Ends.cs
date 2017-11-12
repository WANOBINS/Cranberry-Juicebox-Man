using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnds : MonoBehaviour {

    public AudioSource Source;
    public AudioClip YES;

    private void OnTriggerEnter(Collider other)
    {
        
    }

    IEnumerator DEATHFORYOU()
    {
        Source.clip.Equals(YES);
        Source.Play();
        yield return new WaitForSeconds(0.5f);
    }
}
