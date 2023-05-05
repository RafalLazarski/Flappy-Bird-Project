using FlappyBird.Core;
using System;

namespace FlappyBird.SystemSave
{
	[Serializable]
	public class PlayerData
	{
		public int Score;

		public PlayerData(Score score)
		{
			Score = score.BestScore;
		}
	} 
}
