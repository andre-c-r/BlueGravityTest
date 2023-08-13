using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Singleton;

    List<Item> inventoryItems = new List<Item> ();

    int cash = 900;

    public void BuyItem (Item item) {
        if (inventoryItems.Contains (item)) return;

        cash -= item.itemPrice;
        inventoryItems.Add (item);
    }

    public void AddItem (Item item) {
        if (inventoryItems.Contains (item)) return;

        inventoryItems.Add (item);
    }

    private void Awake () {
        if (Singleton != null) Destroy (this);

        Singleton = this;

    }
}
