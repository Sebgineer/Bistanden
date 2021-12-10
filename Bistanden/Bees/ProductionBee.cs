using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bistanden
{
    /// <summary>
    /// Production Bee is Producing the honey in its house
    /// </summary>
    public class ProductionBee : Bee
    {
        int honeyStash;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="house"></param>
        public ProductionBee(BeeHouse house) : base(house)
        {

        }

        /// <summary>
        /// Start the production of the Honey
        /// </summary>
        public override void Start()
        {
            while (true)
            {
                //takes nektar from home
                this.stash = this.TakeNektar();
                //making honey
                this.MakeHoney();
                //Stash The Honey

                //TakeBreak
            }
        }

        /// <summary>
        /// Take up to 3 nektar, if possible
        /// </summary>
        /// <returns>returns up to 3 nektar</returns>
        private int TakeNektar()
        {
            bool finish = false;
            int result = 0;
            while (!finish)
            {
                lock(this.home)
                {
                    try
                    {
                        result = this.home.TakeNektarFromStash();
                        if (result > 0)
                        {
                            finish = true;
                        }
                    }
                    finally
                    {
                        Monitor.Pulse(this.home);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Makes the nektar to honey
        /// </summary>
        private void MakeHoney()
        {
            this.honeyStash = this.stash;
            this.stash = 0;
        }

        /// <summary>
        /// Stash The Honey to home | not finnished
        /// </summary>
        private void StashHoney()
        {
            bool finish = false;
            int result = 0;
            while (!finish)
            {
                lock (this.home)
                {
                    try
                    {
                        result = this.home.TakeNektarFromStash();
                        if (result > 0)
                        {
                            finish = true;
                        }
                    }
                    finally
                    {
                        Monitor.Pulse(this.home);
                    }
                }
            }
        }
    }
}
