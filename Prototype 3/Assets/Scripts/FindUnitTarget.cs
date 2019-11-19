using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindUnitTarget : MonoBehaviour
{
    public GameObject[] plantsToKill;
    public int howManyTargetsThereAre;

    // Start is called before the first frame update

    void Awake()
    {
        FindPlantsToKill();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindPlantsToKill();
        // for( int i = 0; i < plantsToKill.Length; i++)
        //print(plantsToKill.Length);
    }

    public void FindPlantsToKill()
    {
        plantsToKill = GameObject.FindGameObjectsWithTag("Plant");
    }

}
