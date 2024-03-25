using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject] PlayerMovement playerMovement;

    private void OnEnable()
    {

        PlayerInput.OnPlayerInput += HandleAngularMovement;
        PlayerInput.OnPlayerInput += HandleMovement;
    }
    private void OnDisable()
    {

        PlayerInput.OnPlayerInput -= HandleAngularMovement;
        PlayerInput.OnPlayerInput -= HandleMovement;
    }
    public void HandleMovement(Vector3 movementVector)
    {
        playerMovement.CharacterMovement(movementVector);
    }

    public void HandleAngularMovement(Vector3 angularMoveVector)
    {
        playerMovement.CharacterAngularMovement(angularMoveVector);
    }
}
