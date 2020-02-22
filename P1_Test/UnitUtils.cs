using IDED_Scripting_P1_202010_base.Logic;

namespace P1_Test
{
    public static class UnitUtils
    {
        public static Unit Copy(this Unit u)
        {
            if (u is Human h)
            {
                return h.Copy();
            }
            else
            {
                return new Unit(u.UnitClass, u.BaseAtk, u.BaseDef, u.BaseSpd);
            }
        }

        public static Human Copy(this Human u)
        {
            return new Human(u.UnitClass, u.BaseAtk, u.BaseDef, u.BaseSpd, u.Potential);
        }
    }
}