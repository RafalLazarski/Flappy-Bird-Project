using UnityEngine;

namespace FlappyBird.Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody2D playerRB;
        [SerializeField]
        private float force = 5.0f;
        [SerializeField]
        private float yRange = 5.7f;
        [SerializeField]
        private float maxSpeed = 10.0f;

		public void Init()
		{
			gameObject.SetActive(true);
            playerRB.position = Vector2.zero;
        }

        public void UpdatePosition()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRB.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }

            // TODO: it should be changed for trigger listeners
            if (playerRB.position.y > yRange
                || playerRB.position.y < -yRange)
            {
                playerRB.position = new Vector2(playerRB.position.x,
                    playerRB.position.y > 0 ? -yRange : yRange);
            }
        }

        public void FixedUpdatePosition()
		{
            var yVelocity = playerRB.velocity.y;
            var direction = Mathf.Sign(yVelocity);

            yVelocity = Mathf.Abs(yVelocity);
            yVelocity = Mathf.Clamp(yVelocity, 0, maxSpeed);

            Vector2 finalVelocity = new Vector2(playerRB.velocity.x, yVelocity * direction);
            playerRB.velocity = finalVelocity;
		}
        
        public void Dispose()
        {
            gameObject.SetActive(false);
        }
    }
}
