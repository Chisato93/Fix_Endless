public interface IGameState
{
    void EnterState(GameManager gameManager);
    void Update(GameManager gameManager);
    void ExitState(GameManager gameManager);
}

public class MainState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        // 메인에 왔을때 처리
    }

    public void Update(GameManager gameManager)
    {
        // 메인에서 계속해서 진행될 처리
    }

    public void ExitState(GameManager gameManager)
    {
        // 메인에서 빠져나갈때 처리
    }
}

public class GameState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        // 게임 입장 후 로직
    }

    public void Update(GameManager gameManager)
    {
        // 게임 오버 상태에서 로직 처리
    }

    public void ExitState(GameManager gameManager)
    {
        // 게임 나오면서 로직
    }
}
