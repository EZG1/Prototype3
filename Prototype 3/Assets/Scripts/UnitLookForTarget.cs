using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLookForTarget : MonoBehaviour
{
    //time float + int
    public float secondsToCovert = 0.0f;
    public int seconds;

    public GameObject[] plantTargets;
    public GameObject target;
    int timeToFindTarget = 0;

    //distance to check 
    int distanceBetweenObjects = 20;
 
    void Start()
    {
        //plantTargets = GameObject.FindGameObjectsWithTag("Plant");
        plantTargets = Camera.main.GetComponent<FindUnitTarget>().plantsToKill;
    }

    // Update is called once per frame
    void Update()
    {
        //track seconds
        secondsToCovert = Time.realtimeSinceStartup;
        seconds = Mathf.FloorToInt(secondsToCovert);

        //call each second
        if (timeToFindTarget < seconds)
        {
            timeToFindTarget = seconds + 1;

            //check for closest plant to unit at each distance, 1,2,3 ect up to distance variable 
            for (int x = 0; x < distanceBetweenObjects; x++)
            {
                //check each plant in list
                for (int i = 0; i < plantTargets.Length; i++)
                {
                    //if plant is missing exit
                    if (plantTargets[i] == null)
                    {
                        plantTargets = Camera.main.GetComponent<FindUnitTarget>().plantsToKill;
                        return;
                    }
                    //if target matches range set as target and exit loop
                    else if (Vector3.Distance(this.transform.position, plantTargets[i].transform.position) < Mathf.Round(x))
                    {
                        target = plantTargets[i];
                        print(target.name);
                        print(Vector3.Distance(this.transform.position, plantTargets[i].transform.position));
                        this.gameObject.GetComponent<UnitTrackPlantToShootAt>().targetPlant = plantTargets[i];
                        this.gameObject.GetComponent<UnitTrackPlantToShootAt>().foundTarget = true;
                        return;
                    }
                    //print(i);
                }
            }
            //if no target is found remove current target
            target = null;
            this.gameObject.GetComponent<UnitTrackPlantToShootAt>().foundTarget = false;
        }
    }
}
