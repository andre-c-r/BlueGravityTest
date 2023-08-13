using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : ItemButtonBase {

    public TextMeshProUGUI priceText;

    public void BuyItem () {
        if (!PlayerInventory.Singleton.CanBuyItem (item)) return;

        PlayerInventory.Singleton.BuyItem (item);
        this.button.interactable = false;
    }

    public void SetupItem () {
        nameText.text = item.name;
        priceText.text = item.itemPrice.ToString() + " Z";
    }

    private void Awake () {
        SetupItem ();
    }
}
