using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    float bulletExipiryTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, bulletExipiryTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BulletHitPlant()
    {
        Destroy(this.gameObject);
    }
}
