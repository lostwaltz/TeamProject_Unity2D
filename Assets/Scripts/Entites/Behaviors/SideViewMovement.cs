using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideViewMovement : MonoBehaviour
{
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
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnJumpEvent += Jump;
    }



    private void FixedUpdate()
    {
        ApplyDirectionMove();
    }

    private void ApplyDirectionMove()
    {
        Vector2 currentVelocity = movementRigidbody2D.velocity;
        currentVelocity.x = (direction * statSpeed * (healthSystem.IsAttacked ? 0 : 1)).x;
        movementRigidbody2D.velocity = currentVelocity;
    }

    private void Move(Vector2 _direction)
    {
        direction = _direction;

        bool isFilpX = controller.direction.x < 0;

        spriteRenderer.flipX = isFilpX;
    }

    private void Jump()
    {
        Debug.Log("มกวม");

        movementRigidbody2D.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
    }
}
