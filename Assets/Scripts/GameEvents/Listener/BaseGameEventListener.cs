using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class BaseGameEventListener <T,E,UER>:MonoBehaviour,IGameEventListener<T> 
    where E:BaseGameEvent<T> where UER:UnityEvent<T>
{
    [SerializeField] private E gameEvent;
    [SerializeField] private UER unityEventResponse;
    public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }

    private void OnEnable()
    {
        if(gameEvent==null)
            return;
        GameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (gameEvent == null)
            return;
        GameEvent.UnRegisterListener(this);

    }

    public void OnEventRaised(T item)
    {
       if(unityEventResponse!=null)
       {
           unityEventResponse?.Invoke(item);
       }
    }
}