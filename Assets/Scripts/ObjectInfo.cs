using UnityEngine;
using UnityEngine.UI;

public class ObjectInfo : MonoBehaviour, IInteractable
{
    public bool Grabbable { get; set; }
    private bool _equipped;

    public string itemName = "";
    private Text _interactText;
    
    private ImprovedInventoryManager _inventory;
    public bool Equipped
    {
        get => _equipped;
        set
        {
            _equipped = value;
            gameObject.GetComponent<Rigidbody>().isKinematic = value;
        }
    }

    private void Awake()
    {
        Grabbable = true;
        _equipped = false;
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<ImprovedInventoryManager>();
        _interactText = GameObject.Find("InteractText").GetComponent<Text>();
    }

    public void PlayerFocus()
    {
        _interactText.text = itemName;
    }

    public void PlayerUnfocus()
    {
        _interactText.text = "";
    }

    public void Interact()
    {
        _inventory.PickUp(gameObject);
    }
}

public enum ItemType
{
    None,
    Wrench,
    Hammer,
    Screwdriver,
    WireStripper,
    PowerCoil,
    WiringHarness,
    NavComputer,
    MetalSheet,
    Pipe
}