using UnityEngine;

namespace FlappyBird.Core
{
	public class GameState : BaseState
	{
        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);
            gameController.PlayerController.Init();
        }

        public override void DestroyState()
        {
            gameController.PlayerController.Dispose();
        }

        public override void FixedUpdateState()
        {
            gameController.PlayerController.FixedUpdatePosition();
        }

        public override void UpdateState()
        {
            gameController.PlayerController.UpdatePosition();
        }
    } 
}
