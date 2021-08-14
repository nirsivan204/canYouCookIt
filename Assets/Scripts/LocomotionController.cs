using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    [SerializeField] private XRController leftRayTeleport;
    [SerializeField] private XRController rightRayTeleport;
    [SerializeField] private InputHelpers.Button teleportActivationButton;
    [SerializeField] private float activationPress = 0.1f;

    private void Update()
    {
        if (leftRayTeleport)
        {
            leftRayTeleport.gameObject.SetActive(CheckIfActivated(leftRayTeleport));
        }
        
        if (rightRayTeleport)
        {
            rightRayTeleport.gameObject.SetActive(CheckIfActivated(rightRayTeleport));
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActive, activationPress);
        return isActive;
    }
}
