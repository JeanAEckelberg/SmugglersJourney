using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    public bool grabbable { get; set; }
    public bool Equipped { get; set; }

    public abstract void Interact();
    public abstract void PlayerUnfocus();
    public abstract void PlayerFocus();
}
