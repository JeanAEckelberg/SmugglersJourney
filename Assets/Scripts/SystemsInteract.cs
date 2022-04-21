using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsInteract : MonoBehaviour, Interactable
{
    public bool grabbable { get { return grabbable; } set { return; } }
    public bool Equipped { get { return Equipped; } set { return; }}

    public void Awake()
    {
        Equipped = false;
        grabbable = false;
    }

    public void Interact()
    {
        Debug.Log("Interact");
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
