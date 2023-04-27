using System.Collections;
using UnityEngine;

namespace FlappyBird.Obstacles
{
	public class ObstaclesController : MonoBehaviour
	{
		[SerializeField]
		private int obstaclesCount = 3;
		[SerializeField]
		private GameObject obstaclePrefab;
		[SerializeField]
		private float waitingTime = 1.3f;

		private IObstacle[] obstaclesPool;

		public void Init()
		{
			gameObject.SetActive(true);
			obstaclesPool = new IObstacle[obstaclesCount];
			for (int i = 0; i < obstaclesCount; i++)
			{
				var obstacleGameObj = Instantiate(obstaclePrefab, transform.parent);
				obstacleGameObj.SetActive(false);
				obstaclesPool[i] = obstacleGameObj.GetComponent(typeof(IObstacle)) as IObstacle;

				obstaclesPool[i].Controller = this;
			}

			StartCoroutine(InfiniteLoop(0));
		}

		public void Dispose()
		{
			for (int i = 0; i < obstaclesCount; i++)
			{
				obstaclesPool[i].Dispose();
			}
			gameObject.SetActive(false);
		}

		private IEnumerator InfiniteLoop(int i)
		{
			while (true)
			{
				if (obstaclesPool[i].isActive)
				{
					i++;
				}
				if (i >= obstaclesCount)
				{
					i = 0;
				}
				obstaclesPool[i].Init();
				yield return new WaitForSeconds(waitingTime);
			}
		}
	} 
}
