using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public void Awake()
    {
        gameObject.layer = 10;
    }
    public abstract void Interact();
    public abstract void PlayerUnfocus();
    public abstract void PlayerFocus();
}
