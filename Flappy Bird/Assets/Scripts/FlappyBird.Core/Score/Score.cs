using UnityEngine;

namespace FlappyBird.Core
{
    public class Score
    {
        public int score;

        public Score()
        {
            score = 0;
        }

        public void IncreaseScore()
        {
            score++;
            Debug.Log("Your score: " + score);
        }
    }
}
