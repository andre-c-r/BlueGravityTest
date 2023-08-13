using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : ItemButtonBase {

    public void SetupItem (Item i_Item) {
        item = i_Item;
        NameBox.text = item.name;
    }
}
