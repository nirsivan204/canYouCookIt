using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class CuttingBoard : MonoBehaviour
{
    // Start is called before the first frame update
    private XRSocketInteractor SI;
    void Start()
    {
        SI = GetComponent<XRSocketInteractor>();
        SI.selectEntered.AddListener(enableCut);
        SI.selectExited.AddListener(print);

    }
    
    private void enableCut(SelectEnterEventArgs arg0)
    {
        Cutable cutableProduct = arg0.interactable.gameObject.GetComponent<Cutable>();
        if (cutableProduct)
        {
            if (cutableProduct.cuttingBoardAnchor)
            {
                SI.attachTransform.position = cutableProduct.cuttingBoardAnchor.transform.position;
                SI.attachTransform.rotation = cutableProduct.cuttingBoardAnchor.transform.rotation;
            }
            cutableProduct.enableCut();
        }
    }

    private void print(SelectExitEventArgs arg0)
    {
        print("exit");
    }
}
