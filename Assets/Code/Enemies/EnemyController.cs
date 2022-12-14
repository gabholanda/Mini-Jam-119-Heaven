using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected GameObject player;

    private float distance;
    public CharacterStats characterStats;
    [SerializeField]
    private AbilityTrigger trigger;
    protected AbilityTrigger realTrigger;

    public bool canSpawn = true;

    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterStats = GetComponent<CharacterStats>();
        realTrigger = ScriptableObject.CreateInstance<AbilityTrigger>();
        realTrigger.DeepCopy(trigger);
        realTrigger.Initialize(gameObject);
    }

    void Update()
    {
        if (player)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            if (distance >= 2f)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, characterStats.Speed * Time.deltaTime);
            }
            if (distance <= 2f)
            {
                OnAttack();
            }
        }
    }
    private void OnAttack()
    {
        realTrigger.Fire(player.transform.position, new Vector2(0, 0));
    }

    public virtual void OnDestroy()
    {
        if (canSpawn && GetComponent<LootBag>() != null)
        {
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
    }

    private void OnApplicationQuit()
    {
        canSpawn = false;
    }

}

