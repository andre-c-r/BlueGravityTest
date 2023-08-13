using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour {
    public static MenuController Singleton;

    public GameObject dialogueBox, inventoryBox;

    TextMeshProUGUI dialogueText;

    public GameObject inventoryCellPrefab, inventoryContent;

    public List<InventoryButton> inventoryCells;

    public void SetupInventory (Item[] itemList) {
        int i = 0;

        //spawn extra cells if needed
        foreach (Item item in itemList) {
            if (i >= inventoryCells.Count)
                inventoryCells.Add (Instantiate (inventoryCellPrefab, inventoryContent.transform).GetComponent<InventoryButton> ());

            i++;
        }

        //deactivate extra cells if needed
        for (i = itemList.Length; i < inventoryCells.Count; i++) {
            inventoryCells[i].gameObject.SetActive (false);
        }

        //Setup item values on inventory/shop
        for (i = 0; i < itemList.Length; i++) {
            inventoryCells[i].SetupItem (itemList[i]);
        }

        inventoryCells[0].button.Select ();
    }

    public void SetupDialogue (string message) {
        dialogueText.text = message;

        dialogueBox.SetActive (true);
    }

    private void Awake () {
        if (Singleton != null) Destroy (this);

        Singleton = this;

        dialogueText = dialogueBox.GetComponentInChildren<TextMeshProUGUI> ();
    }
}
