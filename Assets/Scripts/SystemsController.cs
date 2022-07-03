using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SystemsController : MonoBehaviour
{
    public GameObject Part;
    public GameObject Tool;
    public bool isBroken;
    public float failTime = 3f;
    private float timeLeft;
    //100 is full resistance, 0 is none
    [SerializeField] int resistance;
    private bool gameOver = false;

    public void Break()
    {
        int breakChance = UnityEngine.Random.Range(0, 100);

        //If system resists, lower its durability by 5%
        if (resistance > breakChance) {
            resistance = Mathf.CeilToInt(resistance * .95f);
            return;
        }
        else
        {
            this.timeLeft = failTime;
            this.isBroken = true;
            Debug.Log(gameObject.name + " is broken. Bring a " + Tool.name + " and a " + Part.name + " to fix it.");
        }
    }

    private void Update()
    {
        if (isBroken)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                this.isBroken = false;
                this.gameOver = true;
                Debug.Log("Game Over");
            }
        }
    }

    public bool isGameOver() { return this.gameOver; }    

    public string Fix(GameObject[] inventory) {
        if(!Array.Exists(inventory, item => item.name.Equals(this.Part.name+"(Clone)")) && !Array.Exists(inventory, item => item.name.Equals(this.Tool.name+"(Clone)"))) { return "You need a different part and tool to fix this system."; }
        if(!Array.Exists(inventory, item => item.name.Equals(this.Part.name+"(Clone)"))) { return "You need a different part to fix this system."; }
        if(!Array.Exists(inventory, item => item.name.Equals(this.Tool.name+"(Clone)"))) { return "You need a different tool to fix this system."; }
        this.isBroken = false;
        this.timeLeft = failTime;
        InventoryManager playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        playerInv.ConsumeInventory();
        return "You have fixed this system.";

    }

}
