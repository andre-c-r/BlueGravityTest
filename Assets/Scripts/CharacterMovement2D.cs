using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class CharacterMovement2D : MonoBehaviour {
    protected Rigidbody2D rigidBody;

    public Animator animator;

    public virtual void MoveCharacter (Vector2 movementInput) {
        //moves only horizontally or vertically at a time
        if (Mathf.Abs (movementInput.x) >= Mathf.Abs (movementInput.y)) {
            movementInput.y = 0;
        }
        else {
            movementInput.x = 0;
        }

        rigidBody.velocity = movementInput;

        animator.SetFloat ("xSpeed", movementInput.x);
        animator.SetFloat ("ySpeed", movementInput.y);

        animator.SetBool ("moving", rigidBody.velocity.magnitude < 0.15f ? false : true);
    }

    // Start is called before the first frame update
    protected virtual void Awake () {
        rigidBody = this.GetComponent<Rigidbody2D> ();
    }
}
