using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMapHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void SwitchActionMap(string mapName)
    {
        playerInput.SwitchCurrentActionMap(mapName);
    }
}
