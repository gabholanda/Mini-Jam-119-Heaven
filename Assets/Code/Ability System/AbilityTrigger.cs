using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Trigger", menuName = "Scriptable Objects/Ability System/Ability Trigger")]
public class AbilityTrigger : ScriptableObject
{
    public GameObject caster;
    public GameObject prefab;
    public AbilityData data;

    public void Initialize(GameObject _caster)
    {
        caster = _caster;
    }

    public void Fire(Vector2 position, Vector2 direction)
    {
        if (!data.isCoolingDown)
        {
            if (data.isProjectile)
            {
                FireProjectile(position, direction);
            }
            else if (data.isBoundToCaster)
            {
                FireBoundToCaster();
            }
            data.isCoolingDown = true;
            caster.GetComponent<CoroutineRunner>().StartCoroutine(StartCooldown());
        }
    }

    private void FireProjectile(Vector2 position, Vector2 direction)
    {
        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        Ability ability = obj.GetComponent<Ability>();
        ability.direction = direction;
        SetGeneralAttributes(ability);
    }

    private void FireBoundToCaster()
    {
        GameObject obj = Instantiate(prefab, caster.transform);
        Ability ability = obj.GetComponent<Ability>();
        SetGeneralAttributes(ability);
    }

    private void SetGeneralAttributes(Ability ability)
    {
        ability.caster = caster;
        ability.data = data;
    }

    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(data.cooldownDuration);
        data.isCoolingDown = false;
    }
}
