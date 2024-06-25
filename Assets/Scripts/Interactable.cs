using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    private void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //this is the base where Interactable item script will overwrite
    }
    protected virtual void onHover()
    {
        //this is the base where Interactable item script will overwrite
    }
    public void onRaycasted()
    {
        onHover();
    }

}
