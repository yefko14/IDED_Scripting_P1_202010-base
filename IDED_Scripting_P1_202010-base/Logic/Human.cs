using System;
namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        private float potential;

        public float Potential
        {
            get => potential; protected set
            {
                if (value >= 0 && value <= 10) potential = value;
                else if (value < 0) potential = 0;
                else if (value > 10) potential = 10;
            }
        }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            Potential = _potential/100;

            if (_unitClass == EUnitClass.Imp)
            {
                _unitClass = EUnitClass.Villager;
            }
            else if (_unitClass == EUnitClass.Orc)
            {
                _unitClass = EUnitClass.Villager;
            }
            else if(_unitClass == EUnitClass.Dragon)
            {
                _unitClass = EUnitClass.Villager;
            }

            Attack = Attack + (Attack * Potential);
            Defense = Defense + (Defense * Potential);
            Speed = Speed + (Speed * Potential);
        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            if (newClass == EUnitClass.Soldier || newClass == EUnitClass.Squire)
            {
                if(UnitClass == EUnitClass.Soldier)
                {
                    UnitClass = EUnitClass.Squire;
                    return true;
                }
                else if(UnitClass == EUnitClass.Squire)
                {
                    UnitClass = EUnitClass.Soldier;
                    return true;
                }
            }
            else if (newClass == EUnitClass.Ranger || newClass == EUnitClass.Mage)
            {
                if (UnitClass == EUnitClass.Ranger)
                {
                    UnitClass = EUnitClass.Mage;
                    return true;
                }
                else if (UnitClass == EUnitClass.Mage)
                {
                    UnitClass = EUnitClass.Ranger;
                    return true;
                }
            }
            else return false;
        }
    }
}