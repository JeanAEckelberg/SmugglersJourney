using System.Net.NetworkInformation;
using UnityEngine;

public class ImprovedInventoryManager : MonoBehaviour
{
    private GameObject _mainCam;
    private InventoryDisplayController _mainDisplay;
    private GameObject[] _inventory = new GameObject[10];
    private int _size;
    private int _index;
    public int Index => _index;

    [SerializeField] private Vector3 leftPosition, leftRotation, rightPosition, rightRotation;

    private Vector3 _handPosition, _handRotation;
    private GameObject _hand;

    private float _scroll;
    
    private void Start()
    {
        _mainCam = GameObject.Find("Main Camera");
        _mainDisplay = GameObject.Find("InventoryDisplay").GetComponent<InventoryDisplayController>();
    }

    private void Update()
    {
        _scroll = Input.GetAxis("Mouse ScrollWheel");
        
        if (_scroll > 0)
        {
            _index = (_index + 1) % _inventory.Length;
            Swap();
        }
        else if (_scroll < 0)
        {
            _index = (_index - 1) % _inventory.Length;
            if (_index < 0) _index = _inventory.Length + _index;
            Swap();
        }

    }

    public void PickUp(GameObject toPickup)
    {
        if(_size >= 10) Drop();
        
        for (int i = _index; i < _index + _inventory.Length; i++)
        {
            if(_inventory[i% _inventory.Length] != null) continue;
            _index = i% _inventory.Length;
            _inventory[_index] = toPickup;
            Swap();
            break;
        }

        toPickup.transform.SetPositionAndRotation(rightPosition, Quaternion.Euler(rightRotation));
        toPickup.transform.SetParent(_mainCam.transform,false);
        toPickup.GetComponent<ObjectInfo>().Equipped = true;
        _size++;
    }

    void Drop()
    {
        if (_hand == null) return;
        Destroy(_hand);
        _hand= null;
        _inventory[_index] = null;
        _size--;
    }

    public GameObject[] GetInventory()
    {
        GameObject[] temp = new GameObject[_inventory.Length];
        for( int i = 0; i < _inventory.Length; i++)
        {
            temp[i] = _inventory[i];
        }
        return temp;
    }

    public void ConsumeInventory()
    {
      for(int i = 0; i < _inventory.Length; i++)
      {
          _inventory[i] = null;
          Destroy(_hand);
          _hand = null;
      }

      _size = 0;
    }

    public void ConsumeInventorySlot(int slot)
    {
        if(slot < 0 || slot >= _inventory.Length) return;
        if (slot == _index)
        {
            Destroy(_hand);
            _hand = null;
        }
        _inventory[slot] = null;

        _size--;
    }

    private void Swap()
    {
        _mainDisplay.StartCoroutine("UpdateDisplay", _index);
        if (_hand != null) _hand.GetComponent<MeshRenderer>().enabled = false;
        _hand = _inventory[_index];
        if(_hand != null) _hand.GetComponent<MeshRenderer>().enabled = true;
    }
}
