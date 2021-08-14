using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CookingTool : MonoBehaviour
{
    private XRSocketInteractor SI;
    private bool isOnStove = false;
    //private bool isProductOnPun = false;
    private cookable cookableProduct;
    public Transform posOnStove;
    public Transform handlePos;
    private XRGrabInteractable GI;

    // Start is called before the first frame update
    void Start()
    {
        SI = GetComponentInChildren<XRSocketInteractor>();
        SI.selectEntered.AddListener(makeCookableReady);
        GI = GetComponent<XRGrabInteractable>();
    }

    private void makeCookableReady(SelectEnterEventArgs arg0)
    {
        cookableProduct = arg0.interactable.gameObject.GetComponent<cookable>();
        if (cookableProduct)
        {
            cookableProduct.prepareForCooking();
        }
    }

    public void setIsOnStove(bool onStove)
    {
        isOnStove = onStove;
        if (isOnStove)
        {
            GI.attachTransform = posOnStove.transform;
        }
        else
        {
            GI.attachTransform = handlePos.transform;
        }
        print("pan on stove "+ onStove);
        if (cookableProduct)
        {
            if (isOnStove)
            {
                cookableProduct.startCooking();
            }
            else
            {
                cookableProduct.stopCooking();
            }
        }
    }
}
