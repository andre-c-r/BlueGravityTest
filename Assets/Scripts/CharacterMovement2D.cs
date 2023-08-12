using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class CharacterMovement2D : MonoBehaviour {
    Rigidbody2D m_rigidBody;

    public void MoveCharacter (Vector2 movementInput) {
        //moves only horizontally or vertically at a time
        if (Mathf.Abs(movementInput.x) >= Mathf.Abs (movementInput.y)) {
            movementInput.y = 0;
        }
        else {
            movementInput.x = 0;
        }

        m_rigidBody.velocity = movementInput;
    }

    // Start is called before the first frame update
    protected virtual void Awake () {
        m_rigidBody = this.GetComponent<Rigidbody2D> ();
    }
}
