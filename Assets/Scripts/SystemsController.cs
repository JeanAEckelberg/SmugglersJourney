using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SystemsController : MonoBehaviour
{
    public GameObject Part;
    public GameObject Tool;
    public bool isBroken;
    public float failTime = 3f;
    private float timeLeft;
    //100 is full resistance, 0 is none
    [SerializeField] int resistance;
    private Text systemsText;
    private Text timerText;

    private void Start(){ 
        systemsText = GameObject.Find("SystemsText").GetComponent<Text>();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
    }

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
            systemsText.text = gameObject.name + " is broken. Bring a " + Tool.name.ToLower() + " and a " + Part.name.ToLower() + " to fix it.";
        }
    }

    private void Update()
    {
        if (isBroken)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerText.text = "Time Left:\n" + Mathf.FloorToInt(timeLeft % 60);
            }
            else
            {
                this.isBroken = false;
                timerText.text = "";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public string Fix(GameObject[] inventory) {
        //if (inventory[0] == null || inventory[1] == null) { return "You need to grab a part and tool to fix this system"; }
        if(!Array.Exists(inventory, item => item != null && item.name.Equals(this.Part.name+"(Clone)")) 
           && !Array.Exists(inventory, item => item != null && item.name.Equals(this.Tool.name+"(Clone)"))) { return "You need a different part and tool to fix this system."; }
        if(!Array.Exists(inventory, item => item != null && item.name.Equals(this.Part.name+"(Clone)"))) { return "You need a different part to fix this system."; }
        if(!Array.Exists(inventory, item => item != null && item.name.Equals(this.Tool.name+"(Clone)"))) { return "You need a different tool to fix this system."; }
        this.isBroken = false;
        this.timeLeft = failTime;
        timerText.text = "";
        systemsText.text = "";
        ImprovedInventoryManager playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<ImprovedInventoryManager>();
        int index1 = Array.FindIndex(inventory, item => item != null && item.name.Equals(Part.name + "(Clone)")),
            index2 = Array.FindIndex(inventory, item => item != null && item.name.Equals(Tool.name + "(Clone)"));
        playerInv.ConsumeInventorySlot(index1);
        playerInv.ConsumeInventorySlot(index2);
        return "You have fixed this system.";

    }

}
