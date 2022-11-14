using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject angelicPower;
    public GameObject demonPower;

    public GameObject passage;

    private void Awake()
    {
        angelicPower.GetComponent<PickablePowerUp>().OnPickUpPowerUpEvent += OnPickUp;
        angelicPower.GetComponent<PickablePowerUp>().OnDestroyPowerUpEvent += OnDestroyPowerUp;
        demonPower.GetComponent<PickablePowerUp>().OnPickUpPowerUpEvent += OnPickUp;
        demonPower.GetComponent<PickablePowerUp>().OnDestroyPowerUpEvent += OnDestroyPowerUp;
    }

    public void OnPickUp(GameObject powerUp)
    {

        if (powerUp.name == "Angel")
        {
            demonPower.SetActive(false);
        }
        else
        {
            angelicPower.SetActive(false);
        }

        passage.GetComponent<Collider2D>().enabled = true;
    }

    public void OnDestroyPowerUp(GameObject powerUp)
    {
        if (passage)
            passage.GetComponent<Collider2D>().enabled = true;

        if (powerUp.name == "Angel")
        {
            demonPower?.SetActive(false);
        }
        else
        {
            angelicPower?.SetActive(false);
        }
    }
}
