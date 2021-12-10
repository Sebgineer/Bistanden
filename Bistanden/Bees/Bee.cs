using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bistanden
{
    public abstract class Bee
    {
        protected int stash;
        protected BeeHouse home;

        /// <summary>
        /// Create a bee
        /// </summary>
        /// <param name="house">Home of the Bee</param>
        public Bee(BeeHouse house)
        {
            this.home = house;
        }

        public abstract void Start();

        /// <summary>
        /// The Bee will Fly in a little while.
        /// </summary>
        protected void Fly()
        {
            this.TakeBreak(100, 300);
        }

        /// <summary>
        /// Take a break from 100 to 500 ms
        /// </summary>
        protected void TakeBreak()
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(100, 500));
        }

        /// <summary>
        /// Take a break from min to max ms
        /// </summary>
        /// <param name="min">minium time</param>
        /// <param name="max">maximum time</param>
        protected void TakeBreak(int min, int max)
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(min, max));
        }

        /// <summary>
        /// Take a break in time ms
        /// </summary>
        /// <param name="time">the time of break</param>
        protected void TakeBreak(int time)
        {
            Thread.Sleep(time);
        }
    }
}
