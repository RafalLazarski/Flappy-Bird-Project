using UnityEngine;

namespace FlappyBird.Obstacles
{
    public class ObstacleMovement : MonoBehaviour, IObstacle
    {
        [SerializeField]
        private float speed = 5f;
        [SerializeField]
        private float spawnPositionX = 10;
        [SerializeField]
        private float spawnPositionYRange = 3;
        [SerializeField]
        private Rigidbody2D obstacleRB;


        public ObstaclesController Controller { get; set; }

        public bool isActive { get; set; }

        public ObstacleMovement()
        {
            isActive = false;
        }

        public void Init()
        {
            gameObject.SetActive(true);
            isActive = true;

            transform.position = new Vector2(spawnPositionX, Random.Range(-spawnPositionYRange, spawnPositionYRange));

            obstacleRB.velocity = Vector2.left * speed;
        }

        public void Dispose()
        {
            gameObject.SetActive(false);
        }
    } 
}
