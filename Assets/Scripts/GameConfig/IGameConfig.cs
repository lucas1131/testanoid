public interface IGameConfig
{
    float BallMaxSpeed { get; }
    float BallMinSpeed { get; }
    float BallAngleMin { get; }
    float BallAngleMax { get; }
    float PlayerSpeed { get; }
    uint Lives { get; }
}
