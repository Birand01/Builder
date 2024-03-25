using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private Transform woodMovementEndPoint;
    [SerializeField] private Transform woodSpawnPlaceParent;
    [SerializeField] private List<Transform> woodSpawnPlaces=new List<Transform>();
    [SerializeField] private int maxObjectCapacity;
    private float yAxis;
    private int spawnIndex;
    private int currentObjectAmount = 0;
    private bool playerInteraction=false;
    private void Awake()
    {
        spawnIndex = 0;
        for (int i = 0; i < woodSpawnPlaceParent.childCount; i++)
        {
            woodSpawnPlaces.Add(woodSpawnPlaceParent.GetChild(i));
        }
    }
    private void OnEnable()
    {
        WoodSpawnPlaceInteraction.OnPlayerInteraction += PlayerInteraction;
    }
    private void OnDisable()
    {
        WoodSpawnPlaceInteraction.OnPlayerInteraction -= PlayerInteraction;

    }
    private void Start()
    {
        StartCoroutine(SpawnWood());
    }

    private void PlayerInteraction(bool state)
    {
        playerInteraction = state;
    }

    private IEnumerator SpawnWood()
    {
        while (currentObjectAmount<maxObjectCapacity && !playerInteraction)
        {
            GameObject wood = Instantiate(woodPrefab);
            wood.transform.position = new Vector3(transform.position.x,transform.position.y+0.3f,transform.position.z);
            wood.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            wood.transform.SetParent(transform);


            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(wood.transform.DOMove(woodMovementEndPoint.position, 1f))
              .Append(wood.transform.DOScaleY(0.20f, 0.1f))
              .PrependInterval(0.1f)
              .Append(wood.transform.DOJump(new Vector3(woodSpawnPlaces[spawnIndex].position.x, woodSpawnPlaces[spawnIndex].position.y + yAxis,
            woodSpawnPlaces[spawnIndex].position.z), 2f, 1, 0.5f).SetEase(Ease.OutQuad));

           
            spawnIndex++;
            currentObjectAmount++;
            if (spawnIndex >= 9)
            {
                spawnIndex = 0;
                yAxis += 0.3f;
            }
           
            yield return new WaitForSeconds(0.5f);
        }


    }

    
}
