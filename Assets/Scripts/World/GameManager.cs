using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void LoseHealth(int healthToReduce)
    {
        health -= healthToReduce;
        if (health <= 0)
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
