using UnityEngine.AI;

public class GameUtils
{
    public static bool IsNavMeshAgentArrived(NavMeshAgent agent)
    {
        if (agent.pathPending)
            return false;

        if (!agent.isOnNavMesh)
            return false;

        if (agent.pathStatus != NavMeshPathStatus.PathComplete)
            return false;

        if (agent.remainingDistance > agent.stoppingDistance)
            return false;

        return !agent.hasPath
               || agent.velocity.sqrMagnitude < 0.01f;
    }
}