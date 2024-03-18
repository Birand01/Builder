using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class StackManager : MonoBehaviour
{
 
    [SerializeField] private List<Transform> stackList = new List<Transform>();
    [SerializeField] private Transform stackBase;
    [SerializeField] private Ease stackEase;

    private void OnEnable()
    {
       
        WoodInteraction.OnStackDiamond += AddNewItem;
    }
    private void OnDisable()
    {
        WoodInteraction.OnStackDiamond -= AddNewItem;

    }
   
    private void Awake()
    {
        stackList.Add(stackBase);
    }

  
    private void AddNewItem(Transform _itemToAdd)
    {
        _itemToAdd.DOKill(true);

        _itemToAdd.DOJump(stackBase.position +
        new Vector3(0, 0.025f * stackList.Count, 0), 0.5f, 1, 0.1f).OnComplete(
         () =>
         {
             _itemToAdd.DOScale(0.01f, 0.5f);
             _itemToAdd.SetParent(stackBase, true);
             _itemToAdd.localPosition = new Vector3(0, 0.015f * stackList.Count, 0);
             _itemToAdd.localRotation = Quaternion.Euler(90f, 0, 90f);
             stackList.Add(_itemToAdd.transform);
         }
         ).SetEase(stackEase);


    }
}
