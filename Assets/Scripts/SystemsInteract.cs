using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsInteract : MonoBehaviour, Interactable
{
    public bool grabbable { get { return grabbable; } set { return; } }
    public bool Equipped { get { return Equipped; } set { return; }}

    private SystemsController sysController;
    private InventoryManager invManager;
    public void Awake()
    {
        this.sysController = GetComponent<SystemsController>();
        this.invManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        Equipped = false;
        grabbable = false;
    }

    public void Interact()
    {
        if (this.sysController.isBroken){Debug.Log(this.sysController.Fix(invManager.GetInventory()));}
        else { Debug.Log("This system is not broken"); }
    }

    public void PlayerFocus()
    {
        Debug.Log("Focus");
    }

    public void PlayerUnfocus()
    {
        Debug.Log("Unfocus");
    }
}
