using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SideViewPlayerInputController : SideVeiwController
{
    public void OnJump()
    {
        OnCallJumpEvent();
    }

    public void OnMove(InputValue inputValue)
    {
        OnCallMoveEvent(inputValue.Get<Vector2>());
    }
}
