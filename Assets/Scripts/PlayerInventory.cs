using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public static PlayerInventory Singleton;

    public Animator outfitSwapAnimator;

    List<Item> inventoryItems = new List<Item> ();

    int cash = 900;

    bool openMenu = false;

    public List<Item> initialItems = new List<Item> ();

    public List<Item> GetInventory () {
        return inventoryItems;
    }

    public bool CanBuyItem (Item i_item) {
        return i_item.itemPrice <= cash;
    }

    public void BuyItem (Item i_item) {
        if (inventoryItems.Contains (i_item)) return;
        if (!CanBuyItem (i_item)) return;

        cash -= i_item.itemPrice;
        MenuController.Singleton.SetCashText (cash);
        inventoryItems.Add (i_item);
    }

    public void AddItem (Item item) {
        if (inventoryItems.Contains (item)) return;

        inventoryItems.Add (item);
    }

    private void Start () {
        InputController.Singleton.EnablePlayerMap ();

        InputController.Singleton.controls.PlayerMap.OpenMenu.performed += ctx => openMenu = true;

        foreach (Item item in initialItems) AddItem (item);
    }


    private void Awake () {
        if (Singleton != null) Destroy (this);

        Singleton = this;

    }

    private void FixedUpdate () {
        if (openMenu) {
            MenuController.Singleton.SetupInventory ();
            openMenu = false;
        }
    }
}
