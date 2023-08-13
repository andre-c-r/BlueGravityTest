using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour {

    public TextMeshProUGUI NameBox;

    public Button button;

    Item item;
    
    public void SetupItem (Item i_Item) {
        item = i_Item;
        NameBox.text = item.name;
    }
}
