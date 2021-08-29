using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparedIng
{
    private Dishes dish;
    private bool isPreparedForPlate = false;
    private int ingNum;
    public void setDishType(Dishes dish) 
    {
        this.dish = dish;
        setIsPreparedForPlate();
    }

    public Dishes getDishType()
    {
        return dish;
    }

    private void setIsPreparedForPlate()
    {
        isPreparedForPlate = true;
    }

    public bool getIsPreparedForPlate()
    {
        return isPreparedForPlate;
    }


    public int getIngNum()
    {
        return ingNum;
    }

    public void setIngNum(int ingNum)
    {
        this.ingNum = ingNum;
    }
}
