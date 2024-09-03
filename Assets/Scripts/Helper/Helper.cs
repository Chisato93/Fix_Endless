public class Tags
{
    public const string PLAYER = "Player";
    public const string ENDING = "EndingTimeLine";
}

public class AxisTag
{
    public const string HORIZONTAL = "Horizontal";
}

public enum FloorType
{
    NONE,
    FLOOR,
    HEIGHT,
    CORNER,
    START_FLOOR,
};

public class SceneName
{
    public const string MAIN_SCENE = "MainScene";
    public const string GAME_SCENE = "GameScene";
}

public enum ItemType
{
    COIN,
    ROCK,
    OXYGEN,

    TOTAL,
}