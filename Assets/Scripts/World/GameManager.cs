using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   [Header("Commponentes UI")]
    public Text ammoText;
    public Text healthText;
    public int health = 100;
    public int gunAmmo = 10;
    public static GameManager Instance {get; private set;} // Singleton patern

    private void Awake()
    {
        Instance = this;
    }

    private void Update() 
    {
        ammoText.text = gunAmmo.ToString();

        healthText.text = health.ToString();
        
    }
}
