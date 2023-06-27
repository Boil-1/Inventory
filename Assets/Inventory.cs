using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public static Dictionary<ItemTypes, List<Item>> inventory = new Dictionary<ItemTypes, List<Item>>();
    public static Item[] inventoryList = new Item[8]; 
    public static UnityEvent Add = new UnityEvent();
    public static UnityEvent Remove = new UnityEvent();

    public static void AddItem(Item item)
    {
        if(!inventory.ContainsKey(item.type))
            inventory.Add(item.type, new List<Item>());
        inventory[item.type].Add(item);
        Add.Invoke();
    }

    public static void RemoveItem(Item item)
    {
        if (!inventory.ContainsKey(item.type)) return;
        var targetItems = inventory[item.type];
        targetItems.Remove(item);
        Remove.Invoke();
    }

    public static void ClearDictionary<T>(Dictionary<T, T> dictionary)
    {
        foreach (KeyValuePair<T, T> keyvalue in dictionary)
        {
            dictionary.Remove(keyvalue.Key);
            dictionary.Remove(keyvalue.Value);
        }
    }
}

public enum ItemTypes
{
    weapon,
    armor,
    item
}



/*inventory class heeft functies add, remove, clear

als je iets add kan je een item adden en met enum zien welk type het is
    unity events als item word gead of veranderd

dictionary<ItemType, ItemAmountInInventory>*/