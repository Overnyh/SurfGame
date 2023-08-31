using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterflyDefault : MonoBehaviour
{
    [SerializeField] Animator knife;
    void Update()
    {
        if (Input.GetKey(KeyCode.F)) DoF();
    }
    public void DoF()
    {
        if (knife.layerCount == 1)
        {
            knife.Play("KnifeAnim", 0);
        }
        else if (knife.layerCount == 2)
        {
            knife.Play("KnifeAnim", 0);
            knife.Play("KnifeAnim", 1);
        }
    }
}
