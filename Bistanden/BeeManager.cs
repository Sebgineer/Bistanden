using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bistanden
{
    public class BeeManager
    {
        private List<Bee> bees;
        private BeeHouse house;

        public int AmountOfBees { get { return this.bees.Count; } }


        public BeeManager()
        {
            this.house = new BeeHouse();
            this.bees = this.CreateBees(60, this.house);
        }

        /// <summary>
        /// Start the hole Production
        /// </summary>
        public void Start()
        {
            this.StartBees();
        }

        /// <summary>
        /// Creates the bees
        /// </summary>
        /// <param name="numberOfBees">How many bees should be created</param>
        /// <param name="house">House of Bees</param>
        /// <returns>List of all Bees</returns>
        private List<Bee> CreateBees(int numberOfBees, BeeHouse house)
        {
            int oneOfThree = numberOfBees / 3;
            List<Bee> bees = new List<Bee>();

            for (int i = 0; i < oneOfThree + oneOfThree; i++)
            {
                bees.Add(new CollectorBee(house));
            }

            for (int i = 0; i < oneOfThree; i++)
            {
                bees.Add(new ProductionBee(house));
            }

            return bees;
        }

        /// <summary>
        /// Starts the Bees production
        /// </summary>
        private void StartBees()
        {
            for (int i = 0; i < this.bees.Count; i++)
            {
                Thread thread = new Thread(this.bees[i].Start);
                thread.Name = $"Bee{i}";
                thread.Start();
            }
        }
    }
}
