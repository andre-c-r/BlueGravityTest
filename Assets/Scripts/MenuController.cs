using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour {
    public static MenuController Singleton;

    public GameObject dialogueBox;

    TextMeshProUGUI dialogueText, cashText;

    public GameObject cashBox;

    public GameObject itemsBox, inventoryCellPrefab, inventoryContent, shopContent, shopCellPrefab;

    public Button closeBtn;

    List<ItemButtonBase> buttons = new List<ItemButtonBase> ();

    bool closeDialogue = false;
    bool closeAllWindows = false;

    public void SetCashText (int i_cash) {
        cashText.text = i_cash.ToString () + " Z";
    }

    public void SelectCloseButton () {
        closeBtn.Select ();
    }

    public void SetupShop (Item[] itemList) {
        InputController.Singleton.EnableMenuMap ();

        foreach (Item item in itemList) {
            ShopButton auxButton = Instantiate (shopCellPrefab, shopContent.transform).GetComponent<ShopButton> ();
            auxButton.SetupItem (item);

            //checks if player already have item
            if (PlayerInventory.Singleton.GetInventory ().Contains (item)) auxButton.button.interactable = false;

            buttons.Add (auxButton);
        }

        cashBox.SetActive (true);

        SelectCloseButton ();

        itemsBox.SetActive (true);
        shopContent.SetActive (true);
        inventoryContent.SetActive (false);
    }
    public void SetupInventory () {
        InputController.Singleton.EnableMenuMap ();

        foreach (Item item in PlayerInventory.Singleton.GetInventory ()) {
            InventoryButton auxButton = Instantiate (inventoryCellPrefab, inventoryContent.transform).GetComponent<InventoryButton> ();
            auxButton.SetupItem (item);

            buttons.Add (auxButton);
        }

        SelectCloseButton ();

        itemsBox.SetActive (true);
        shopContent.SetActive (false);
        inventoryContent.SetActive (true);
    }

    public void SetupDialogue (string message) {
        InputController.Singleton.EnableMenuMap ();

        dialogueText.text = message;

        dialogueBox.SetActive (true);
    }

    public void CloseAllWindows () {
        dialogueBox.SetActive (false);
        itemsBox.SetActive (false);
        cashBox.SetActive (false);

        foreach (ItemButtonBase button in buttons) {
            Destroy (button.gameObject);
        }

        buttons.Clear ();

        closeAllWindows = false;
        closeDialogue = false;

        InputController.Singleton.EnablePlayerMap ();
    }

    void CheckForCloseWindowsCommand () {
        if (!closeAllWindows) {
            if (!closeDialogue) return;
            //it's not a common dialogue if itesbox is open
            if (itemsBox.activeSelf) return;

        }

        CloseAllWindows ();
    }

    private void FixedUpdate () {
        CheckForCloseWindowsCommand ();
    }

    private void Start () {
        CloseAllWindows ();

        InputController.Singleton.controls.Menu.Submit.performed += ctx => closeDialogue = true;
        InputController.Singleton.controls.Menu.Reject.performed += ctx => closeAllWindows = true;

        SetupDialogue ("Thanks for playing! Use the arrow keys to move, Z to interact with the products, textboxes and the merchant and X to close windows and open your inventory!");
    }

    private void Awake () {
        if (Singleton != null) Destroy (this);

        Singleton = this;

        dialogueText = dialogueBox.GetComponentInChildren<TextMeshProUGUI> ();
        cashText = cashBox.GetComponentInChildren<TextMeshProUGUI> ();

    }
}
