using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBM : MonoBehaviour
{
    [SerializeField] private Transform characterController;
    public void DoHop()
    {
        characterController.GetComponent<MB_PlayerMovement>().Hop();
    }
    public void DoF()
    {
        characterController.GetComponent<MB_PlayerMovement>().F();
    }
}
