using FlappyBird.Core;
using TMPro;
using UnityEngine;

namespace FlappyBird.UI
{
	public class GameView : BaseView
	{

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
	} 
}
