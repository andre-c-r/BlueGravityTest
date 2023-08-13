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

    public GameObject itemsBox, inventoryCellPrefab, inventoryContent, shopContent;
    
    public Button closeBtn;

    List<InventoryButton> buttons = new List<InventoryButton> ();

    bool closeDialogue = false;
    bool closeAllWindows = false;

    public void SetCashText (int i_cash) {
        cashText.text = i_cash.ToString() + " Z";
    }

    public void SetupShop (Item[] itemList) {
        InputController.Singleton.EnableMenuMap ();

        cashBox.SetActive (true);

        closeBtn.Select ();

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

        closeBtn.GetComponent<Button> ().Select ();

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

        foreach (InventoryButton button in buttons) {
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
        InputController.Singleton.EnablePlayerMap ();

        InputController.Singleton.controls.Menu.Submit.performed += ctx => closeDialogue = true;
        InputController.Singleton.controls.Menu.Reject.performed += ctx => closeAllWindows = true;

        CloseAllWindows ();
    }

    private void Awake () {
        if (Singleton != null) Destroy (this);

        Singleton = this;

        dialogueText = dialogueBox.GetComponentInChildren<TextMeshProUGUI> ();
        cashText = cashBox.GetComponentInChildren<TextMeshProUGUI> ();

    }
}
