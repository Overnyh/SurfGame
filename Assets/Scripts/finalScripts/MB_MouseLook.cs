using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MB_MouseLook : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] public float sensitivity = 500;

    private float _xRotation;
    private float _yRotation;

    private float mouseX = 0, mouseY = 0;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        //player.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
        //transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            mouseX = Input.GetTouch(0).deltaPosition.x;
            mouseY = Input.GetTouch(0).deltaPosition.y;
        }

        _yRotation += mouseX;
        _xRotation -= mouseY;

        player.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);

        //_xRotation = Mathf.Clamp(_xRotation, -90, 90);
    }
}
