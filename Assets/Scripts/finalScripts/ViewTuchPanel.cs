using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ViewTuchPanel : MonoBehaviour
{
    private Vector2 startPosition;
    private bool isDragging = false;
    public float rotationSpeed = 2.0f; // �������� �������� ������

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    //Debug.Log(touchPosition);
                    if (touchPosition.x > 1080f)
                    {
                        isDragging = true;
                        Debug.Log(2);
                        startPosition = touchPosition;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging && touchPosition.x > 1080f)
                    {
                        // ��������� �������� ������
                        Vector2 delta = touchPosition - startPosition;
                        float rotationX = delta.y * rotationSpeed * Time.deltaTime;
                        float rotationY = -delta.x * rotationSpeed * Time.deltaTime;

                        Debug.Log(rotationX);

                        // ���������� �������� ������
                        //Camera.main.transform.Rotate(Vector3.right, rotationX);
                        //Camera.main.transform.Rotate(Vector3.up, rotationY);

                        startPosition = touchPosition;
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    break;
            }
        }
    }

    // ��������, ��������� �� ������� ������ ������� ������
    private bool IsTouchInsidePanel(Vector2 touchPosition)
    {
        // ����� ��� ����� ���������� ������� ������� ������ � ���������, ��������� �� ������� ������ ���
        // ��������, ����� ������������ RectTransform.rect.Contains
        return GetComponent<RectTransform>().rect.Contains(touchPosition);
    }
}
