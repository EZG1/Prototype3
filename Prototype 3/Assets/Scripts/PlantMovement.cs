using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlantMovement : MonoBehaviour
{
    //bullet plants take to be destroyed
    int plantHealt = 4;
    
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


    //choose a random location to run to at corner location.
    public void setTagetPosition()
    {
        target.position = moveToLocation.position + new Vector3(Random.Range(-2, 2), 0, Random.Range(-2,2));
    }

    //call correct function on collion 
    private void OnTriggerEnter(Collider Box)
    {
        //call new checkpoint 
        if (Box.tag == "Checkpoint")
        {
            // moveToLocation = Find
            //print(Box.name);
            moveToLocation = Box.GetComponent<CornerDirections>().NextLocation;
            setTagetPosition();
        }
        //trigger bullet collision
        else if (Box.tag == "Bullet")
        {
            Box.GetComponent<DestroyBullet>().BulletHitPlant();
            plantHealt -= 1;
            print(plantHealt);

            if(plantHealt == 0)
            {
                this.gameObject.tag = "Untagged";
                Destroy(this.gameObject);
            }

        }     
        //trigger base DM taken
        else if (Box.tag == "EntPoint")
        {
            Camera.main.GetComponent<FindUnitTarget>().baseDamaged();
            Destroy(this.gameObject);
        }
    }
}
