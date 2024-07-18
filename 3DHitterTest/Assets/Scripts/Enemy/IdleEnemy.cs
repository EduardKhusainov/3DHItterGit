using UnityEngine;
using UnityEngine.AI;

public class IdleEnemy : Enemy, IDamageble
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] bool canMove;
    [SerializeField] GameObject healthBar;
    private void OnEnable()
    {
        if(EnemyChecker.Instance != null)
        EnemyChecker.Instance.AddEnemy(gameObject);
    }
    private void Start()
    {
        currentHealth = maxHealth;
        transform.LookAt(player);
        currentHealth = maxHealth;
        if(canMove)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            if(player == null)
            {
               player = FindAnyObjectByType<Player>().transform;
            }
        }
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (player != null)
        {
            navMeshAgent.speed = speed;
            navMeshAgent.SetDestination(player.position);
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }


    private void OnDisable()
    {
        if(EnemyChecker.Instance != null)
        EnemyChecker.Instance.RemoveEnemy(gameObject);
    }
}
