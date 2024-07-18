using UnityEngine;

public interface IPlayerState
{
    public void Exit();
    void Enter(PlayerMovement player); 
    void Update(); 
}
