using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLookForTarget : MonoBehaviour
{
    public float secondsToCovert = 0.0f;
    public int seconds;

    public GameObject[] plantTargets;
    public GameObject target;
    int timeToFindTarget = 0;

    int distanceBetweenObjects = 20;
 
    void Start()
    {
        //plantTargets = GameObject.FindGameObjectsWithTag("Plant");
        plantTargets = Camera.main.GetComponent<FindUnitTarget>().plantsToKill;
    }

    // Update is called once per frame
    void Update()
    {
        secondsToCovert = Time.realtimeSinceStartup;
        seconds = Mathf.FloorToInt(secondsToCovert);

        if (timeToFindTarget < seconds)
        {
            timeToFindTarget = seconds + 1;

            for (int x = 0; x < distanceBetweenObjects; x++)
            {
                for (int i = 0; i < plantTargets.Length; i++)
                {

                    if (Vector3.Distance(this.transform.position, plantTargets[i].transform.position) < Mathf.Round(x))
                    {
                        target = plantTargets[i];
                        print(target.name);
                        print(Vector3.Distance(this.transform.position, plantTargets[i].transform.position));
                        this.gameObject.GetComponent<UnitTrackPlantToShootAt>().targetPlant = plantTargets[i];
                        this.gameObject.GetComponent<UnitTrackPlantToShootAt>().foundTarget = true;
                        return;
                    }
                    print(i);
                }
                print(x);
            }
            target = null;
            this.gameObject.GetComponent<UnitTrackPlantToShootAt>().foundTarget = false;
        }
    }
}
