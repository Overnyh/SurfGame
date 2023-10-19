using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchCameraMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isDragging = false;
    private Vector2 dragStartPosition;
    [SerializeField] private Transform cameraToRotate = null;
    [SerializeField] private GameObject player = null;
    public float sensitivity = 100f;

    private float _xRotation;
    private float _yRotation;

    private float mouseX = 0, mouseY = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        // ����� �������� ������
        isDragging = true;
        dragStartPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // ����� �������
        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ����� ��������� ������ ������
        if (isDragging && cameraToRotate != null)
        {
            Vector2 currentPosition = eventData.position;
            Vector2 delta = currentPosition - dragStartPosition;

            // ��������� ���� �������� �� ������ �������� ������
            float rotationAngle = delta.x * sensitivity;

            // ��������� �������� � ������
            //cameraToRotate.Rotate(Vector3.up, rotationAngle);
            mouseX = delta.x * sensitivity * Time.fixedDeltaTime / 10;
            mouseY = delta.y * sensitivity * Time.fixedDeltaTime / 10;

            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            player.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
            cameraToRotate.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);

            // ��������� ������� ������ �����������
            dragStartPosition = currentPosition;
        }
    }
}
