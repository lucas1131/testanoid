public interface IGameConfig
{
    float BallMaxSpeed { get; }
    float BallMinSpeed { get; }
    float PlayerSpeed { get; }
    uint Lives { get; }
}
