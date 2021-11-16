using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    //pravim go Transform zashtoto samo transforma mu ni trqbva inache mojem da go vuvedem kato GameObject
    private Transform bulletSpawnPoint;

    private float secondsSinceLast = 0;
    public float fireRate = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnPoint = GameObject.FindGameObjectWithTag("BulletSpawnPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {

        secondsSinceLast += Time.deltaTime;
        if (Input.GetAxis("Fire1")>0 && secondsSinceLast>fireRate)
        {
            //susdavame obekt korshuma s pozicia i rotacia
          GameObject spawnedBullet=
            Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            secondsSinceLast = 0;
            Destroy(spawnedBullet,2f);
        }

       

    }
}
