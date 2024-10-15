using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideViewController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnAttackEvent;

    public Vector2 direction { get; private set; }
    protected bool isAttacking { get; set; }
    private float timeSinceLastAttack = float.MaxValue;

    private void Update()
    {
        if(timeSinceLastAttack < 5f)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(true == isAttacking && timeSinceLastAttack > 5f)
        {
            OnCallAttackEvent();
            timeSinceLastAttack = 0f;
        }
        
    }

    public void OnCallMoveEvent(Vector2 _direction)
    {
        if (0 != _direction.x)
            direction = _direction;

        OnMoveEvent?.Invoke(_direction);
    }

    public void OnCallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
