using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        void Start()
        {

        }
    } 
   
    // Update is called once per frame
    void Update()
    {
        
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if (Camera.main != null)
        {
            Camera.main.transform.Translate(new Vector3(xAxisValue, zAxisValue, 0.0f));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition),Color.black,5f);
            }
        }
        
    }
}
