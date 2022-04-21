using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsInteract : Interactable
{
    public override void Interact()
    {
        Debug.Log("Interact");
    }

    public override void PlayerFocus()
    {
        Debug.Log("Focus");
    }

    public override void PlayerUnfocus()
    {
        Debug.Log("Unfocus");
    }
}
