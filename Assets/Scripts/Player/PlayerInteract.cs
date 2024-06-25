using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    LayerMask mask;
    private PlayerUI playerUI;
    private Interactable interactable;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                hitInfo.collider.GetComponent<Interactable>().onRaycasted();
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);//get info from objects that collided with the ray, in this case promptMessage from Interactable 
            }
        }
        
    }
}
