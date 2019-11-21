using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{

    private NavMeshAgent navAgent;

    //target to move unit to
    public Transform moveToLocation;

    Camera mainCamera;

    public AudioClip walking;


    void Start()
    {
        mainCamera = Camera.main;
        navAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //grab current distination to walk to from mouse click script
        moveToLocation = mainCamera.GetComponent<CameraController>().courserTarget;
        navAgent.SetDestination(moveToLocation.transform.position);

        //GetComponent<AudioSource>().PlayOneShot(walking);
    }
}
