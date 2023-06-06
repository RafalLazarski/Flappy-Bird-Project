using UnityEngine;

namespace FlappyBird.Core
{
	public class GameState : BaseState
	{
        public Score Score = new Score();
        private bool isFirstStart;

        public GameState(bool isFirstStart)
        {
            this.isFirstStart = isFirstStart;
        }

        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);
            Score.LoadScore();
            gameController.TriggerHandler.IsGameLost += CheckGameStatus;
            gameController.PlayerController.Init();
            gameController.ObstaclesController.Init();

            if(isFirstStart)
            {
                gameController.GameView.HideView();
                gameController.MenuView.ShowView();
            }
            else
            {
                gameController.GameView.ShowView();
                gameController.MenuView.HideView();
            }
            gameController.ResetButtonInGame.
                onClick.AddListener(StartNewGame);
            gameController.ResetButtonInMenu.
                onClick.AddListener(StartNewGame);
        }

        public override void DestroyState()
        {
            base.DestroyState();
            Score.SaveScore();
            gameController.TriggerHandler.ClearAllInputs();
            gameController.PlayerController.Dispose();
            gameController.ObstaclesController.Dispose();
            gameController.GameView.HideView();
            gameController.ResetButtonInGame.
                onClick.RemoveAllListeners();
            gameController.ResetButtonInMenu.
                onClick.RemoveAllListeners(); 
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            gameController.PlayerController.
                FixedUpdatePosition();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            gameController.PlayerController.UpdatePosition();
            gameController.GameView.UpdateScore(Score);
            gameController.MenuView.UpdateScore(Score);
        }

        public override void StartNewGame()
        {
            gameController.ChangeState(new MenuState(Score));
        }

        public void CheckGameStatus(bool isLost)
        {
            if (isLost)
            {
                StartNewGame();
            }
            else
            {
                Score.IncreaseScore();
            }
        }
    } 
}
