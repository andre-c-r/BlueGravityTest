using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {
    Player player;

    Vector2 movementInput = Vector2.zero;

    public float deadzone = 0.15f;

    public float speed = 5;

    bool searchInteraction = false, interactionLock = false;


    private void Start () {
        player = GetComponent<Player> ();

        InputController.Singleton.EnablePlayerMap ();

        InputController.Singleton.controls.PlayerMap.Interact.performed += ctx => SearchInteraction();
        InputController.Singleton.controls.PlayerMap.Interact.canceled += ctx => interactionLock = false;

        InputController.Singleton.controls.PlayerMap.Movement.performed += ctx => ReadMomventInput (ctx.ReadValue<Vector2> ());
        InputController.Singleton.controls.PlayerMap.Movement.canceled += ctx => ReadMomventInput (Vector2.zero);
    }

    void SearchInteraction () {
        if (interactionLock) return;

        searchInteraction = true;
        interactionLock = true;
    }

    void ReadMomventInput (Vector2 input) {
        if (Mathf.Abs (input.x) < deadzone) input.x = 0;
        if (Mathf.Abs (input.y) < deadzone) input.y = 0;

        movementInput = input;
    }

    private void FixedUpdate () {
        player.MoveCharacter (movementInput * speed);

        if (searchInteraction) {
            player.SearchInteraction ();
            searchInteraction = false;
        }
    }
}
