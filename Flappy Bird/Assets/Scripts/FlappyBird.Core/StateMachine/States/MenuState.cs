using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird.Core
{
    public class MenuState : BaseState
    {
        public Score score;

        public MenuState(Score score)
        {
            this.score = score;
        }

        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);
            gameController.MenuView.ShowView();
            gameController.PlayButton.
                onClick.AddListener(StartNewGame);
            gameController.ResetButtonInMenu.
                onClick.AddListener(StartNewGame);
            gameController.MenuView.UpdateScore(score);
        }

        public override void DestroyState()
        {
            base.DestroyState();
            gameController.MenuView.HideView();
            gameController.PlayButton.
                onClick.RemoveAllListeners();
            gameController.ResetButtonInMenu.
                onClick.RemoveAllListeners();
        }

        public override void StartNewGame()
        {
            gameController.ChangeState(new GameState(false));
        }
    }
}
