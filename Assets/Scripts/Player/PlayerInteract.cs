using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Variables
    public Camera playerCamera;
    public float distance = 3.0f;
    public LayerMask mask;
    private PlayerUI playerUI;
    //private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponent<PlayerLook>().playerCamera;
        playerUI = GetComponent<PlayerUI>();
        //inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // variable to store the collision information.
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            /*if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }*/
        }
    }
}
