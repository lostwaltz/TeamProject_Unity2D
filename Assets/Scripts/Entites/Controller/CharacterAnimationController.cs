using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private static readonly int isHit = Animator.StringToHash("isHit");

    private readonly float magnituteThreshold = 0.5f;

    private CharacterStatsHandler statHandler;

    private HealthSystem healthSystem;

    private PhotonView photonView;

    protected override void Awake()
    {
        base.Awake();
        statHandler = GetComponent<CharacterStatsHandler>();
        healthSystem = GetComponent<HealthSystem>();
        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (!photonView.IsMine)
            return;

        controller.OnMoveEvent += Move;
        healthSystem.OnDamage += Hit;
        healthSystem.OninvinciblilityEnd += InvincilbilityEnd;
    }

    private void Hit()
    {
        animator.SetBool(isHit, true);
    }
    private void InvincilbilityEnd()
    {
        animator.SetBool(isHit, false);
    }

    private void Move(Vector2 direction)
    {
        animator.speed = (1f + (statHandler.CurrentStat.speed * 0.05f * Mathf.Abs(direction.x)));

        animator.SetBool(isWalking, direction.magnitude > magnituteThreshold);
    }
}
