using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Singleton;

    public InputMaster controls;

    public void EnablePlayerMap () {
        if (controls == null) {
            controls = new InputMaster ();
        }
        controls.PlayerMap.Enable ();
        controls.Menu.Disable ();
    }

    public void EnableMenuMap () {
        if (controls == null) {
            controls = new InputMaster ();
        }
        controls.PlayerMap.Disable ();
        controls.Menu.Enable ();
    }

    private void Awake () {
        if (Singleton != null) Destroy (this);

        Singleton = this;

    }
}
