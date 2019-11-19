using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{

    private NavMeshAgent navAgent;

    public Transform moveToLocation;

    Camera mainCamera;
    

    void Start()
    {
        mainCamera = Camera.main;
        navAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        moveToLocation = mainCamera.GetComponent<CameraController>().courserTarget;
        navAgent.SetDestination(moveToLocation.transform.position);
    }
}
