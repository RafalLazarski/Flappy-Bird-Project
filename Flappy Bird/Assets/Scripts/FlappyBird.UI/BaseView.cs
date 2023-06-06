using TMPro;
using UnityEngine;
using FlappyBird.Core;

namespace FlappyBird.UI
{
	public class BaseView : MonoBehaviour
	{
        [SerializeField]
        protected TextMeshProUGUI scoreInfo;

        public virtual void ShowView()
		{
			gameObject.SetActive(true);
		}

		public virtual void HideView()
		{
			gameObject.SetActive(false);
		}

        public virtual void UpdateScore(Score score)
        {
            scoreInfo.text = $"Best Score: {score.BestScore}\nCurrent Score: {score.CurrentScore}";
        }
    } 
}
