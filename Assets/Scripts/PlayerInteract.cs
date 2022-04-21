using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] KeyCode interactKey;
    [SerializeField] Camera playerCam;
    [SerializeField] Vector3 interactionRay;
    [SerializeField] float interactDistance;
    [SerializeField] LayerMask interactLayer;
    private Interactable currentInteract;

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(interactKey) && currentInteract !=null && Physics.Raycast(playerCam.ViewportPointToRay(interactionRay), out RaycastHit hit, interactDistance, interactLayer)){
            currentInteract.Interact();
        }
    }

    public void CheckInteraction()
    {
        if(Physics.Raycast(playerCam.ViewportPointToRay(interactionRay), out RaycastHit hit, interactDistance)){
            if(hit.collider.gameObject.layer == 10 && (currentInteract == null || hit.collider.gameObject.GetInstanceID() != currentInteract.GetInstanceID()))
            {
                hit.collider.TryGetComponent(out currentInteract);

                if (currentInteract)
                {
                    currentInteract.PlayerFocus();
                }
            }
        }
        else if (currentInteract)
        {
            currentInteract.PlayerUnfocus();
            currentInteract = null;
        }
    }
}
