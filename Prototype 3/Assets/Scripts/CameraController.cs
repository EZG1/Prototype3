﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    //sound assets and speaker
    private AudioSource buttonsSpeaker;
    public AudioClip buildingBarracks;
    public AudioClip buildingUnit;
    public AudioClip UnitBuilt;
    
    public GameObject cameraHolder;

    //target for units to move too.
    public Transform courserTarget;

    //objects to create
    public GameObject unit;
    public GameObject barack;

    //bool for disabling barrack placemet
    bool baracksPlaced = false;
    public GameObject instantiatedBarack;

    public GameObject goldCounterObject;

    bool placingBarack = false;

    void Awake()
    {
        buttonsSpeaker = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
    } 
   
    // Update is called once per frame
    void Update()
    {
        
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if (Camera.main != null)
        {
            cameraHolder.transform.Translate(new Vector3(xAxisValue, zAxisValue, 0.0f));
            //Camera.main.transform.Translate(new Vector3(xAxisValue, zAxisValue, 0.0f));
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point,Color.black,5f);
                //Debug.Log("Ray Shot");
                //Debug.Log(hit.transform.name);

                if(hit.transform.tag != "Button")
                {
                    courserTarget.position = hit.point;
                } 
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.black, 5f);
                //Debug.Log("Ray Shot");
                //Debug.Log(hit.transform.name);
             
                //create barracks if button and gold are correct, then adjust components acordingly
                if(placingBarack == true & goldCounterObject.GetComponent<GoldCounter>().currentGold > 9 & baracksPlaced == false)
                {
                    GameObject newBarrack;
                    newBarrack = Instantiate(barack, hit.point, Quaternion.identity) as GameObject;
                    goldCounterObject.GetComponent<GoldCounter>().currentGold -= 10;
                    instantiatedBarack = newBarrack;
                    placingBarack = false;
                    baracksPlaced = true;
                    buttonsSpeaker.PlayOneShot(buildingBarracks);
                }
            }
        }
    }

    //enable barrack placement
    public void PlaceingBarack()
    {
        if(goldCounterObject.GetComponent<GoldCounter>().currentGold > 9)
        {
            buttonsSpeaker.PlayOneShot(buildingBarracks);
            placingBarack = !placingBarack;
            print("Placeing baracks");
            
        }
    }

    //buid unit if barracks is made
    public void createUnit()
    {
        if(baracksPlaced == true & goldCounterObject.GetComponent<GoldCounter>().currentGold > 4)
        {
            buttonsSpeaker.PlayOneShot(buildingUnit);
            goldCounterObject.GetComponent<GoldCounter>().currentGold -= 5;
            //create unit after delay
            StartCoroutine(waitTime());
        }
    }

    //dellay trigger for unit placement to allow for sound
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(3);
        Transform spawnLocation = instantiatedBarack.GetComponent<Barracks>().spawnLocation;
        Instantiate(unit, spawnLocation);
        buttonsSpeaker.PlayOneShot(UnitBuilt);
    }

}
