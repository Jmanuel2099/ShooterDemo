using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmonBox : MonoBehaviour
{
    [SerializeField] private int ammo = 10;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getAmmo(){
        return ammo;
    }
}
