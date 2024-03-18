using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private Transform stoneSpawnPlaceParent,stoneParent;
    [SerializeField] private List<Transform> stoneSpawnPlaces=new List<Transform>();
    [SerializeField] private int maxStoneCapacity;
    private float yAxis;
    private int spawnIndex = 0;
    private int currentStoneAmount = 0;
    private void Awake()
    {
        for (int i = 0; i < stoneSpawnPlaceParent.childCount; i++)
        {
            stoneSpawnPlaces.Add(stoneSpawnPlaceParent.GetChild(i));
        }
    }
    private void Start()
    {
        StartCoroutine(ProduceStone());
    }
 
    private IEnumerator ProduceStone()
    {
        
        while (currentStoneAmount<=maxStoneCapacity)
        {
            GameObject money = Instantiate(stonePrefab);
            money.transform.position = this.gameObject.transform.parent.transform.position;
            money.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
            money.transform.SetParent(stoneParent);
            money.transform.DOJump(new Vector3(stoneSpawnPlaces[spawnIndex].position.x, stoneSpawnPlaces[spawnIndex].position.y + yAxis,
                stoneSpawnPlaces[spawnIndex].position.z), 2f, 1, 0.5f).SetEase(Ease.OutQuad);
           spawnIndex++;
            currentStoneAmount++;
            if(spawnIndex >= 9)
            {
                spawnIndex = 0;
                yAxis += 0.3f;
            }
            yield return new WaitForSeconds(0.3f);
        }
       


    }
}
