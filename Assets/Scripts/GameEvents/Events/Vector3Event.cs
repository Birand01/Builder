using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Vector3 Event", menuName = "GameEvents/Vector3 Event", order = 1)]
public class Vector3Event : BaseGameEvent<Vector3>
{
    public void Raise() => Raise();

}
