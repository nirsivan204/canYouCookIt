using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum OmletteIngrediants
{
    Omlette,
    None
}

public class Omlette : Dish
{
    public override void ShowNextIngrediant(int prod)
    {
      //  Type enumType = prod.GetType();
      //  if (enumType.Name != "OmletteIngrediants")
      //  {
      //      print("error in omlette, not an omlette");
      //  }
      //  else
        {
            OmletteIngrediants egg = (OmletteIngrediants)prod;
            if (!isReady)
            {
                switch (egg)
                {
                    case OmletteIngrediants.Omlette:
                        ingrediantsMeshsRef[numOfIng].enabled = true;
                        break;
                }
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
                print("error in omlette. too much ingrediants");
            }
        }
    }
}
