using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnd : MonoBehaviour {

    public GameObject CranberryJuiceMan;
    public GameManager GM;

    public AudioClip OhNo1;
    public AudioClip OhNo2;
    public AudioClip Yes;

    public AudioSource Source;

    public GameObject CBJBM;

	// Use this for initialization
	void Start () {
        GM = FindObjectOfType<GameManager>();
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (GM.OhNo1 == true && GM.OhNo2 == true)
        {
            StartCoroutine(Death());
        }

        if (GM.OhNo1 == true && GM.OhNo2 == false)
        {
            Source.Play();
            GM.OhNo2 = true;
        }


        if (GM.OhNo1 == false)
        {
            Source.clip = OhNo1;
            Source.Play();
            GM.OhNo1 = true;
        }
       
    }

    IEnumerator Death()
    {
        Source.clip = OhNo2;
        Source.Play();
        yield return new WaitForSeconds(1.0f);
        Instantiate(CBJBM, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Source.clip = Yes;
        Source.Play();
        yield return new WaitForSeconds(2.0f);
        Application.Quit();
    }
}
