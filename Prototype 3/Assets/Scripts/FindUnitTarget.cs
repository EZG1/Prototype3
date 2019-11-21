using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FindUnitTarget : MonoBehaviour
{
    //list our plants to target
    public GameObject[] plantsToKill;
    public int howManyTargetsThereAre;

    //ui text for base HP and plants remaining in scene
    public Text plantsRemaining;
    public Text baseHPText;

    //is the wave over?
    bool waveWon = false;
    //PLayer life
    int baseHP = 5;

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
        //update our text live to state base HP & plants
        baseHPText.text = "Base HP Remaining: " + baseHP;
        winWaveCondition();
        FindPlantsToKill();
        plantsRemaining.text = "Plants Remaining in wave: " + plantsToKill.Length;
        // for( int i = 0; i < plantsToKill.Length; i++)
        //print(plantsToKill.Length);
    }

    //check plants in scene
    public void FindPlantsToKill()
    {
        plantsToKill = GameObject.FindGameObjectsWithTag("Plant");
    }

    //check if game is won 
    public void winWaveCondition()
    {
        if (plantsToKill.Length == 0 & waveWon == false)
        {
            waveWon = true;
            print("you have cleared the wave");
        }
    }

    // Call to update base HP
    public void baseDamaged()
    {
        if (baseHP != 0)
        {
            baseHP -= 1;
            
            if (baseHP == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

}
