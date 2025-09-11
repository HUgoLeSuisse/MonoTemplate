﻿using BuildAndDestroy.GameComponents.Utils;
using Microsoft.Xna.Framework;
using System;

namespace Monotemplate.Utils.Time
{
    /// <summary>
    /// Permet lancer un minuteur qui active un event quand il a fini
    /// </summary>
    public class Cooldown 
    {

        private float maxTime;
        private float currentTime;
        private bool isEnable = false;

        /// <summary>
        /// Temps de fin du cooldown
        /// </summary>
        public float MaxTime
        {
            get { return maxTime; }
        }

        /// <summary>
        /// Temps écoulé depuis le depuis du cooldown
        /// </summary>
        public float CurrentTime
        {
            get { return currentTime; }
        }


        /// <summary>
        /// Est ce que le cooldown est actif
        /// </summary>
        public bool IsEnable
        {
            get { return isEnable; }
        }

        public delegate void EndTimer();
        /// <summary>
        /// s'Active quand le temps voulu s'est écoulé
        /// </summary>
        public EndTimer endCooldown;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time">Temps à écouler</param>
        public Cooldown(float time)
        {
            maxTime = time;
            currentTime = time;
            UpdateEvents.Instance.Update += Update;
        }

        private void Update(GameTime gameTime)
        {
            if (isEnable) {
                currentTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (currentTime < 0) {
                if (isEnable)
                {
                    endCooldown?.Invoke();
                    Stop();
                }
            }

        }
        /// <summary>
        /// Retourn le temps restant
        /// </summary>
        /// <returns>Temps acctuel</returns>
        public float GetTime()
        {
            return currentTime;
        }

        /// <summary>
        /// Arrete le minuteur
        /// </summary>
        public void Stop()
        {
            isEnable = false;
        }

        /// <summary>
        /// Démarre le minuteur
        /// </summary>
        public void Start()
        {
            isEnable = true;
        }

        public void Destroy()
        {
            UpdateEvents.Instance.Update -= Update;
            endCooldown = null;
        }
    }
}
