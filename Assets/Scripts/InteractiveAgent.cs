using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveAgent : MonoBehaviour
{
    public string dialogueMessage;
    
    public virtual void Interact () {
        MenuController.Singleton.SetupDialogue (dialogueMessage);
    }
}
