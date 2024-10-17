using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SideViewMovement : MonoBehaviour
{
    private PhotonView photonView;


    private Vector2 direction = Vector2.zero;

    private SideVeiwController controller;
    private Rigidbody2D movementRigidbody2D;
    private SpriteRenderer spriteRenderer;
    private CharacterStatsHandler statHandler;
    private HealthSystem healthSystem;

    private float statSpeed => statHandler.CurrentStat.speed;

    private void Awake()
    {
        controller = GetComponent<SideVeiwController>();
        movementRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        statHandler =  GetComponent<CharacterStatsHandler>();
        healthSystem = GetComponent<HealthSystem>();
        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (!photonView.IsMine)
            return;

        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyDirectionMove();
    }

    private void ApplyDirectionMove()
    {
        movementRigidbody2D.velocity = direction * statSpeed * (healthSystem.IsAttacked ? 0 : 1);
    }

    private void Move(Vector2 _direction)
    {
        direction = _direction;

        bool isFilpX = controller.direction.x < 0;

        photonView.RPC("FlipXRPC", RpcTarget.All, isFilpX); 
    }

    [PunRPC]
    private void FlipXRPC(bool isFlipX)
    {
        spriteRenderer.flipX = isFlipX;
    }
}
