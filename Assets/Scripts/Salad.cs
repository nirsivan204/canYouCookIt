using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Vegetables
{
    Tomato,
    Carrot,
    Shroom,
    Onion,
    None
}

public class Salad : Dish
{
    [SerializeField] Material tomatoMat;
    [SerializeField] Material carrotMat;
    [SerializeField] Material shroomMat;
    [SerializeField] Material onionMat;

    public override void ShowNextIngrediant(int prod)
    {
        Material mat = null;
        //Type enumType = prod.GetType();
        //if(enumType.Name != "Vegetables")
       // {
       //     print("error in salad, not a vegetable");
       // }
    //    else
        {
            Vegetables veg = (Vegetables)prod;
            if (!isReady)
            {
                switch (veg)
                {
                    case Vegetables.Tomato:
                        mat = tomatoMat;
                        break;
                    case Vegetables.Carrot:
                        mat = carrotMat;
                        break;
                    case Vegetables.Shroom:
                        mat = shroomMat;
                        break;
                    case Vegetables.Onion:
                        mat = onionMat;
                        break;
                }
                ingrediants[numOfIng].material = mat;
                ingrediants[numOfIng].enabled = true;
                numOfIng++;
                isDishReady();
            }
            else
            {
                print("error in salad. too much ingrediants");
            }
        }


    }
}
