using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shotForce = 1500f;
    [SerializeField] private float ShotRate = 0.5f;
    private float shotRateTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // int ammo = GameManager.Instance.gunAmmo;
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameManager.Instance.gunAmmo > 0 && Time.time > shotRateTime)
        {
            GameObject newBullet;
            newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

            shotRateTime = Time.time + ShotRate;

            GameManager.Instance.gunAmmo--;
            Destroy(newBullet, 5);
        }
    }
}
