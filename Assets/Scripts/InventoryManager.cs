using System;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject _left, _right;
    private GameObject _mainCam;
    private GameObject _toPickup;
    private RaycastHit hit;
    
    [SerializeField] private Vector3 leftPosition, leftRotation, rightPosition, rightRotation;
    
    [SerializeField] float pickupRange = 5f;
    
    private Vector3 _handPosition, _handRotation;
    private GameObject _hand;
    
    private void Start()
    {
        _mainCam = GameObject.Find("Main Camera");
    }

    void PickUpLeft()
    {
        _handPosition = leftPosition;
        _handRotation = leftRotation;
        _hand = _left;

        PickUp();
        _left = _toPickup;
    }
    void PickUpRight()
    {
        _handPosition = rightPosition;
        _handRotation = rightRotation;
        _hand = _right;
        
        PickUp();
        _right = _toPickup;
    }

    private void PickUp()
    {
        if(!Physics.Raycast(
               Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), 
               out hit, pickupRange
               )) return;
        
        if (!hit.collider.gameObject.TryGetComponent(out ObjectInfo info)) return;
        
        if(!info.grabbable) return;
        
        Drop();
        _toPickup = hit.collider.gameObject;
        _toPickup.transform.SetPositionAndRotation(_handPosition, Quaternion.Euler(_handRotation));
        _toPickup.transform.SetParent(_mainCam.transform,false);
        info.Equipped = true;
    }

    void Drop()
    {
        if (_hand == null) return;
            Destroy(_hand);
            _hand= null;
    }
}
