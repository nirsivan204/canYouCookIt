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
                ingrediantsMeshsRef[numOfIng].material = mat;
                ingrediantsMeshsRef[numOfIng].enabled = true;
                if (ingrediants == null)
                {
                    ingrediants = new int[maxNumIngrediants];
                }
                ingrediants[numOfIng] = prod;
                numOfIng++;
                isDishReady();
            }
            else
            {
                print("error in salad. too much ingrediants");
            }
        }


    }

    public override int ScoreDish(Dish TargetDish)
    {
        int score = base.ScoreDish(TargetDish);
        if(score >= 0)
        {
            score += compareIngrediants(ingrediants, TargetDish.getIngrediants());

        }
        return score;
    }

    private int compareIngrediants(int[] a, int[] b)
    {
        Array.Sort(a);
        Array.Sort(b);
        int score = 0;
        int offset = 0;
        for (int i = 0; i < maxNumIngrediants; i++)
        {
            if(a[i] == b[i + offset])
            {
                score++;
            }
            else
            {
                int j = 1;
                for (; j < maxNumIngrediants-i; j++)
                {
                    if (a[i] <= b[i+j])
                    {
                        if (a[i] == b[i + j])
                        {
                            score++;
                            break;
                        }
                    }
                }
                offset += j;
            }
        }
        return score--;
    }
}
