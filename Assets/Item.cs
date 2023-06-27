using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public GameObject itemObject;
    public ItemTypes type;
    public int YPosition;

    public Item(ItemTypes type, GameObject itemObject)
    {
        this.type = type;
        this.itemObject = itemObject;
    }
}
