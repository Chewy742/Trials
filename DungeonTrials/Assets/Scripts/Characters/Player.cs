using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    public int coins = 0;

    private bool haslevelKey = false;
    private bool hasGateKey = false;

    public Slider healthbar;


    /*
     * 
     * Start and Scene Management Functions
     * 
     */
    public void Start()
    {
        health = GlobalControl.instance.health;
        Debug.Log(health);
        coins = GlobalControl.instance.coins;
        healthbar.value = calculateHealthPer();
    }

    public void SavePlayerData()
    {
        GlobalControl.instance.health = health;
        GlobalControl.instance.coins = coins;
    }


    /*
     * 
     * Health-related functions
     * 
     */

    public void takeDamage(float damage)
    {
        health -= damage;
        healthbar.value = calculateHealthPer();

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private float calculateHealthPer()
    {
        return health / maxHealth;
    }

    /*
     * 
     * Collectable functions
     * 
     */

    public void addCollectables(string name){

        if (name == "Coin"){
            addCoin();
        }
        if(name == "LevelKey")
        {
            addLevelKey();
        }
        if(name == "SmallHealthPotion")
        {
            addSmallHP();
        }
        if(name == "GateKey")
        {
            addGateKey();
        }

    }

    private void addGateKey()
    {
        hasGateKey = true;
    }

    private void addSmallHP()
    {
        health += 20;
        if(health > 100)
        {
            health = 100;
        }
        healthbar.value = calculateHealthPer();
    }

   
    private void addLevelKey()
    {
        haslevelKey = true;
        Debug.Log(haslevelKey);
    }

    private void addCoin(){
        coins++;
        Debug.Log(coins);
    }


    /*
     * 
     * Methods for accessing variables    
     * 
     */    

    public bool getLevelKeyStatus()
    {
        return haslevelKey;
    }

    public bool getGateKeyStatus()
    {
        return hasGateKey;
    }

    public int getCoinNumber()
    {
        return coins;
    }

}
