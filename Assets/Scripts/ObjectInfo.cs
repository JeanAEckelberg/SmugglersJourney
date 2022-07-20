using UnityEngine;


public class ObjectInfo : MonoBehaviour, IInteractable
{
    public bool Grabbable { get; set; }
    private bool _equipped;
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
    }

    public void PlayerFocus()
    {
        
    }

    public void PlayerUnfocus()
    {
        
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