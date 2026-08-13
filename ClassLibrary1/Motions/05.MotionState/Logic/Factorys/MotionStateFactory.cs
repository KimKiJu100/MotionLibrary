using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._05.MotionState.Logic.AJIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._05.MotionState.Logic.Factorys
{
    public enum StateMode
    {
        AJIN_ENDLogic = 0,
        AJIN_DriveMode= 1,
        AJIN_DriveMechanical = 2,
    }
    public class MotionStateFactory
    {
        public IMotionAxisStateLogic CreateStateStrategy(StateMode mode, IMotionAxisHandler handler)
        {
            switch (mode)
            {
                case StateMode.AJIN_DriveMechanical:
                    return new MechanicalStateLogic(handler);
                case StateMode.AJIN_DriveMode:
                    return new DriveMotionState(handler);
                case StateMode.AJIN_ENDLogic:
                    return new AxisEndStateLogic(handler);
                default:
                    throw new Exception("Type 정의 NG.");
            }
             
        }
    }
}
