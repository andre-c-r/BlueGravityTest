using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour {
    public static MenuController Singleton;

    public GameObject dialogueBox;

    TextMeshProUGUI dialogueText;

    public GameObject inventoryBox, inventoryCellPrefab, inventoryContent;

    public GameObject shopBox, firstCellShop;

    public void SetupShop (Item[] itemList) {
        InputController.Singleton.EnableMenuMap ();

        firstCellShop.GetComponent<Button> ().Select ();

        shopBox.SetActive (true);
    }

    public void SetupDialogue (string message) {
        dialogueText.text = message;

        dialogueBox.SetActive (true);
    }

    public void CloseAllWindows () {
        dialogueBox.SetActive (false);
        inventoryBox.SetActive (false);
        shopBox.SetActive (false);

        InputController.Singleton.EnablePlayerMap ();
    }

    private void Awake () {
        if (Singleton != null) Destroy (this);

        Singleton = this;

        dialogueText = dialogueBox.GetComponentInChildren<TextMeshProUGUI> ();
    }
}
