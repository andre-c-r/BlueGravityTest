using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

    public InputMaster controls;

    Player player;

    Vector2 movementInput = Vector2.zero;

    public float deadzone = 0.15f;

    public float speed = 5;

    bool searchInteraction = false, interactionLock = false;

    void EnablePlayerMap () {
        if (controls == null) {
            controls = new InputMaster ();
        }
        controls.PlayerMap.Enable ();
    }

    private void Awake () {
        player = GetComponent<Player> ();

        EnablePlayerMap ();

        controls.PlayerMap.Interact.performed += ctx => SearchInteraction();
        controls.PlayerMap.Interact.canceled += ctx => interactionLock = false;

        controls.PlayerMap.Movement.performed += ctx => ReadMomventInput (ctx.ReadValue<Vector2> ());
        controls.PlayerMap.Movement.canceled += ctx => ReadMomventInput (Vector2.zero);
    }
    public void OnEnable () {
        EnablePlayerMap ();
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
