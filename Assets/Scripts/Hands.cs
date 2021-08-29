using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hands : MonoBehaviour
{
    private GameObject ItemHolding;
    [SerializeField] XRRayInteractor RI;
    private XRDirectInteractor DI;
    private bool isHoldingPlate;
    private Product thrownProduct;

    // Start is called before the first frame update
    void Start()
    {
        DI = GetComponent<XRDirectInteractor>();
        DI.selectEntered.AddListener(WhatIsHolding);
        DI.selectExited.AddListener(NotHolding);
    }

    public void Throw()
    {
        if (RI & DI & isHoldingPlate)
        {
            Rigidbody rb = ItemHolding.GetComponent<Rigidbody>();
            thrownProduct = ItemHolding.GetComponent<Product>();
            DI.enabled = false;
            rb.AddForce(RI.velocity * RI.transform.forward, ForceMode.VelocityChange);
            Invoke("enableInteraction", 0.2f);
        }
    }

    public void enableInteraction()
    {
        DI.enabled = true;
    }
    private void WhatIsHolding(SelectEnterEventArgs arg0)
    {
        ItemHolding = arg0.interactable.gameObject;
        if (ItemHolding.GetComponentInChildren<Plate>())
        {
            isHoldingPlate = true;
        }
        else
        {
            isHoldingPlate = false;
        }
    }
    private void NotHolding(SelectExitEventArgs arg0)
    {
        ItemHolding = null;
        isHoldingPlate = false;
    }

    public bool IsHoldingPlate()
    {
        return isHoldingPlate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
