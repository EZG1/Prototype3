using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{

    float secondsToCovert = 0.0f;
    public int seconds;
    public Text goldCounter;
    public int currentGold = 0;
    public int timeToAddGold = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsToCovert = Time.realtimeSinceStartup;
        seconds = Mathf.FloorToInt(secondsToCovert);

        if(timeToAddGold < seconds)
        {
            timeToAddGold = seconds + 1;
            currentGold += 1;
        }


        goldCounter.text = "Current Gold: " + (currentGold).ToString();


    }
}
