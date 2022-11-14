using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossController : EnemyController
{
    public AudioSource source;
    public AudioClip clip;

    private AbilityTrigger extraTriggerCopy;
    private AbilityTrigger extraTriggerCopy2;
    private AbilityTrigger extraTriggerCopy3;

    public GameObject powerUps;
    protected override void Awake()
    {
        base.Awake();
        extraTriggerCopy = ScriptableObject.CreateInstance<AbilityTrigger>();
        extraTriggerCopy.DeepCopy(realTrigger);
        extraTriggerCopy.Initialize(gameObject);

        extraTriggerCopy2 = ScriptableObject.CreateInstance<AbilityTrigger>();
        extraTriggerCopy2.DeepCopy(realTrigger);
        extraTriggerCopy2.Initialize(gameObject);

        extraTriggerCopy3 = ScriptableObject.CreateInstance<AbilityTrigger>();
        extraTriggerCopy3.DeepCopy(realTrigger);
        extraTriggerCopy3.Initialize(gameObject);
        StartCoroutine(ShootOnSides());
        StartCoroutine(StartShottingCycle());
        StartCoroutine(FirstShootingConstraint());
        StartCoroutine(SecondShootingConstraint());
        StartCoroutine(ThirdShootingConstraint());
    }

    private IEnumerator ShootOnSides()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            realTrigger.Fire(transform.position, new Vector2(-10f, 8f));
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(transform.position + new Vector3(0, 2, 0), new Vector2(-10f, 10f));
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(transform.position + new Vector3(0, 2, 0), new Vector2(10f, 10f));
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(transform.position, new Vector2(10, 8f));
        }
    }

    private IEnumerator FirstShootingConstraint()
    {
        yield return new WaitForSeconds(15f);
        while (true)
        {
            Vector2 left = transform.position + new Vector3(-0.7f, 0);
            Vector2 right = transform.position + new Vector3(0.7f, 0);
            yield return new WaitForSeconds(0.01f);
            extraTriggerCopy.Fire(left, new Vector2(-0.9f, 7.9f));
            yield return new WaitForSeconds(0.01f);
            extraTriggerCopy.Fire(right, new Vector2(0.9f, 7.9f));

            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator SecondShootingConstraint()
    {
        yield return new WaitForSeconds(30f);
        while (true)
        {
            Vector2 left = transform.position + new Vector3(-0.7f, 0);
            Vector2 right = transform.position + new Vector3(0.7f, 0);
            yield return new WaitForSeconds(0.01f);
            extraTriggerCopy2.Fire(left, new Vector2(-0.9f, 7.7f));
            yield return new WaitForSeconds(0.01f);
            extraTriggerCopy2.Fire(right, new Vector2(0.9f, 7.7f));

            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator ThirdShootingConstraint()
    {
        yield return new WaitForSeconds(45f);
        Vector2 leftDirection = new Vector2(-3, -9f);
        Vector2 rightDirection = new Vector2(3, -9f);
        while (true)
        {
            Vector2 left = transform.position + new Vector3(-3, 0);
            Vector2 right = transform.position + new Vector3(3, 0);
            yield return new WaitForSeconds(0.01f);
            extraTriggerCopy3.Fire(left, leftDirection);
            yield return new WaitForSeconds(0.01f);
            extraTriggerCopy3.Fire(right, rightDirection);

            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator StartShottingCycle()
    {
        float time = 0f;
        Vector2 direction = new Vector2(-1f, 7.8f);
        while (time <= 5f)
        {
            realTrigger.Fire(transform.position, direction);
            yield return new WaitForSeconds(0.4f);
            direction.x += 0.1f;
            time += 0.4f;
        }

        time = 0f;

        while (time <= 5f)
        {
            realTrigger.Fire(transform.position, direction);
            yield return new WaitForSeconds(0.4f);
            direction.x -= 0.2f;
            time += 0.4f;
        }
        time = 0f;

        while (time <= 3)
        {
            Vector2 left = transform.position + new Vector3(-0.3f, 0);
            Vector2 middle = transform.position + new Vector3(0.0f, 0);
            Vector2 right = transform.position + new Vector3(0.3f, 0);
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(left, new Vector2(-1f, -1f));
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(middle, new Vector2(0f, -1f));
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(right, new Vector2(1f, -1f));

            yield return new WaitForSeconds(0.05f);
            time += 0.1f;
        }

        time = 0f;

        while (time <= 3)
        {
            Vector2 left = transform.position + new Vector3(-0.6f, 0);
            Vector2 middle = transform.position + new Vector3(0.0f, 0);
            Vector2 right = transform.position + new Vector3(0.6f, 0);
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(left, new Vector2(-1f, -0.6f));
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(middle, new Vector2(0f, -1f));
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(right, new Vector2(1f, -0.6f));

            yield return new WaitForSeconds(0.05f);
            time += 0.1f;
        }

        time = 0f;

        while (time <= 3)
        {
            Vector2 left = transform.position + new Vector3(-0.6f, 0);
            Vector2 right = transform.position + new Vector3(0.6f, 0);
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(left, new Vector2(-0.5f, -0.6f));
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(right, new Vector2(0.5f, -0.6f));

            yield return new WaitForSeconds(0.05f);
            time += 0.1f;
        }

        time = 0f;

        Vector2 secondaryDirection = new Vector2(1, -1f);
        direction.x = -1;
        direction.y = -1f;
        while (time <= 3)
        {
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(transform.position, direction);
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(transform.position, secondaryDirection);
            yield return new WaitForSeconds(0.4f);
            secondaryDirection.x -= 0.2f;
            direction.x += 0.2f;
            time += 0.2f;
        }

        while (time <= 3)
        {
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(transform.position, direction);
            yield return new WaitForSeconds(0.01f);
            realTrigger.Fire(transform.position, secondaryDirection);
            yield return new WaitForSeconds(0.4f);
            secondaryDirection.x += 0.2f;
            direction.x -= 0.2f;
            time += 0.2f;
        }


        StartCoroutine(StartShottingCycle());
    }

    public override void OnDestroy()
    {
        StopAllCoroutines();
        powerUps.SetActive(true);
        powerUps.transform.position = transform.position;
        source.PlayOneShot(clip);
        base.OnDestroy();
    }
}
