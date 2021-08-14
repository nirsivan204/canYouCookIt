using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class handle : XRGrabInteractable
{
    public Transform handlePlace;
    public Rigidbody handleRB;
    protected override void Detach()
    {
        transform.position = handlePlace.position;
        transform.rotation = handlePlace.rotation;
        transform.localScale = Vector3.one;

        handleRB.velocity = Vector3.ProjectOnPlane(handleRB.velocity, Vector3.up);
        //handleRB.angularVelocity = Vector3.zero;

    }

    private void Update()
    {
        if (isSelected && Vector3.Distance(handlePlace.position, transform.position) > 0.4f)
        {
            Detach();
            ForceDeselect();
        }
    }


    private void ForceDeselect()
    {
        base.OnSelectExiting(new SelectExitEventArgs());
    }
}
