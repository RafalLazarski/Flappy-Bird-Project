using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird.Core
{
    public class MenuState : BaseState
    {
        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);
            gameController.MenuView.ShowView();
            gameController.PlayButton.
                onClick.AddListener(StartNewGame);
            gameController.ResetButtonInMenu.
                onClick.AddListener(StartNewGame);
        }

        public override void DestroyState()
        {
            gameController.MenuView.HideView();
            gameController.PlayButton.
                onClick.RemoveAllListeners();
            gameController.ResetButtonInMenu.
                onClick.RemoveAllListeners();
        }

        public override void FixedUpdateState()
        {

        }

        public override void UpdateState()
        {

        }

        public void StartNewGame()
        {
            gameController.ChangeState(new GameState());
        }
    }
}
