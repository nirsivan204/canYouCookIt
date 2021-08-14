using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Product : XRGrabInteractable
{
    public GameObject mesh;
    private Rigidbody rb;
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        Container container = GetComponentInParent<Container>();
        if (container)
        {
            container.create();
        }
        mesh.SetActive(true);
        base.OnSelectEntering(args);
    }
}
