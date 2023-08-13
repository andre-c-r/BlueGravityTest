using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : ItemButtonBase {

    public void EquipItem () {
        Animator anim = PlayerInventory.Singleton.outfitSwapAnimator;

        for (int i = 0; i < anim.layerCount; i++) {
            anim.SetLayerWeight (i, 0);
        }

        anim.SetLayerWeight (anim.GetLayerIndex(item.name), 1);
    }
}
