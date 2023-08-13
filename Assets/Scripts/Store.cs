using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : InteractiveAgent {

    public Item[] itemsForSale;

    public override void Interact () {
        base.Interact ();

        MenuController.Singleton.SetupShop (itemsForSale);
    }
}
