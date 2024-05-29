using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponFollowLook : MonoBehaviour
{
    // Variables
    public GameObject playerWeapon;
    public float zRotation = 0f;

    public float xSensitivity = 50f;
    public float ySensitivity = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    public void ProcessFollowLookWithWeapon(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Calculate weapon rotation for looking up and down
        zRotation -= (mouseY * Time.deltaTime * ySensitivity);
        zRotation = Mathf.Clamp(zRotation, -80f, 80f);
        // Applying to the weapon transform
        playerWeapon.transform.localRotation = Quaternion.Euler(0, 90, zRotation);

        /*// Calculate weapon rotation for looking left and right
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime * xSensitivity);*/
    }
}
