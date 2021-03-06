using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Plate : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor SI;
    bool hasIngrediant = false;
    private Dishes dishType = Dishes.Null;
    private Dish dish;
    public GameObject saladGO;
    public GameObject omletteGO;

    // Start is called before the first frame update
    void Start()
    {
        SI = GetComponent<XRSocketInteractor>();
        SI.enabled = true;
        SI.selectEntered.AddListener(showFood);
    }
    private void showFood(SelectEnterEventArgs arg0)
    {
        if (arg0.interactable.gameObject.layer == LayerMask.NameToLayer("ingrediants"))
        {
            PreparedIng ing = checkIngrediant(arg0.interactable.gameObject);
            if (ing.getIsPreparedForPlate())
            {
                if (!hasIngrediant)
                {
                    if (ing.getIsPreparedForPlate())
                    {
                        addFirstIngrediant(ing);
                        hasIngrediant = true;
                    }
                }
                else
                {
                    dish.ShowNextIngrediant(ing.getIngNum());
                }
                Destroy(arg0.interactable.gameObject);
            }
            else
            {
                print("error in Plate, not an ingrediant");
            }
        }
        

    }

    private void addFirstIngrediant( PreparedIng ing)
    {
        dishType = ing.getDishType();
        switch (dishType) 
        {
            case Dishes.Salad:
                {
                    GameObject clone = Instantiate(saladGO, transform);
                    dish = clone.GetComponent<Salad>();
                    dish.ShowNextIngrediant(ing.getIngNum());
                    break;
                }
            case Dishes.Omlette:
                {
                    GameObject clone = Instantiate(omletteGO, transform);
                    dish = clone.GetComponent<Omlette>();
                    dish.ShowNextIngrediant(ing.getIngNum());
                    break;
                }
            case Dishes.Null:
                {
                    print("error in Plate, not an ingrediant");
                    break;
                }
        }
    }

    public PreparedIng checkIngrediant(GameObject firstIng)
    {

        Cutable cutableScript = firstIng.GetComponent<Cutable>();
        if (cutableScript)
        {
            PreparedIng res = cutableScript.getPreparedIng();
            print("is cutuable + " + res);
            return res;
        }
        else
        {
            cookable cookableScript = firstIng.GetComponent<cookable>();
            if (!cookableScript)
            {
                return null;
            }
            return cookableScript.getPreparedIng();
        }
    }

    public Dish getDish()
    {
        return dish;
    }
}