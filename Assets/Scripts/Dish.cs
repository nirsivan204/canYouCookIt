using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dish : MonoBehaviour
{
    [SerializeField] GameObject mesh;
    [SerializeField] protected MeshRenderer[] ingrediants;
    [SerializeField] protected int maxNumIngrediants;
    protected bool isReady = false;
    protected int numOfIng = 0;

    protected void Start()
    {
        if (mesh)
        {
            mesh.SetActive(true);
        }
        else
        {
            print("No Mesh");
        }
    }
    public virtual void ShowNextIngrediant(int prod)
    {

    }

    public bool isDishReady()
    {
        if(numOfIng == maxNumIngrediants)
        {
            isReady = true;
        }
        return isReady;
    }

}
