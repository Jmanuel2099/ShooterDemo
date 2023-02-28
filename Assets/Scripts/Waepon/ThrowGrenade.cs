using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    [SerializeField] private float throwForce = 500;

    [SerializeField] private GameObject granadePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Throw();
        }
    }

    private void Throw()
    {
        GameObject newGrenade = Instantiate(granadePrefab, transform.position, transform.rotation);

        newGrenade.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);

    }
}
