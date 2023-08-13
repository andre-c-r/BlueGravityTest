using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Singleton;

    public Animator outfitSwapAnimator;

    List<Item> inventoryItems = new List<Item> ();

    int cash = 900;

    bool openMenu = false;

    private void Start () {
        InputController.Singleton.EnablePlayerMap ();

        InputController.Singleton.controls.PlayerMap.OpenMenu.performed += ctx => openMenu = true;
    }

    public List<Item> GetInventory () {
        return inventoryItems;
    }

    public void BuyItem (Item item) {
        if (inventoryItems.Contains (item)) return;

        cash -= item.itemPrice;
        MenuController.Singleton.SetCashText (cash);
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

    private void FixedUpdate () {
        if (openMenu) {
            MenuController.Singleton.SetupInventory ();
            openMenu = false;
        }
    }
}
