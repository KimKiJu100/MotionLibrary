using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._03.MotionMoves;
using ClassLibrary1.Motions._03.MotionMoves.Base;
using ClassLibrary1.Motions._04.MotionOperations;
using ClassLibrary1.Motions._04.MotionOperations.Base;
using ClassLibrary1.Motions._05.MotionState.Base;
using ClassLibrary1.Motions._98.MotorAxes.Factorys.Params;
using ClassLibrary1.Motions._98.MotorAxes.Factorys.Params.Base;
using ClassLibrary1.Motions.MotionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._98.MotorAxes
{
    public class MotionAxisPartFactory
    {
        private MotionAxis CreateAxis(AxisParamBase param)
        {
            switch (param)
            {
                case AJINAxisParam ajinParam:
                    IMotionAxisHandler handle = new MotionAxisHandler() { AxisIndex = ajinParam.iAxisHandler };
                    IMotionMoveBase move = new MotionAJINMove(handle) ;
                    IMotionOperation oper = new MotionAxisAJINOperation(handle);
                    return new MotionAxis(handle, move, oper);

                default:
                    throw new NotSupportedException($"지원하지 않는 AxisParam 타입입니다. {param.GetType().Name}");
            }
        }
    }
}
