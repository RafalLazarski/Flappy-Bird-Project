using UnityEngine;

public interface IObstacle
{
	bool isActive { get; set; }
	void Init();
	void Dispose();
}
