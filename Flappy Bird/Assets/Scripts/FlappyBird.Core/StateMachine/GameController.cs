using FlappyBird.Player;
using UnityEngine;

namespace FlappyBird.Core
{
	public class GameController : MonoBehaviour
	{
        private BaseState currentState;

        [SerializeField]
        private PlayerController playerController;
        public PlayerController PlayerController => playerController;

        private void Start()
        {
            ChangeState(new GameState());
        }

        private void Update()
        {
            currentState?.UpdateState();
        }

        private void FixedUpdate()
        {
            currentState?.FixedUpdateState();
        }

        private void OnDestroy()
        {
            // ChangeState(null);
            // some method to save game before shut down
        }

        public void ChangeState(BaseState newState)
        {
            currentState?.DestroyState();
            currentState = newState;
            currentState?.InitState(this);
        }
    }
}
