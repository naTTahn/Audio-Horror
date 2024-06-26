using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public MeshRenderer meshRenderer;
    //public MeshRenderer meshRenderer;
    public Material highlightMaterial;
    public Material transparentMaterial;
    private bool doorOpen;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    protected override void Interact()
    {
        base.Interact();
        //Debug.Log("Interact with " + gameObject.name);
        doorOpen = door.GetComponent<Animator>().GetBool("isOpen");
        doorOpen = !doorOpen;
        Debug.Log("Door is " + doorOpen);
        door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
    }
    private void FixedUpdate()
    {
        hideHighlight();
    }
    protected override void onHover()
    {
        base.onHover();
        showHighlight();
    }
    void hideHighlight()
    {
        Material[] materials = meshRenderer.materials;
        materials[1] = transparentMaterial;
        meshRenderer.materials = materials;
    }
    void showHighlight()
    {
        Material[] materials = meshRenderer.materials;
        materials[1] = highlightMaterial;
        meshRenderer.materials = materials;
    }
}
