using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnd : MonoBehaviour {

    public GameObject CranberryJuiceMan;
    public GameManager GM;

    public AudioClip OhNo1;
    public AudioClip OhNo2;
    public AudioClip OhNo3;

	// Use this for initialization
	void Start () {
        GM = FindObjectOfType<GameManager>();
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(GM.OhNo1 == false)
        {
            // Insert Audio Clip Playing Here
            GM.OhNo1 = true;
        }

        if(GM.OhNo1 == true && GM.OhNo2 == false)
        {
            // Insert Audio Clip Playing Here
            GM.OhNo2 = true;
        }

        if(GM.OhNo1 == true && GM.OhNo2 == true)
        {
            // Insert Audio Clip Playing Here
            // Insert Death Here
            // Shoebopadoo
        }

    }
}
