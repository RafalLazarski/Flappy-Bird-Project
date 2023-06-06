using FlappyBird.Player;
using UnityEngine;
using FlappyBird.Obstacles;
using FlappyBird.UI;
using UnityEngine.UI;

namespace FlappyBird.Core
{
    public class GameController : MonoBehaviour
    {
        private BaseState currentState;

        [SerializeField]
        private PlayerController playerController;
        public PlayerController PlayerController => playerController;

        [SerializeField]
        private PlayerTriggerHandler triggerHandler;
        public PlayerTriggerHandler TriggerHandler => triggerHandler;

        [SerializeField]
        private ObstaclesController obstaclesController;
        public ObstaclesController ObstaclesController => obstaclesController;

        [SerializeField]
        private GameView gameView;
        public GameView GameView => gameView;

        [SerializeField]
        private MenuView menuView;
        public MenuView MenuView => menuView;

        [SerializeField]
        private Button playButton;
        public Button PlayButton => playButton;

        [SerializeField]
        private Button resetButtonInGame;
        public Button ResetButtonInGame => resetButtonInGame;

        [SerializeField]
        private Button resetButtonInMenu;
        public Button ResetButtonInMenu => resetButtonInMenu;

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

        }

        public void ChangeState(BaseState newState)
        {
            currentState?.DestroyState();
            currentState = newState;
            currentState?.InitState(this);
        }
    }
}
