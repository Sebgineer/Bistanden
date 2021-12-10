using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistanden
{
    /// <summary>
    /// The Home of many Bees
    /// </summary>
    public class BeeHouse
    {
        private int nektarStash;
        private int HoneyStash;

        /// <summary>
        /// See the Amount of Nektar in the stash
        /// </summary>
        public int NektarStash { get { return this.nektarStash; } }

        /// <summary>
        /// Put Nektar in the Stash
        /// </summary>
        /// <param name="nektar">the amount of nektar to stash</param>
        public void StashTheNektar(int nektar)
        {
            this.nektarStash += nektar;
        }

        /// <summary>
        /// Take up to 3 nektar if possible
        /// </summary>
        /// <returns>returns up to 3</returns>
        public int TakeNektarFromStash()
        {
            int result;
            if (this.nektarStash >= 3)
            {
                result = 3;
                this.nektarStash -= 3;
            }
            else
            {
                result = this.nektarStash;
                this.nektarStash = 0;
            }
            return result;
        }

        /// <summary>
        /// Take The Amount Nektar you choose to take
        /// </summary>
        /// <param name="amount">The amount of youre choice</param>
        /// <returns>returns the choice of nektar</returns>
        public int TakeNektarFromStash(int hamount)
        {
            return 0;
        }
    }
}
