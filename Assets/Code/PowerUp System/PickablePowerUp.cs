using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickablePowerUp : MonoBehaviour, IPickable
{
    public GameObject powerUpPrefab;

    public void Pick(GameObject picker)
    {
        Instantiate(powerUpPrefab, picker.transform);
    }
}
