using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private float delay = 3;
    private float  countDown;
    [SerializeField] private float radius = 5;
    [SerializeField] private float explotionForce = 70;
    private bool exploted = false;
    [SerializeField] private GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown < 0 && exploted == false)
        {
            Exploted();
        }
    }

    private void Exploted()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var rangeObjects in colliders)
        {
            Rigidbody rb = rangeObjects.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explotionForce * 10, transform.position, radius);
            }
        }
        Destroy(gameObject);
        exploted = true;
    }
}
