using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    //time to wait before bullet distruction
    float bulletExipiryTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //destroy bullet after creation
        Destroy(this.gameObject, bulletExipiryTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to call on colision with plant 
    public void BulletHitPlant()
    {
        Destroy(this.gameObject);
    }
}
