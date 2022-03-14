using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 2.5f; //Sensitivity of mouse input
    public float drag = 1.5f; //Continued mouse movement after input stops

    private Transform character; //This references character transform
    private Vector2 mouseDirection; //This stores cursor coordinates
    private Vector2 smoothing; //Smoothed cursor movement value
    private Vector2 result; //Resulting cursor position

    private void Awake()
    {
        character = transform.parent; //Get reference to parent's transform
    }

    // Update is called once per frame
    void Update()
    {
        mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X") * sensitivity,
            Input.GetAxisRaw("Mouse Y") * sensitivity); //Calculate mouse dir
        smoothing = Vector2.Lerp(smoothing, mouseDirection, 1 / drag); //Calculate smoothing
        result += smoothing; //Add smoothing to result
        result.y = Mathf.Clamp(result.y, -80, 80); // Clamps y angle

        transform.localRotation = Quaternion.AngleAxis(-result.y, Vector3.right); //Apply x axis rotation
        character.rotation = Quaternion.AngleAxis(result.x, character.up);// Apply y rotation to character
    }
}
