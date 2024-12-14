using System.Collections.Generic;
using UnityEngine;
using EnemyStateMashine;

public class PlayerInitializer : MonoBehaviour
{
    public PlayerBehaviour Initialize(PlayerBehaviour player)
    {
        List<IState> playerStates = new List<IState>
        {
            new PlayerIdleState(player),
            new PlayerMoveState(player),
            new PlayerCollectingState(player)
        };

        EntityStateMachine playerStateMashine = new EntityStateMachine(playerStates);

        foreach (IState state in playerStates)
        {
            state.Initialize(playerStateMashine);
        }

        player.Construct(playerStateMashine);

        return player;
    }
}
