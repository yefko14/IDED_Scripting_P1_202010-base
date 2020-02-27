namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            Potential = _potential;
            if (_unitClass == EunitClass.Imp)
            {
                _unitClass = EuniClass.Viillager;
            }
            else if (_unitClass == EunitClass.Orc)
            {
                _unitClass = EuniClass.Viillager;
            }
            else if(_unitClass = EuniClass.Dragon)
            {
                _unitClass = EuniClass.Viillager;
            }
        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            return false;
        }
    }
}