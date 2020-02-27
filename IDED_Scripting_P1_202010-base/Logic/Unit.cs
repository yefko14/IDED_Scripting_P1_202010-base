namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        public int BaseAtk { get; protected set; }
        public int BaseDef { get; protected set; }
        public int BaseSpd { get; protected set; }

        public int MoveRange { get; protected set; }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; }
        public float Defense { get; }
        public float Speed { get; }

        protected Position CurrentPosition;

        public EUnitClass UnitClass { get; protected set; }
        
        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;

            if (_unitClass== EunitClass.Villager)
            {
                BaseAtkAdd = _atk*0;
                BaseDefAdd = _def*0;
                BaseSpdAdd = _spd*0;
                AtkRange = 1;
            }
            else if (_unitClass == EunitClass.Squire)
            {
                BaseAtkAdd = _atk*0.02;
                BaseDefAdd = _def*0.01;
                BaseSpdAdd = _spd*0;
                AtkRange = 1;
            }
            else if (_unitClass == EunitClass.Soldier)
            {
                BaseAtkAdd = _atk*0.03;
                BaseDefAdd = _def*0.02;
                BaseSpdAdd = _spd*0.01;
                AtkRange = 1;
            }
            else if (_unitClass == EunitClass.Ranger)
            {
                BaseAtkAdd = _atk*0.01;
                BaseDefAdd = _def*0;
                BaseSpdAdd = _sdp*0.03;
                AtkRange = 3;
            }
            else if (_unitClass == EunitClass.Mage)
            {
                BaseAtkAdd = _atk*0.03;
                BaseDefAdd = _def*0.01;
                BaseSpdAdd = _spd*-0.01;
                AtkRange = 3;
            }
            else if (_unitClass == EunitClass.Imp)
            {
                BaseAtkAdd = _atk*0.01;
                BaseDefAdd = _def*0;
                BaseSpdAdd = _sdp*0;
                AtkRange = 1;
            }
            else if (_unitClass == EunitClass.Orc)
            {
                BaseAtkAdd = _atk*0.04;
                BaseDefAdd = _def*0.02;
                BaseSpdAdd = _adp*-0.02;
                AtkRange = 1;
            }
            else if (_unitClass == EunitClass.Dragon)
            {
                BaseAtkAdd = _atk*0.05;
                BaseDefAdd = _def*0.03;
                BaseSpdAdd = _spd*0.02;
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
            else if (Defense < 0)
            {
                Defense = 0;
            }
            else if (Defense > 255)
            {
                Defense = 255;
            }
            else if (Speed < 0)
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
            return false;
        }

        public virtual bool Interact(Prop prop) => false;

        public bool Move(Position targetPosition)
        {
            if (targetPosition <= CurrentPosition + (MoveRange, MoveRange))
            {
                CurrentPosition = targetPosition;
                return true;
            }
            else false;
        }
    }
}