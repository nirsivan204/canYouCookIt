using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Product : XRGrabInteractable
{
    public GameObject childParent;
    private Rigidbody rb;
    private bool createdNext = false;
    private Vector3 interactorPos = Vector3.zero;
    private Quaternion interactorRot = Quaternion.identity;

    [SerializeField] Transform BoardPos;
    [SerializeField] Transform HandPos;


    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        // print("1" + gameObject);
        //print("2" + args.interactor.gameObject + "tag = " + args.interactor.gameObject.tag + "layer " + args.interactor.gameObject.layer) ;
        // print("3" + args.interactable.gameObject);

        //if ( args.interactor.gameObject.tag == "Player")//
        // {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        Container container = GetComponentInParent<Container>();
        if (!createdNext && container)
        {
            container.create();
            createdNext = true;
        }
        if (childParent)
        {
            childParent.SetActive(true);
        }

        storeInteractor(args.interactor);
        if(args.interactor.tag == "CuttingBoard")
        {
            //print("board");
            attachTransform = BoardPos;
        }
        if(args.interactor.tag == "Player")
        {
            attachTransform = HandPos;
            //print("Player");
            //matchAttachmentPoints(args.interactor);

        }
        base.OnSelectEntering(args);

        // matchAttachmentPoints(args.interactor);


    }

    private void storeInteractor(XRBaseInteractor interactor)
    {
        interactorPos = interactor.attachTransform.localPosition;
        interactorRot = interactor.attachTransform.localRotation;
    }

    private void matchAttachmentPoints(XRBaseInteractor interactor) 
    {
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        resetAttachmentPoints(args.interactor);
        clearInteractor(args.interactor);

    }

    private void resetAttachmentPoints (XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = interactorPos;
        interactor.attachTransform.localRotation = interactorRot ;

    }

    private void clearInteractor(XRBaseInteractor interactor)
    {
        interactorPos = Vector3.zero;
        interactorRot = Quaternion.identity;
    }
}
