using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Camera cam;
    [SerializeField] private float offset;

    private Vector3 movement;

    void Update()
    {
        Movement();

        RotateTowardsMouse();
    }

    void Movement()
    {
        movement.z = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        movement.x = -Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        characterController.Move(new Vector3(movement.x, 0, movement.z));
    }


    void RotateTowardsMouse()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = cam.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)cam.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle + offset, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
