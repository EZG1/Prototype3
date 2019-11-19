﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject cameraHolder;
    public Transform courserTarget;

    public GameObject Barack;
    public GameObject goldCounterObject;

    private bool placingBarack = false;

    public Button placeBaracksButton;
    public ColorBlock buttonColor;


    // Start is called before the first frame update
    void Start()
    {
        buttonColor = placeBaracksButton.colors;
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
                Debug.Log("Ray Shot");
                Debug.Log(hit.transform.name);

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
                Debug.Log("Ray Shot");
                Debug.Log(hit.transform.name);
             
                if(placingBarack == true & goldCounterObject.GetComponent<GoldCounter>().currentGold > 9)
                {
                    Instantiate(Barack, hit.point, Quaternion.identity);
                    goldCounterObject.GetComponent<GoldCounter>().currentGold -= 10;
                    placingBarack = false;
                }
            }
            
        }
        buttonColor.normalColor = Color.red;

        if (placingBarack == true)
        {
            buttonColor.normalColor = Color.red;
        }
       /* else
        {
            buttonColor.normalColor = Color.white;
        } */

    }

    public void PlaceingBarack()
    {
        if(goldCounterObject.GetComponent<GoldCounter>().currentGold > 9)
        {
            placingBarack = !placingBarack;
            print("Placeing baracks");
        }
    }

}
