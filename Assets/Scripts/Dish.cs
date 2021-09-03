using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dish : MonoBehaviour
{
    [SerializeField] GameObject mesh;
    protected int[] ingrediants;
    [SerializeField] protected int maxNumIngrediants;
    protected bool isReady = false;
    protected int numOfIng = 0;
    [SerializeField] protected MeshRenderer[] ingrediantsMeshsRef;

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
        ingrediants = new int[maxNumIngrediants];
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

    public virtual int ScoreDish(Dish TargetDish)
    {
        if(GetType() != TargetDish.GetType())
        {
            return -10;
        }
        return 0;
    }

    public int[] getIngrediants()
    {
        return ingrediants;
    }
}
