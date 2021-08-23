using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparedIng: Component
{
    private Dishes dish;
    private Vegetables veg;
    private bool isPreparedForPlate = false;
    private OmletteIngrediants egg;
    public void setDishType(Dishes dish) 
    {
        this.dish = dish;
        setIsPreparedForPlate();
    }

    public Dishes getDishType()
    {
        return dish;
    }

    public void setVegType(Vegetables veg)
    {
        this.veg = veg;
    }

    public Vegetables getVegType()
    {
        return veg;
    }

    private void setIsPreparedForPlate()
    {
        isPreparedForPlate = true;
    }

    public bool getIsPreparedForPlate()
    {
        return isPreparedForPlate;
    }

    public OmletteIngrediants getOmletteType()
    {
        return egg;
    }

    public void setOmletteType(OmletteIngrediants egg)
    {
        this.egg = egg;
    }
}
