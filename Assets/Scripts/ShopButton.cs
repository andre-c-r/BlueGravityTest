using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : ItemButtonBase {    

    public void BuyItem () {
        PlayerInventory.Singleton.BuyItem (item);
    }
}
