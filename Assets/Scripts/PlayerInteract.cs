using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] KeyCode interactKey;
    [SerializeField] Camera playerCam;
    private Vector3 interactionRay = new Vector3(.5f, .5f, 0);
    [SerializeField] float interactDistance;
    private Interactable currentInteract;
    private GameObject lastInteract;
    private bool isFocused;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && lastInteract!=null) lastInteract.GetComponent<Interactable>().Interact();
    }

    void FixedUpdate()
    {
        if (!Physics.Raycast(playerCam.ViewportPointToRay(interactionRay), out RaycastHit hit, interactDistance))
        {
            CleanUp();
            return;
        }

        if (!hit.collider.gameObject.Equals(lastInteract)) CleanUp();

        if (!hit.collider.TryGetComponent(out currentInteract)) return;

        lastInteract = hit.collider.gameObject;

        if (isFocused) return;
        
        currentInteract.PlayerFocus();    
        isFocused = true;
    }

    public void CleanUp()
    {
        isFocused = false;
        if (lastInteract==null) return;
        lastInteract.GetComponent<Interactable>().PlayerUnfocus();
        lastInteract = null;
    }
    
}
