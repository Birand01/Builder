using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawnPlaceInteraction : InteractionBase
{
    public static event Action<bool> OnPlayerInteraction;
   
    protected override void OnTriggerEnterAction(Collider other)
    {
        Debug.Log("INTERACT IN");
        OnPlayerInteraction?.Invoke(false);
    }
    protected override void OnTriggerExitAction(Collider other)
    {
        Debug.Log("INTERACT OUT");

        OnPlayerInteraction?.Invoke(true);
    }

}
