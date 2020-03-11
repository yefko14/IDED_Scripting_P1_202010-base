using System;

namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        private int baseAtk;
        private int baseDef;
        private int baseSpd;
        private int moveRange;

        public int BaseAtk
        {
            get => baseAtk; protected set
            {
                if (value >= 0 && value <= 255) baseAtk = value;
                else if (value < 0) baseAtk = 0;
                else if (value > 255) baseAtk = 255;
            }
        }
        public int BaseDef
        { get => baseDef; protected set
            {
                if (value >= 0 && value <= 255) baseDef = value;
                else if (value < 0) baseDef = 0;
                else if (value > 255) baseDef = 255;
            }
        }
        public int BaseSpd
        { get => baseSpd; protected set
            {
                if (value >= 0 && value <= 255) baseSpd = value;
                else if (value < 0) baseSpd = 0;
                else if (value > 255) baseSpd = 255;
            }
        }

        public int MoveRange
        {
            get => moveRange; protected set
            {
                if (value >= 1 && value <= 10) moveRange = value;
                else if (value < 1) moveRange = 1;
                else if (value > 10) moveRange = 10;
            }
        }

        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; protected set; }
        public float Defense { get; protected set; }
        public float Speed { get; protected set; }

        protected Position CurrentPosition;
        Random rdn = new Random();

        private EUnitClass unitClass;
        public EUnitClass UnitClass { get; protected set; }
        
        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            int rdnX = rdn.Next(0, 100);
            int rdnY = rdn.Next(0, 100);

            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;

            CurrentPosition = new Position(rdnX, rdnY);

            if (_unitClass== EUnitClass.Villager)
            {
                BaseAtkAdd = _atk*0f;
                BaseDefAdd = _def*0f;
                BaseSpdAdd = _spd*0f;
                AtkRange = 0;
            }
            else if (_unitClass == EUnitClass.Squire)
            {
                BaseAtkAdd = _atk*0.02f;
                BaseDefAdd = _def*0.01f;
                BaseSpdAdd = _spd*0f;
                AtkRange = 1;
            }
            else if (_unitClass == EUnitClass.Soldier)
            {
                BaseAtkAdd = _atk*0.03f;
                BaseDefAdd = _def*0.02f;
                BaseSpdAdd = _spd*0.01f;
                AtkRange = 1;
            }
            else if (_unitClass == EUnitClass.Ranger)
            {
                BaseAtkAdd = _atk*0.01f;
                BaseDefAdd = _def*0f;
                BaseSpdAdd = _spd*0.03f;
                AtkRange = 3;
            }
            else if (_unitClass == EUnitClass.Mage)
            {
                BaseAtkAdd = _atk*0.03f;
                BaseDefAdd = _def*0.01f;
                BaseSpdAdd = _spd*-0.01f;
                AtkRange = 3;
            }
            else if (_unitClass == EUnitClass.Imp)
            {
                BaseAtkAdd = _atk*0.01f;
                BaseDefAdd = _def*0f;
                BaseSpdAdd = _spd*0f;
                AtkRange = 1;
            }
            else if (_unitClass == EUnitClass.Orc)
            {
                BaseAtkAdd = _atk*0.04f;
                BaseDefAdd = _def*0.02f;
                BaseSpdAdd = _spd*-0.02f;
                AtkRange = 1;
            }
            else if (_unitClass == EUnitClass.Dragon)
            {
                BaseAtkAdd = _atk*0.05f;
                BaseDefAdd = _def*0.03f;
                BaseSpdAdd = _spd*0.02f;
                AtkRange = 5;
            }

            Attack = BaseAtk + BaseAtkAdd;
            Defense = BaseDef + BaseDefAdd;
            Speed = BaseSpd + BaseSpdAdd;

            if (Attack < 0)
            {
                Attack = 0;
            }
            else if (Attack > 255)
            {
                Attack = 255;
            }
            if (Defense < 0)
            {
                Defense = 0;
            }
            else if (Defense > 255)
            {
                Defense = 255;
            }
            if (Speed < 0)
            {
                Speed = 0;
            }
            else if (Speed > 255)
            {
                Speed = 255;
            }
        }

        public virtual bool Interact(Unit otherUnit)    
        {
            switch (UnitClass)
            {
                case EUnitClass.Villager:
                    return false;
                case EUnitClass.Squire:
                    if (otherUnit.UnitClass is EUnitClass.Villager)
                    {
                        return false;
                    }
                    else return true;
                case EUnitClass.Soldier:
                    if (otherUnit.UnitClass is EUnitClass.Villager)
                    {
                        return false;
                    }
                    else return true;
                case EUnitClass.Ranger:
                    if (otherUnit.UnitClass is EUnitClass.Mage || otherUnit.UnitClass is EUnitClass.Dragon)
                    {
                        return false;
                    }
                    else return true;
                case EUnitClass.Mage:
                    if (otherUnit.UnitClass is EUnitClass.Mage)
                    {
                        return false;
                    }
                    else return true;
                case EUnitClass.Imp:
                    if (otherUnit.UnitClass is EUnitClass.Dragon)
                    {
                        return false;
                    }
                    else return true;
                case EUnitClass.Orc:
                    if (otherUnit.UnitClass is EUnitClass.Mage)
                    {
                        return false;
                    }
                case EUnitClass.Dragon:
                    return true;
            }
        }

        public virtual bool Interact(Prop prop)
        {
            if (UnitClass is EUnitClass.Villager)
            {
                return true;
            }
            else return false;
        }

        public bool Move(Position targetPosition)
        {
            float canMove = (float)Math.sqrt(targetPosition.x, 2) + Math.pow(targetPosition.y, 2);
            if (canMove <= MoveRange)
            {
                CurrentPosition = targetPosition;
                return true;
            }
            else false;
        }
    }
}