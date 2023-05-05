using UnityEngine;

namespace FlappyBird.Core
{
	public class GameState : BaseState
	{
        public Score currentScore;

        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);
            gameController.PlayerController.Init();
            gameController.TriggerHandler.IsGameLost += CheckGameStatus;
            gameController.ObstaclesController.Init();
            gameController.GameView.ShowView();
            gameController.ResetButtonInGame.
                onClick.AddListener(StartNewGame);
            gameController.ResetButtonInMenu.
                onClick.AddListener(StartNewGame);
        }

        public override void DestroyState()
        {
            gameController.PlayerController.Dispose();
            gameController.ObstaclesController.Dispose();
            gameController.GameView.HideView();
            gameController.TriggerHandler.ClearAllInputs();
            gameController.ResetButtonInGame.
                onClick.RemoveAllListeners();
            gameController.ResetButtonInMenu.
                onClick.RemoveAllListeners(); 
        }

        public override void FixedUpdateState()
        {
            gameController.PlayerController.
                FixedUpdatePosition();
        }

        public override void UpdateState()
        {
            gameController.PlayerController.UpdatePosition();
        }

        public void CheckGameStatus(bool isLost)
        {
             if (isLost)
            {
                StartNewGame();
            }
            else
            {
                currentScore.IncreaseScore();
            }
        }

        public void StartNewGame()
        {
            gameController.ChangeState(new MenuState());
        }
    } 
}
