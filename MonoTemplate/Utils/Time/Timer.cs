using BuildAndDestroy.GameComponents.Utils;
using Microsoft.Xna.Framework;
using Monotemplate.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Monotemplate.Utils.Time.Cooldown;

namespace Monotemplate.Utils.Time
{
    /// <summary>
    /// Permet de compter le temps passé depuis la création de l'instance
    /// </summary>
    public class Timer : ICleanable
    {
        private float time;
        public float Time { get { return time; } set { time = value; } }
        public Timer()
        {
            UpdateEvents.Instance.Update += Update;
        }
        private void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void Destroy()
        {
            UpdateEvents.Instance.Update -= Update;
        }
    }
}
