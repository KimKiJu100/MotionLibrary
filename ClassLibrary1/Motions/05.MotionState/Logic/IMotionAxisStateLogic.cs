using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes;
using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes.Base;

namespace ClassLibrary1.Motions._05.MotionState.Logic
{
    public interface IMotionAxisStateLogic
    {
        MotionStatusBase GetState();
    }
}
