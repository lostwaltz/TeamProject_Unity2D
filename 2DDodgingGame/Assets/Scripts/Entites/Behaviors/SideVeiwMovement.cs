using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideVeiwMovement : MonoBehaviour
{

    private Vector2 direction = Vector2.zero;

    private SideViewController controller;
    private Rigidbody2D movementRigidbody2D;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        controller = GetComponent<SideViewController>();
        movementRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyDirectionMove();
    }

    private void ApplyDirectionMove()
    {
        movementRigidbody2D.velocity = direction * 5f;
    }

    private void Move(Vector2 _direction)
    {
        spriteRenderer.flipX = controller.direction.x < 0;

        direction = _direction;
    }
}
