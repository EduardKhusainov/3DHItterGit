using UnityEngine;

public class WalkState : IPlayerState
{
    private PlayerMovement _player;

    public void Enter(PlayerMovement player)
    {
        _player = player;
        
        _player.SetAnimationState(true); 
        _player.navMeshAgent.isStopped = false;
    }

    public void Update()
    {
        if (_player.canMove && !_player.EnemyChecker.AreEnemiesActive())
        {
            _player.Move();
        }
        else
        {
            _player.ChangeState(new IdleState()); 
        }
    }

    public void Exit()
    {
        _player.SetAnimationState(false); 
    }
}
