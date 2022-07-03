using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemsInteract : MonoBehaviour, Interactable
{
    public bool grabbable { get { return grabbable; } set { return; } }
    public bool Equipped { get { return Equipped; } set { return; }}

    private Text interactText;
    private SystemsController sysController;
    private InventoryManager invManager;

    public void Awake()
    {
        this.interactText = GameObject.Find("InteractText").GetComponent<Text>();
        this.sysController = GetComponent<SystemsController>();
        this.invManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        Equipped = false;
        grabbable = false;
    }

    public void Interact(){if (this.sysController.isBroken){ this.interactText.text = this.sysController.Fix(invManager.GetInventory());}}

    public void PlayerFocus()
    {
        if (sysController.isBroken) { this.interactText.text = "Press E to attempt to fix the " + gameObject.name.ToLower(); }
        else { this.interactText.text = "The " + gameObject.name.ToLower() + " seems to be working properly"; }
    }

    public void PlayerUnfocus(){this.interactText.text = "";}
}
