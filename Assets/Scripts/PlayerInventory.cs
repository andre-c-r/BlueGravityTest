using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    List<Item> inventoryItems = new List<Item> ();

    public void AddItem (Item item) {
        if (inventoryItems.Contains (item)) return;

        inventoryItems.Add (item);
    }
}
