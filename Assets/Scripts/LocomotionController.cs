using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    [SerializeField] private XRController leftRayThrower;
    [SerializeField] private XRController rightRayTeleport;

    [SerializeField] private InputHelpers.Button teleportActivationButton;
    [SerializeField] private InputHelpers.Button throwActivationButton;
    [SerializeField] Hands HandScript;

    [SerializeField] private float activationPress = 0.1f;
    private bool canThrow;
    private bool isAiming;

    private void Update()
    {
        
        if (rightRayTeleport)
        {
            rightRayTeleport.gameObject.SetActive(CheckIfActivated(rightRayTeleport, teleportActivationButton));
        }
        if (leftRayThrower)
        {
            leftRayThrower.gameObject.SetActive(CheckIfActivated(leftRayThrower, throwActivationButton));
            if (CheckIfActivated(leftRayThrower, throwActivationButton)) 
            {
                isAiming = true;
            }
            else
            {
                if (isAiming)
                {
                    HandScript.Throw();
                    isAiming = false;
                }
            }

        }


    }

    public bool CheckIfActivated(XRController controller, InputHelpers.Button Button)
    {
        InputHelpers.IsPressed(controller.inputDevice, Button, out bool isActive, activationPress);
        return isActive;
    }
}
