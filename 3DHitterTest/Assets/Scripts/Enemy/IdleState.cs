using UnityEngine;

public class IdleState : IPlayerState
{
    private PlayerMovement _player;

    public void Enter(PlayerMovement player)
    {
        _player = player;
       
        _player.SetAnimationState(false); 
        _player.navMeshAgent.isStopped = true;
    }

    public void Update()
    {
        if (!_player.EnemyChecker.AreEnemiesActive() &&  _player.canMove)
        {
            _player.ChangeState(new WalkState()); 
        }
    }

    public void Exit()
    {
       
    }
}
