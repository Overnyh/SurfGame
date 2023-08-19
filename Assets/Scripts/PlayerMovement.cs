using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public static float Speed = 12f;
    private float speed = Speed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [SerializeField] TextMeshProUGUI speedHud;

    public Transform graundCheck;
    public float graundDistance = 0.4f;
    public float slopeForceRayLength = 1.5f;
    public float slopeForce = 5f;
    public LayerMask graundMask;
    public LayerMask surfMask;

    Vector3 velocity, oldPosition, currentPosition;
    bool isGraunded, isSurf;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        oldPosition = transform.position;
        controller.Move(move * speed * Time.deltaTime);
        currentPosition = transform.position;

        isGraunded = Physics.CheckSphere(graundCheck.position, graundDistance, graundMask);
        isSurf = Physics.CheckSphere(graundCheck.position, graundDistance, surfMask);

        if ((isGraunded || isSurf) && velocity.y < 0)
        {
            velocity.y = -10f;
            if (oldPosition == currentPosition)
            {
                speed = Speed;
            }
        }

        if ((x != 0 || z != 0) && OnSlope())
        {
            controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (isGraunded || isSurf)) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (!isGraunded && !isSurf)
        {
            if (oldPosition != currentPosition)
            {
                if (speed < 32f)
                {
                    speed += 0.0200000f;
                }
                else 
                {
                    speed = 32f;
                }
            }
            else
            {
                speed = Speed;
            }
        }
        speedHud.text = "Speed: " + speed;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
    private bool OnSlope() 
    {
        if (!isGraunded && !isSurf) return false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 * slopeForceRayLength))
        {
            if (hit.normal != Vector3.up) return true;
        }
        return false;
    }
}
