using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class PickUp : MonoBehaviour
{
    private bool inInventory = false;
    private void OnMouseDown()
    {
        //uit inventory
        if (inInventory)
        {
            Inventory.Remove.AddListener(RemoveEvent);
            
            inInventory = false;
            Item thisInstance = null;
            foreach (Item i in InstantiateItems.allItems)
            {
                if (gameObject == i.itemObject)
                    thisInstance = i;
            }
            if(thisInstance != null)
                Inventory.RemoveItem(thisInstance);
            for (int i = 0; i < Inventory.inventoryList.Length; i++)
                if (Inventory.inventoryList[i] == thisInstance)
                {
                    Inventory.inventoryList[i] = null;
                    break;
                }
            transform.position = new Vector3(UnityEngine.Random.Range(-6, 6), UnityEngine.Random.Range(-2, 3));
        }
        
        
        //in inventory
        else if (!inInventory)
        {
            Inventory.Add.AddListener(AddEvent);
            
            Item thisInstance = null;
            foreach (Item i in InstantiateItems.allItems)
            {
                if (gameObject == i.itemObject)
                    thisInstance = i;
            }
            if(thisInstance != null)
                Inventory.AddItem(thisInstance);
            
            for (int i = 0; i < Inventory.inventoryList.Length; i++)
            {
                if (Inventory.inventoryList[i] == null)
                {
                    //Debug.Log(Inventory.inventoryList[i] + " " + i);
                    Inventory.inventoryList[i] = thisInstance;
                    transform.position = new Vector3(i-4, -4);
                    break;
                }
            }
            inInventory = true;
        }
        
        foreach (KeyValuePair<ItemTypes, List<Item>> keyvalue in Inventory.inventory)
        {
            Debug.Log(keyvalue.Key + " " + keyvalue.Value.Count);
        }
        
    }
    
    public void AddEvent()
    {
       gameObject.transform.GetComponent<SpriteRenderer>().color = Color.green;
       Inventory.Remove.RemoveListener(RemoveEvent);
    }

    public void RemoveEvent()
    {
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
        Inventory.Add.RemoveListener(AddEvent);
    }
}
