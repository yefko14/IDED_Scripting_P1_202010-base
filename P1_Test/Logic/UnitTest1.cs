using IDED_Scripting_P1_202010_base.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P1_Test.Logic
{
    [TestClass()]
    public class UnitTest1
    {
        #region TestUnits_Humans

        // Villager with combat params.
        private Human jane = new Human(EUnitClass.Villager, 10, 10, 40, 10, 10);

        // Mage
        private Human benedict = new Human(EUnitClass.Mage, 10, 10, 40, 10, 10);

        // Ranger
        private Human fawn = new Human(EUnitClass.Ranger, 10, 10, 40, 10, 10);

        // Squire
        private Human ramza = new Human(EUnitClass.Squire, 10, 10, 40, 10, 10);

        // Soldier
        private Human cloud = new Human(EUnitClass.Soldier, 10, 10, 40, 10, 10);

        #endregion TestUnits_Humans

        #region TestUnits_Monsters

        // Imp
        private Unit redImp = new Unit(EUnitClass.Imp, 100, 20, 40, 10);

        // Orc
        private Unit ogremon = new Unit(EUnitClass.Orc, 100, 20, 40, 10);

        // Dragon
        private Unit shinryu = new Unit(EUnitClass.Dragon, 100, 20, 40, 10);

        // Custom dragon with exceed params
        private Unit omegaWeapon = new Unit(EUnitClass.Dragon, 255, 255, 255, 100);

        #endregion TestUnits_Monsters

        #region TestMethods

        [TestMethod()]
        public void UnitCreationTest()
        {
            // Villager can't have combat params.
            Assert.AreEqual(jane.Attack, 0);
            Assert.AreEqual(jane.Defense, 0);
            Assert.AreEqual(jane.AtkRange, 0);

            // Units cap their stats correctly
            Assert.AreEqual(omegaWeapon.BaseAtk, 255);
            Assert.AreEqual(omegaWeapon.Attack, 255);
            Assert.AreEqual(omegaWeapon.BaseDef, 255);
            Assert.AreEqual(omegaWeapon.Defense, 255);
            Assert.AreEqual(omegaWeapon.BaseSpd, 255);
            Assert.AreEqual(omegaWeapon.Speed, 255);
            Assert.AreEqual(omegaWeapon.MoveRange, 10);
        }

        [TestMethod()]
        public void UnitInteractionTest()
        {
            Prop chest = new Prop(EPropType.Chest);

            // Villager can interact with props.
            Assert.AreEqual(jane.Interact(chest), true);

            // Other than villagers can't interact with props
            Assert.AreEqual(benedict.Interact(chest), false);
            Assert.AreEqual(cloud.Interact(chest), false);
            Assert.AreEqual(shinryu.Interact(chest), false);

            // Villager can't interact with other villagers.
            Assert.AreEqual(jane.Interact(jane.Copy()), false);

            // Villager can't interact with non-villager humans.
            Assert.AreEqual(jane.Interact(ramza), false);
            Assert.AreEqual(jane.Interact(cloud), false);
            Assert.AreEqual(jane.Interact(fawn), false);
            Assert.AreEqual(jane.Interact(benedict), false);

            // Villager can't interact with monsters
            Assert.AreEqual(jane.Interact(ogremon), false);
            Assert.AreEqual(jane.Interact(shinryu), false);
            Assert.AreEqual(jane.Interact(redImp), false);

            // Solider and Squire can't interact with villager
            Assert.AreEqual(ramza.Interact(jane), false);
            Assert.AreEqual(cloud.Interact(jane), false);

            // Ranger and Mage can't interact with mage
            Assert.AreEqual(fawn.Interact(benedict), false);
            Assert.AreEqual(benedict.Interact(benedict.Copy()), false);

            // Imp and orc can't interact with dragon
            Assert.AreEqual(redImp.Interact(shinryu), false);
            Assert.AreEqual(ogremon.Interact(shinryu), false);

            // Soldier can interact with monsters
            Assert.AreEqual(cloud.Interact(ogremon), true);
            Assert.AreEqual(cloud.Interact(redImp), true);
            Assert.AreEqual(cloud.Interact(shinryu), true);
        }

        [TestMethod()]
        public void UnitParamsTest()
        {
            // Classes set the param adds correctly
            Assert.AreEqual(cloud.BaseAtkAdd, 0.03F);
            Assert.AreEqual(cloud.BaseDefAdd, 0.02F);
            Assert.AreEqual(cloud.BaseSpdAdd, 0.01F);

            Assert.AreEqual(jane.BaseAtkAdd, 0F);
            Assert.AreEqual(jane.BaseDefAdd, 0F);
            Assert.AreEqual(jane.BaseSpdAdd, 0F);

            Assert.AreEqual(shinryu.BaseAtkAdd, 0.05F);
            Assert.AreEqual(shinryu.BaseDefAdd, 0.03F);
            Assert.AreEqual(shinryu.BaseSpdAdd, 0.02F);

            // Classes' param adds operate correctly

            // Dragon's attack ups 5%
            Assert.AreEqual(shinryu.Attack, 105F);
            // Dragon's defense ups 3%
            Assert.AreEqual(shinryu.Defense, 20.6F);
            // Dragon's speed ups 2%
            Assert.AreEqual(shinryu.Speed, 40.8F);

            // Imp's attack ups 1%
            Assert.AreEqual(redImp.Attack, 101F);

            // Imp's defense and speed won't increase
            Assert.AreEqual(redImp.Defense, 20F);
            Assert.AreEqual(redImp.Speed, 40F);

            // Mage's speed decreases 1%
            Assert.AreEqual(benedict.Speed, 39.6F);

            // Orc's speed decreases 2%
            Assert.AreEqual(ogremon.Speed, 39.2F);
        }

        [TestMethod()]
        public void UnitClassChangeTest()
        {
            // Villager can't change to any class
            Assert.AreEqual(jane.ChangeClass(EUnitClass.Ranger), false);
            Assert.AreEqual(jane.ChangeClass(EUnitClass.Mage), false);
            Assert.AreEqual(jane.ChangeClass(EUnitClass.Soldier), false);
            Assert.AreEqual(jane.ChangeClass(EUnitClass.Squire), false);
            Assert.AreEqual(jane.ChangeClass(EUnitClass.Villager), false);

            // Units can't change to its own class
            Assert.AreEqual(fawn.ChangeClass(EUnitClass.Ranger), false);
            Assert.AreEqual(benedict.ChangeClass(EUnitClass.Mage), false);
            Assert.AreEqual(cloud.ChangeClass(EUnitClass.Soldier), false);
            Assert.AreEqual(ramza.ChangeClass(EUnitClass.Squire), false);

            // Units can change only to designed class
            Assert.AreEqual(fawn.ChangeClass(EUnitClass.Mage), true);
            Assert.AreEqual(fawn.ChangeClass(EUnitClass.Soldier), false);
            Assert.AreEqual(fawn.ChangeClass(EUnitClass.Squire), false);
            Assert.AreEqual(fawn.ChangeClass(EUnitClass.Villager), false);

            Assert.AreEqual(benedict.ChangeClass(EUnitClass.Ranger), true);
            Assert.AreEqual(benedict.ChangeClass(EUnitClass.Soldier), false);
            Assert.AreEqual(benedict.ChangeClass(EUnitClass.Squire), false);
            Assert.AreEqual(benedict.ChangeClass(EUnitClass.Villager), false);

            Assert.AreEqual(cloud.ChangeClass(EUnitClass.Squire), true);
            Assert.AreEqual(cloud.ChangeClass(EUnitClass.Soldier), false);
            Assert.AreEqual(cloud.ChangeClass(EUnitClass.Mage), false);
            Assert.AreEqual(cloud.ChangeClass(EUnitClass.Villager), false);

            // Humans can't change to monster class
            Assert.AreEqual(jane.ChangeClass(EUnitClass.Dragon), false);
            Assert.AreEqual(jane.ChangeClass(EUnitClass.Imp), false);
            Assert.AreEqual(jane.ChangeClass(EUnitClass.Orc), false);
        }

        [TestMethod()]
        public void UnitMovementTest()
        {
            Position p1 = new Position(10, 100);
            Position p2 = new Position(15, -20);
            Position p3 = new Position(-5, -10);

            // Units can move within their MoveRange
            // Dragon has MoveRange of 100
            Assert.AreEqual(shinryu.Move(p1), true);

            // Villager has MoveRange of 10
            Assert.AreEqual(benedict.Move(p3), true);


            // Units can't move outside their MoveRange
            // Villager has MoveRange of 10, can't move to 10, 100
            Assert.AreEqual(jane.Move(p1), false);
        }

        #endregion TestMethods
    }
}