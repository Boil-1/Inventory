using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class InstantiateItems  : MonoBehaviour
{
    public GameObject prefab;
    public static List<Item> allItems = new List<Item>();
    private ItemTypes[] itemTypes = new ItemTypes[] { ItemTypes.weapon, ItemTypes.armor, ItemTypes.item };
    private bool place = true;
    private void Start()
    {
        for (int i = -4; i < 4; i++)
        {
            place = !place;
            for (int j = -1; j < 1; j++)
            {
                place = !place;
                if (place)
                {
                    Item itm = new Item(itemTypes[UnityEngine.Random.Range(0, itemTypes.Length)],Instantiate(prefab, new Vector3(i, j),Quaternion.identity));
                    itm.itemObject.name = itm.type.ToString();
                    itm.itemObject.GetComponentInChildren<TMP_Text>().text = itm.type.ToString();
                    allItems.Add(itm);
                }
            }
        }
    }
}
