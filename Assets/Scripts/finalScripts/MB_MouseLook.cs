using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class MB_MouseLook : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] public float sensitivity = 500;

    private float _xRotation;
    private float _yRotation;

    private float mouseX = 0, mouseY = 0;

    public bool pressed = false;

    private void FixedUpdate()
    {
        /*
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).position.x > 680f)
        {
            mouseX = Input.GetTouch(0).deltaPosition.x * sensitivity /10 * Time.fixedDeltaTime;
            mouseY = Input.GetTouch(0).deltaPosition.y * sensitivity /10 * Time.fixedDeltaTime;

            _yRotation += mouseX;
            _xRotation -= mouseY;

            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            player.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        }
        else if (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Moved && Input.GetTouch(1).position.x > 680f)
        {
            mouseX = Input.GetTouch(1).deltaPosition.x * sensitivity / 10 * Time.fixedDeltaTime;
            mouseY = Input.GetTouch(1).deltaPosition.y * sensitivity / 10 * Time.fixedDeltaTime;

            _yRotation += mouseX;
            _xRotation -= mouseY;

            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            player.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        }
        */
    }
}
