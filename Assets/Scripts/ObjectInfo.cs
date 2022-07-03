using UnityEngine;


public class ObjectInfo : MonoBehaviour
{
    public bool grabbable = true;
    private bool _equipped;
    public bool Equipped
    {
        get
        {
            return _equipped;
        }
        set
        {
            _equipped = value;
            gameObject.GetComponent<Rigidbody>().isKinematic = value;
        }
    }

    private void Awake()
    {
        grabbable = true;
        _equipped = false;
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