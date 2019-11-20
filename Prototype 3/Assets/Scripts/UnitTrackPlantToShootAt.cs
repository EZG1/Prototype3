using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTrackPlantToShootAt : MonoBehaviour
{
    float aimSpeed = 100;
    public GameObject targetPlant;
    Quaternion lookAtRotation;

    public bool foundTarget = false;

    //public GameObject bullet;
    float timeToShoot = 0f;
    float timeBetweenShots = 0.5f;

    float bulletSpeed = 1000f;

    public Transform endOfGun;
    public Rigidbody unitGunRigiddody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(targetPlant == null)
        {
            foundTarget = false;
        }


        if (foundTarget == true)
        {
            lookAtRotation = Quaternion.LookRotation(targetPlant.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, aimSpeed * Time.deltaTime);

            if (timeToShoot < this.gameObject.GetComponent<UnitLookForTarget>().secondsToCovert)
            {
                timeToShoot = this.gameObject.GetComponent<UnitLookForTarget>().secondsToCovert + timeBetweenShots;

                Rigidbody newBullet;
                newBullet = Instantiate(unitGunRigiddody, endOfGun.position, endOfGun.rotation) as Rigidbody;
                newBullet.AddForce(endOfGun.forward * bulletSpeed);
            }
        }
    }
}
