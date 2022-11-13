using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Item")]
public class ItemSO : ScriptableObject
{
    public int price;
    [TextArea(20, 20)]
    public string description;
    public GameObject itemPrefab;
    public Sprite sprite;
}
