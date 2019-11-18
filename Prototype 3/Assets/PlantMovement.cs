using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlantMovement : MonoBehaviour
{

    private NavMeshAgent navAgent;

    public Transform moveToLocation;
    public Transform target;
    GameObject startLocation;

    /*public Transform CheckpointLocation;

    public Transform Target1;
    public Transform Target2;
    public Transform Target3;
    public Transform Target4;

    public Transform[] Targets;*/

    void Start()
    {
        startLocation = GameObject.Find("CornerDirections1");
        moveToLocation = startLocation.transform;
        setTagetPosition();
        navAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(target.transform.position);
    }


    //choose a random location to run to.
    public void setTagetPosition()
    {
        target.position = moveToLocation.position + new Vector3(Random.Range(-2, 2), 0, Random.Range(-2,2));
    }

    private void OnTriggerEnter(Collider Box)
    {
        if (Box.tag == "Checkpoint")
        {
            // moveToLocation = Find
            print(Box.name);
            moveToLocation = Box.GetComponent<CornerDirections>().NextLocation;
            setTagetPosition();
        }
    }
}
