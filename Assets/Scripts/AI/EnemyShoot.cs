using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform spawnBulletPoint;
    [SerializeField] private float bulletVelocity = 100;
    private Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        //find the object that has the PlayerMovement script 
        // playerPosition = FindObjectOfType<PlayerMovement>().transform;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        // Invoke("ShootPlaye", 3);
        ShootPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShootPlayer()
    {
        Vector3 playerDirection = playerPosition.position - transform.position;

        GameObject newBullet;
        newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);
        
        Invoke("ShootPlayer", 3);
    }
}
