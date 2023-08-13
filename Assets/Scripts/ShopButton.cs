using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : ItemButtonBase {

    public TextMeshProUGUI priceText;

    public void BuyItem () {
        PlayerInventory.Singleton.BuyItem (item);
    }

    public void SetupItem () {
        nameText.text = item.name;
        priceText.text = item.itemPrice.ToString();
    }

    private void Awake () {
        SetupItem ();
    }
}
