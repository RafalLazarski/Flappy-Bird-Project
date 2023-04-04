using FlappyBird.Obstacles;
using UnityEngine;

public interface IObstacle
{
    ObstaclesController Controller { get; set; }
    bool isActive { get; set; }
	void Init();
	void Dispose();
}
