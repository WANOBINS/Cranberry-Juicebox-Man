using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ohno : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip ohNo;
    public AudioClip YES;
    public AudioEchoFilter Echo;
    private int ohNoCount = 0;
    public float ohNoDelay;

    // Use this for initialization
    private void Awake()
    {
        Source = GetComponent<AudioSource>();
        Source.clip = ohNo;
    }

    // Update is called once per frame
    void Update ()
    {
		// for test
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            Source.PlayDelayed(ohNoDelay);
            ohNoCount++;
        }
        if (ohNoCount >= 3)
        {
            Source.PlayOneShot(YES);
            ohNoCount = 0;
        }
	}
}
