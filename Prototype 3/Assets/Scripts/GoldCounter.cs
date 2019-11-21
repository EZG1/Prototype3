using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    // create floats and bools to store time info
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
        //count seconds
        secondsToCovert = Time.realtimeSinceStartup;
        seconds = Mathf.FloorToInt(secondsToCovert);

        // update curret gold each second
        if(timeToAddGold < seconds)
        {
            timeToAddGold = seconds + 1;
            currentGold += 1;
        }

        // update current gold text
        goldCounter.text = "Current Gold: " + (currentGold).ToString();


    }
}
