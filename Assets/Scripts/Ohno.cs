using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ohno : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip ohNo;
    public AudioEchoFilter Echo;

    public AudioSource cranSource;
    public AudioClip YES;
    public AudioClip wallCrash;
    
    private int ohNoCount = 0;
    public float ohNoDelay;

    // Use this for initialization
    private void Awake()
    {
        //Source = GetComponent<AudioSource>();
        Source.clip = ohNo;
        cranSource.clip = wallCrash;
    }

    // Update is called once per frame
    void Update ()
    {
		// for test
        if(Input.GetKeyDown(KeyCode.Space))
        {            
            Source.PlayDelayed(ohNoDelay); //plays ohNo on delay
            ohNoCount++;
        }
        if (ohNoCount >= 3)
        {
            cranSource.Play(); //plays wallCrash
            cranSource.PlayOneShot(YES);
            ohNoCount = 0;
        }
	}
}
