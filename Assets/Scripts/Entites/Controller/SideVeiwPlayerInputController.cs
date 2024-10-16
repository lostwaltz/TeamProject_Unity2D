using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SideVeiwPlayerInputController : SideVeiwController
{
    public void OnMove(InputValue inputValue)
    {
        OnCallMoveEvent(inputValue.Get<Vector2>());
    }
}
