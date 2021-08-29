using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class CuttingBoard : MonoBehaviour
{
    // Start is called before the first frame update
    private XRSocketInteractor SI;
    Cutable cutableProduct;
    void Start()
    {
        SI = GetComponent<XRSocketInteractor>();
        SI.selectEntered.AddListener(enableCut);
        SI.selectExited.AddListener(print);

    }
    
    private void enableCut(SelectEnterEventArgs arg0)
    {
        //print("enableCut");
        cutableProduct = arg0.interactable.gameObject.GetComponent<Cutable>();
        if (cutableProduct)
        {
            //if (cutableProduct.cuttingBoardAnchor)
           // {
            //    Invoke("changeAnchor",0.1f);
           // }
            cutableProduct.enableCut();
        }
    }

    private void changeAnchor()
    {
        if (cutableProduct)
        {
            //SI.attachTransform.position = cutableProduct.cuttingBoardAnchor.transform.position;
            //SI.attachTransform.rotation = cutableProduct.cuttingBoardAnchor.transform.rotation;
        }
    }

    private void print(SelectExitEventArgs arg0)
    {
        cutableProduct = null;
        cutableProduct = arg0.interactable.gameObject.GetComponent<Cutable>();
        if (cutableProduct)
        {
            cutableProduct.disableCut();
        }
        // SI.attachTransform = Transform;
        //Invoke("NewMethod",0.2f);
    }

    private void NewMethod()
    {
        cutableProduct = null;

        //SI.attachTransform.localPosition = Vector3.zero;
      //  SI.attachTransform.rotation = Quaternion.identity;
    }

  //  int counter = 0;
    private void OnTriggerEnter(Collider other)
    {
        //print("enter colision "+ counter);
    }

}
