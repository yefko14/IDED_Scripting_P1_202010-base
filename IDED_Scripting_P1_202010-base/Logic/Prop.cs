using System;
namespace IDED_Scripting_P1_202010_base.Logic
{
    public struct Prop
    {
        public EPropType PropType { get; private set; }

        public Prop(EPropType _propType)
        {
            PropType = _propType;
        }
    }
}