using FlappyBird.SystemSave;
using System;
using UnityEngine;

namespace FlappyBird.Core
{
    public class Score
    {
        private int currentScore;
        public int CurrentScore => currentScore;

        private int bestScore;
        public int BestScore => bestScore;

        public Score()
        {
            currentScore = 0;
        }

        public void IncreaseScore()
        {
            currentScore++;
            if(currentScore >= bestScore)
            {
                bestScore = currentScore;
            }
        }

        public void SaveScore()
        {
            SaveSystem.SaveData(this);
        }

        public void LoadScore()
        {
            PlayerData data = SaveSystem.LoadData();
            try
            {
                bestScore = data.Score;
            }
            catch(NullReferenceException e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}
