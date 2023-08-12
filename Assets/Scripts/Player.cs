using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterMovement2D {

    public LayerMask interactionLayer;

    public GameObject raycastOrigin;

    public float maxInteractionDistance = 2;

    protected Vector2 lookingDirection = Vector2.zero;

    public bool visualDebug = false;

    protected override void Awake () {
        base.Awake ();
    }

    public override void MoveCharacter (Vector2 movementInput) {
        base.MoveCharacter (movementInput);

        if (Mathf.Abs (rigidBody.velocity.magnitude) > 0) lookingDirection = rigidBody.velocity.normalized;
    }

    public void SearchInteraction () {
        RaycastHit2D hit = Physics2D.Raycast (raycastOrigin.transform.position, lookingDirection, maxInteractionDistance, interactionLayer);

        if (hit.collider == null) return;

        hit.collider.gameObject.GetComponent<InteractiveAgent> ().Interact ();
    }

    private void FixedUpdate () {
        if (visualDebug) {
            Debug.DrawLine (raycastOrigin.transform.position,
                raycastOrigin.transform.position + (new Vector3 (lookingDirection.x, lookingDirection.y, 0) * maxInteractionDistance),
                Color.green, 0, false);
        }
    }
}
