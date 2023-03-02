using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private Transform startPostion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.CompareTag("GunAmmon"))
        {
            GameManager.Instance.gunAmmo += collider.gameObject.GetComponent<AmmonBox>().getAmmo();
            Destroy(collider.gameObject);
        }
        
        if (collider.gameObject.CompareTag("DeathFloor"))
        {
            GameManager.Instance.LoseHealth(50);
            
            GetComponent<CharacterController>().enabled = false;
            this.gameObject.transform.position = startPostion.position;
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
