using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;
    private static string movementAnimName = "Speed";
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        PlayerInput.OnPlayerInput += MovementAnimation;
    }
    private void OnDisable()
    {
        PlayerInput.OnPlayerInput -= MovementAnimation;
    }

    private void MovementAnimation(Vector3 movementVector)
    {
        if (movementVector.x != 0 || movementVector.z != 0)
        {
            anim.SetFloat(movementAnimName, 1.0f);
        }
        else
        {

            anim.SetFloat(movementAnimName, 0.0f);
        }

    }
}
