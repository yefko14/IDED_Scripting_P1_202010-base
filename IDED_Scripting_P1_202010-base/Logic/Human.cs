namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, float _potential)
            : base(_unitClass, _atk, _def, _spd)
        {
            Potential = _potential;
        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            return false;
        }
    }
}