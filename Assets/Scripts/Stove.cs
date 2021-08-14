using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Stove : XRSocketInteractor
{
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        CookingTool tool = args.interactable.gameObject.GetComponent<CookingTool>();
        if (tool)
        {
            tool.setIsOnStove(true);
        }
        base.OnSelectEntering(args);
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        CookingTool tool = args.interactable.gameObject.GetComponent<CookingTool>();
        if (tool)
        {
            tool.setIsOnStove(false);
        }
        base.OnSelectExiting(args);

    }

}
