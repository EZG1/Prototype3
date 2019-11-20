using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FindUnitTarget : MonoBehaviour
{
    public GameObject[] plantsToKill;
    public int howManyTargetsThereAre;
    public Text plantsRemaining;
    public Text baseHPText;

    bool waveWon = false;
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
        baseHPText.text = "Base HP Remaining: " + baseHP;
        winWaveCondition();
        FindPlantsToKill();
        plantsRemaining.text = "Plants Remaining in wave: " + plantsToKill.Length;
        // for( int i = 0; i < plantsToKill.Length; i++)
        //print(plantsToKill.Length);
    }

    public void FindPlantsToKill()
    {
        plantsToKill = GameObject.FindGameObjectsWithTag("Plant");
    }

    public void winWaveCondition()
    {
        if (plantsToKill.Length == 0 & waveWon == false)
        {
            waveWon = true;
            print("you have cleared the wave");
        }
    }

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
