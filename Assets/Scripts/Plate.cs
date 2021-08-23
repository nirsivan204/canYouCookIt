using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Plate : MonoBehaviour
{
    private XRSocketInteractor SI;
    bool hasIngrediant = false;
    private Dishes dishType;
    private Dish dish;
    public GameObject saladGO;
    public GameObject omletteGO;

    // Start is called before the first frame update
    void Start()
    {
        SI = GetComponent<XRSocketInteractor>();
        SI.selectEntered.AddListener(showFood);
    }
    private void showFood(SelectEnterEventArgs arg0)
    {
        if (!hasIngrediant)
        {
            chooseDish(arg0.interactable.gameObject);
            hasIngrediant = true;
        }

    }

    public void chooseDish(GameObject firstIng)
    {
        PreparedIng ing;
        Cutable cutableScript = firstIng.GetComponent<Cutable>();
        if (cutableScript)
        {
            ing = cutableScript.getPreparedIng();
        }
        else
        {
            cookable cookableScript = firstIng.GetComponent<cookable>();
            ing = cookableScript.getPreparedIng();
        }
        if (ing.getIsPreparedForPlate())
        {
            dishType = ing.getDishType();
            switch (dishType)
            {
                case Dishes.Salad:
                    {
                        GameObject clone = Instantiate(saladGO, transform);
                        dish = clone.GetComponent<Salad>();
                        Vegetables veg = ing.getVegType();
                        dish.ShowNextIngrediant(veg);
                        break;
                    }
                case Dishes.Omlette:
                    {
                        GameObject clone = Instantiate(omletteGO, transform);
                        dish = clone.GetComponent<Omlette>();
                        OmletteIngrediants egg = ing.getOmletteType();
                        dish.ShowNextIngrediant(egg);
                        break;
                    }
            }
            firstIng.SetActive(false);
        }
        else
        {
            print("error in Plate, not an ingrediant");

        }
    }

}
