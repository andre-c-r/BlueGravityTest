using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterMovement2D
{
    public float maxInteractionDistance;

    public LayerMask interactionLayer;

    protected override void Awake () {
        base.Awake ();
    }
}
