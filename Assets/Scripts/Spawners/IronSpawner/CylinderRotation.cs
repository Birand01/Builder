using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CylinderRotation : MonoBehaviour
{
    protected CompositeDisposable subscriptions = new CompositeDisposable();
    [SerializeField] private float rotationSpeed;
    protected virtual void OnEnable()
    {
        StartCoroutine(Subscribe());

    }
    protected virtual void OnDisable()
    {

        subscriptions.Clear();
    }
    private  IEnumerator Subscribe()
    {
        yield return null;

        this.UpdateAsObservable().Subscribe(x =>
        {
            RotateCylinder();
        })
            .AddTo(subscriptions);
    }

    private void RotateCylinder()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));

    }


}
