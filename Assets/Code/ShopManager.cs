using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{

    public List<ItemSO> allItems;

    public GameObject Item1Pos;
    public GameObject Item2Pos;
    public GameObject Item3Pos;
    public GameObject Item4Pos;


    private void Awake()
    {
        ItemSO firstRandom = allItems[Random.Range(0, allItems.Count)];
        allItems.Remove(firstRandom);
        Instantiate(firstRandom.itemPrefab, Item1Pos.transform.position, Quaternion.identity);

        ItemSO secondRandom = allItems[Random.Range(0, allItems.Count)];
        allItems.Remove(secondRandom);
        Instantiate(secondRandom.itemPrefab, Item2Pos.transform.position, Quaternion.identity);

        ItemSO thirdRandom = allItems[Random.Range(0, allItems.Count)];
        allItems.Remove(thirdRandom);
        Instantiate(thirdRandom.itemPrefab, Item3Pos.transform.position, Quaternion.identity);

        ItemSO fourhtRandom = allItems[Random.Range(0, allItems.Count)];
        Instantiate(fourhtRandom.itemPrefab, Item4Pos.transform.position, Quaternion.identity);
    }

}
