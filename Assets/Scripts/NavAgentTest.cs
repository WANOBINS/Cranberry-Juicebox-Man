using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentTest : MonoBehaviour {
    NavMeshAgent Agent; 
    public enum TargetSetType{
        OnStart,
        OnUpdate,
        OnCoroutine
    }
    public TargetSetType TargettingFrequency;
    public float CoroutinePeriod = 0f;
    bool CoroutineRunning = false;
    GameObject Target;

    private void Awake()
    {
        Agent = gameObject.GetComponent<NavMeshAgent>();
        Target = GameObject.Find("NavAgentTarget");
    }

    // Use this for initialization
    void Start () {
		if(TargettingFrequency == TargetSetType.OnStart)
        {
            Retarget();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(TargettingFrequency == TargetSetType.OnUpdate)
        {
            Retarget();
        }
	}

    void StartCoroutine()
    {
        if(TargettingFrequency == TargetSetType.OnCoroutine)
        {
            if (!CoroutineRunning)
            {
                CoroutineRunning = true;
                StartCoroutine(RetargetLoop());
            }
            else
            {
                Debug.LogWarning("Coroutine already running!");
            }
        }
        else
        {
            Debug.LogWarning("To use Retergetting coroutine, set Targetting Frequency to \"OnCoroutine\"");
        }
    }

    void StopCoroutine()
    {
        CoroutineRunning = false;
    }

    IEnumerator RetargetLoop()
    {
        while (CoroutineRunning)
        {
            Retarget();
            yield return new WaitForSeconds(CoroutinePeriod);
        }
    }

    private void Retarget()
    {
        if (!Target)
        {
            throw new NullReferenceException(ToString() + " was told to target a null object");
        }
        if(Vector3.Distance(gameObject.transform.position,Target.transform.position) >= 2)
        {
            Agent.SetDestination(Target.transform.position);
        }
    }
}
