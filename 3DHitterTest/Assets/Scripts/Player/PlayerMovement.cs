using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] List<Transform> pointsTransforms;
    [SerializeField] float sphereCastRadius;
    private IPlayerState _currentState;
    private int currentPointIndex;
    private Animator animator;
    public NavMeshAgent navMeshAgent;
    public bool canMove;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        ChangeState(new IdleState()); 
    }

    void Update()
    {
        _currentState?.Update();

        if (Input.GetMouseButtonDown(0))
        {
            canMove = true;
        }
    }

    public void Move()
    {
        if (canMove && !EnemyChecker.Instance.AreEnemiesActive())
        {
            navMeshAgent.SetDestination(pointsTransforms[currentPointIndex].position);
            CheckPoint();
        }
        Debug.Log(canMove);
    }

    private void CheckPoint()
    {
        RaycastHit hit;
        Vector3 direction = navMeshAgent.destination - transform.position;
        if (Physics.SphereCast(transform.position, sphereCastRadius, direction.normalized, out hit, direction.magnitude) && canMove)
        {
            if (hit.collider.CompareTag("Point Trigger"))
            {
                canMove = false;
                currentPointIndex++;

                var enemyPointActivator = hit.collider.GetComponent<EnemyPointActivater>();
                if (enemyPointActivator != null)
                {
                if (enemyPointActivator.enemys.Count > 0)
                    {
                        enemyPointActivator.EnableEnemys();
                        enemyPointActivator.gameObject.SetActive(false);
                    }
                }
            }
            if (hit.collider.CompareTag("Finish"))
            {
                canMove = false;
                currentPointIndex = 0;
                LevelManager.RestartLevel();
            }
        }
    }

    public void ChangeState(IPlayerState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter(this);
    }

    public void SetAnimationState(bool isWalking)
    {
        animator.SetBool("isWalk", isWalking);
    }

    public EnemyChecker EnemyChecker => EnemyChecker.Instance;
}
