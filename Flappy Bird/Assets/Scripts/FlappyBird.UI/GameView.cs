using FlappyBird.Core;
using TMPro;
using UnityEngine;

namespace FlappyBird.UI
{
	public class GameView : BaseView
	{
		[SerializeField]
		private TextMeshProUGUI scoreInfo;

		public override void ShowView()
		{
			base.ShowView();
            Time.timeScale = 1;
        }

		public override void HideView()
		{
			base.HideView();
            Time.timeScale = 0;
        }

		public void UpdateScore(Score score)
		{
			scoreInfo.text = $"Best Score: {score.BestScore}\nCurrent Score: {score.CurrentScore}";
        }
	} 
}
