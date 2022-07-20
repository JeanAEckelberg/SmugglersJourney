using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemsInteract : MonoBehaviour, IInteractable
{
    public bool Grabbable { get => Grabbable;
        set { return; } }
    public bool Equipped { get => Equipped;
        set { return; }}

    private Text _interactText;
    private SystemsController _sysController;
    private ImprovedInventoryManager _invManager;

    public void Awake()
    {
        this._interactText = GameObject.Find("InteractText").GetComponent<Text>();
        this._sysController = GetComponent<SystemsController>();
        this._invManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ImprovedInventoryManager>();
        Equipped = false;
        Grabbable = false;
    }

    public void Interact(){if (_sysController.isBroken){ _interactText.text = _sysController.Fix(_invManager.GetInventory());}}

    public void PlayerFocus()
    {
        if (_sysController.isBroken) { _interactText.text = "Press E to attempt to fix the " + gameObject.name; }
        else { _interactText.text = "The " + gameObject.name + " seems to be working properly"; }
    }

    public void PlayerUnfocus(){_interactText.text = "";}
}
