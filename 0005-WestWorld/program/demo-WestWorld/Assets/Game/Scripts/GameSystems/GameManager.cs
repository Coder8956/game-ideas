using UGU.Runtime;

public class GameManager : UGUBaseGameSystem<GameManager>
{
    protected override void OnInitialize()
    {
        gameObject.AddComponent<UGUFSM>();
    }
}