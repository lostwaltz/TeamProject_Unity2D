using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");

    private readonly float magnituteThreshold = 0.5f;


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        animator.SetBool(isWalking, direction.magnitude > magnituteThreshold);
    }
}
