using System;
using UnityEngine;

namespace FlappyBird.Player
{
    public class PlayerTriggerHandler : MonoBehaviour
    {
        public Action<bool> IsGameLost;

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Finish")
            {
                IsGameLost?.Invoke(true);
            }
             else if (collision.tag == "Score")
            {
                IsGameLost?.Invoke(false);
            }
        }

        public void ClearAllInputs()
        {
            IsGameLost = null;
        }
    } 
}
