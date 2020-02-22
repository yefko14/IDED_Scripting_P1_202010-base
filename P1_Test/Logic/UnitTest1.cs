using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDED_Scripting_P1_202010_base.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDED_Scripting_P1_202010_base.Logic.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        #region TestUnits_Humans

        private Human Jane = new Human(EUnitClass.Villager, 10, 10, 40, 10);

        #endregion TestUnits_Humans

        #region TestUnits_Monsters

        private Unit redImp = new Unit(EUnitClass.Imp, 100, 20, 40);

        #endregion TestUnits_Monsters

        /* Test cases:
         * - Villager with combat params
         * - Villager can interact with other units
         * - Villager with atk range
         * - Other than villagers can interact with props.
         * - Units with params outside caps.
         * - Units' final parameters with class adds.
         * - Villager can change class
         * - Interaction table
         * - Move test
         */

        [TestMethod()]
        public void UnitTest()
        {

        }

        [TestMethod()]
        public void InteractTest()
        {

        }

        [TestMethod()]
        public void InteractTest1()
        {

        }
    }
}