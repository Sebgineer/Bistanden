using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistanden
{
    /// <summary>
    /// Flower Is Used by the Bees to get Nektar
    /// </summary>
    public class Flower
    {
        /// <summary>
        /// The number of Nektar
        /// </summary>
        private int nektar;

        /// <summary>
        /// See how many Nektar there is in the Flower.
        /// </summary>
        public int NumberOfNektar { get { return this.nektar; } }

        /// <summary>
        /// When Created its makes nektar from 1 to 3 Random
        /// </summary>
        public Flower()
        {
            Random rnd = new Random();
            this.nektar = rnd.Next(1, 3);
        }

        /// <summary>
        /// Create A Flower, Where you says how many nektar is in it.
        /// </summary>
        /// <param name="nektar">The Amount of Nektar The Flower gonna have</param>
        public Flower(int nektar)
        {
            this.nektar = nektar;
        }

        /// <summary>
        /// Take the Nektar the Flower have.
        /// </summary>
        /// <returns>Returns the Nektar the flower have</returns>
        public int TakeNektar()
        {
            int result = this.nektar;
            this.nektar = 0;
            return result;
        }
    }
}
