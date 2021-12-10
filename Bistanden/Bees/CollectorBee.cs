using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bistanden
{
    /// <summary>
    /// Collector Bee is a bee that collect the Nektar from flower
    /// </summary>
    public class CollectorBee : Bee
    {
        /// <summary>
        /// CollectorBee Collect Nektar to the Bee House;
        /// </summary>
        /// <param name="house">The Home of bee</param>
        public CollectorBee(BeeHouse house) : base(house)
        {

        }

        /// <summary>
        /// Starts the bee to collect nektar
        /// </summary>
        public override void Start()
        {
            while (true)
            {
                //flyes to find nektar
                this.Fly();
                
                //Collect the Nektar from flower
                this.CollectNektar();

                //Takes a break
                this.TakeBreak();

                //returns the Nektar to the House
                this.ReturnNektar();
                Console.WriteLine($"{Thread.CurrentThread.Name} Finnished a Route");

                //takes a breake before it begins again
                this.TakeBreak();
            }
        }

        /// <summary>
        /// Collects Nektar from a flower
        /// </summary>
        public void CollectNektar()
        {
            Flower flower = new Flower();

            this.stash = flower.TakeNektar();

        }

        /// <summary>
        /// Returns the nektar to the bee house
        /// </summary>
        private void ReturnNektar()
        {
            bool Finish = false;
            while (!Finish)
            {

                lock(this.home)
                {
                    try
                    {
                        this.home.StashTheNektar(this.GiveNektar());
                        Finish = true;
                    }
                    finally
                    {
                        Monitor.Pulse(this.home);
                    }
                }
            }
        }

        /// <summary>
        /// Give the nektar from the bee
        /// </summary>
        /// <returns>the nektar the bee have</returns>
        private int GiveNektar()
        {
            int result = this.stash;
            this.stash = 0;
            return result;
        }
    }
}
