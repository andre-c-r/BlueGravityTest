using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public static MenuController Singleton;

    public GameObject dialogueBox, inventoryBox;

    TextMeshProUGUI dialogueText;

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
