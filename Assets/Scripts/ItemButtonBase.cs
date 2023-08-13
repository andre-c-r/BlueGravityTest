using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonBase : MonoBehaviour {
    public TextMeshProUGUI nameText;

    public Image itemIcon;

    public Button button;

    public Item item;

    public virtual void SetupItem (Item i_Item) {
        item = i_Item;
        nameText.text = item.name;
        itemIcon.sprite = i_Item.ItemIcon;
    }
}
