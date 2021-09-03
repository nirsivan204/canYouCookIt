using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Table : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor SI;
    [SerializeField] private Dish WantedDish;
    [SerializeField] private Dish dishOnTable;
    private void Start()
    {
        SI = GetComponent<XRSocketInteractor>();
        SI.enabled = true;
        SI.selectEntered.AddListener(CheckDish);
    }

    private void CheckDish(SelectEnterEventArgs arg0)
    {
        Plate plate = arg0.interactable.GetComponentInChildren<Plate>();
        if (plate)
        {
            dishOnTable = plate.getDish();
            //gradeDish();
        }
    }
}
