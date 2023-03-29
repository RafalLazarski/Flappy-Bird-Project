using UnityEngine;

namespace FlappyBird.Core
{
	public class GameState : BaseState
	{
        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);
            gameController.PlayerController.Init();
            gameController.ObstaclesController.Init();
        }

        public override void DestroyState()
        {
            gameController.PlayerController.Dispose();
            gameController.ObstaclesController.Dispose();
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
