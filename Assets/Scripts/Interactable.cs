using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //this is the base where Interactable item script will overwrite
    }
    protected virtual void OnHover()
    {
        //this is the base where Interactable item script will overwrite
    }
    public void OnRaycasted()
    {
        OnHover();
    }

}
