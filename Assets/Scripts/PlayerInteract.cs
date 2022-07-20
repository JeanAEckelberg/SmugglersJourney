using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] KeyCode interactKey;
    [SerializeField] Camera playerCam;
    private Vector3 _interactionRay = new Vector3(.5f, .5f, 0);
    [SerializeField] float interactDistance;
    private IInteractable _currentInteract;
    private GameObject _lastInteract;
    private bool _isFocused;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && _lastInteract!=null) _lastInteract.GetComponent<IInteractable>().Interact();
    }

    void FixedUpdate()
    {
        if (!Physics.Raycast(playerCam.ViewportPointToRay(_interactionRay), out RaycastHit hit, interactDistance))
        {
            CleanUp();
            return;
        }

        if (!hit.collider.gameObject.Equals(_lastInteract)) CleanUp();

        if (!hit.collider.TryGetComponent(out _currentInteract)) return;

        _lastInteract = hit.collider.gameObject;

        if (_isFocused) return;
        
        _currentInteract.PlayerFocus();    
        _isFocused = true;
    }

    public void CleanUp()
    {
        _isFocused = false;
        if (_lastInteract==null) return;
        _lastInteract.GetComponent<IInteractable>().PlayerUnfocus();
        _lastInteract = null;
    }
    
}
