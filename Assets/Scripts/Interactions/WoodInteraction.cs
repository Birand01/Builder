using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodInteraction : InteractionBase
{
    public static event Action<Transform> OnStackDiamond;
    protected override void OnTriggerEnterAction(Collider other)
    {
        OnStackDiamond?.Invoke(this.transform);
    }

}
