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
        angelicPower.GetComponent<PickablePowerUp>().OnPickUpPowerUpEvent -= OnPickUp;
        angelicPower.GetComponent<PickablePowerUp>().OnDestroyPowerUpEvent -= OnDestroyPowerUp;
        demonPower.GetComponent<PickablePowerUp>().OnPickUpPowerUpEvent -= OnPickUp;
        demonPower.GetComponent<PickablePowerUp>().OnDestroyPowerUpEvent -= OnDestroyPowerUp;

        if (powerUp.name == "Angel")
        {
            demonPower.SetActive(false);
            demonPower.GetComponent<PickablePowerUp>().canSpawn = false;
        }
        else
        {
            angelicPower.SetActive(false);
            angelicPower.GetComponent<PickablePowerUp>().canSpawn = false;

        }

        passage.GetComponent<Collider2D>().enabled = true;
    }

    public void OnDestroyPowerUp(GameObject powerUp)
    {
        angelicPower.GetComponent<PickablePowerUp>().OnPickUpPowerUpEvent -= OnPickUp;
        angelicPower.GetComponent<PickablePowerUp>().OnDestroyPowerUpEvent -= OnDestroyPowerUp;
        demonPower.GetComponent<PickablePowerUp>().OnPickUpPowerUpEvent -= OnPickUp;
        demonPower.GetComponent<PickablePowerUp>().OnDestroyPowerUpEvent -= OnDestroyPowerUp;
        if (passage)
            passage.GetComponent<Collider2D>().enabled = true;

        if (powerUp.name == "Angel" && demonPower != null)
        {
            demonPower.SetActive(false);
            demonPower.GetComponent<PickablePowerUp>().canSpawn = false;
        }
        else if (angelicPower != null)
        {
            angelicPower.SetActive(false);
            angelicPower.GetComponent<PickablePowerUp>().canSpawn = false;
        }
    }
}
