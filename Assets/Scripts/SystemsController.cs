using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsController : MonoBehaviour
{
    public GameObject part;
    public GameObject tool;
    public bool isBroken;

    //100 is full resistance, 0 is none
    [SerializeField] int resistance;

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
            this.isBroken = true;
            Debug.Log(gameObject.name + " is broken. Bring a " + tool.name + " and a " + part.name + " to fix it.");
        }
    }

    public string Fix(GameObject[] inventory) { 
        if(!Array.Exists(inventory, item => item == this.part) && !Array.Exists(inventory, item => item == this.tool)) { return "You need a different part and tool to fix this system."; }
        if(!Array.Exists(inventory, item => item == this.part)) { return "You need a different part to fix this system."; }
        if(!Array.Exists(inventory, item => item == this.tool)) { return "You need a different tool to fix this system."; }
        this.isBroken = false;
        return "You have fixed this system.";

    }

}
