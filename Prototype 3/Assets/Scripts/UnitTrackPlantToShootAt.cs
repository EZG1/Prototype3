using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTrackPlantToShootAt : MonoBehaviour
{
    //sound
    public AudioClip gunSound;

    float aimSpeed = 100;

    //target to look at
    public GameObject targetPlant;
    Quaternion lookAtRotation;

    //do we have a target? bool
    public bool foundTarget = false;

    //bullet variables;
    float timeToShoot = 0f;
    float timeBetweenShots = 0.5f;
    float bulletSpeed = 1000f;

    //where to spawn bullets
    public Transform endOfGun;
    //store the bullet we are creating
    public Rigidbody unitGunRigiddody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if we have a target
        if(targetPlant == null)
        {
            foundTarget = false;
        }


        //if we have a target rotate to look and plant and start shooting
        if (foundTarget == true)
        {
            lookAtRotation = Quaternion.LookRotation(targetPlant.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, aimSpeed * Time.deltaTime);

            if (timeToShoot < this.gameObject.GetComponent<UnitLookForTarget>().secondsToCovert)
            {
                timeToShoot = this.gameObject.GetComponent<UnitLookForTarget>().secondsToCovert + timeBetweenShots;

                //call and play sound to audio source
                GetComponent<AudioSource>().PlayOneShot(gunSound);

                //shoot bullet
                Rigidbody newBullet;
                newBullet = Instantiate(unitGunRigiddody, endOfGun.position, endOfGun.rotation) as Rigidbody;
                newBullet.AddForce(endOfGun.forward * bulletSpeed);
            }
        }
    }
}
