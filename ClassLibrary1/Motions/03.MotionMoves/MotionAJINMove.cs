using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._03.MotionMoves.Base;
using ClassLibrary1.Motions._03.MotionMoves.ParamsType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._03.MotionMoves
{
    /// <summary>
    /// 모션 무브 기능을 책임진다.
    /// </summary>

    public class MotionAJINMove : MotionMoveBase, IMotionMoveBase
    {
        private readonly IMotionAxisHandler _handler = null;
        public MotionAJINMove(IMotionAxisHandler handler)
        {
            _handler = handler;
        }

        public void SetJogParam(MotionSpeedParam SpeedParam)
        {
            base.SetJogParams(SpeedParam);
        }
        public void SetMoveParam(MotionSpeedParam SpeedParam)
        {
            base.SetMoveParams(SpeedParam);
        }

        public void JogMove()
        {
            if (base._jogParam == null) throw new Exception("Jog Speed 파라미터가 입력되어 있지 않습니다.");
            CAXM.AxmMoveVel(_handler.AxisIndex, base._jogParam.Velocity, base._jogParam.Accel, base._jogParam.Decel);
        }
        public bool MoveStop()
        {
            if (CAXM.AxmMoveSStop(_handler.AxisIndex) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                return true;
            else
                return false;
        }

        public bool AbsMove(double targetPosition)
        {
            if(base._absParam == null) throw new Exception("abs Speed 파라미터가 입력되어 있지 않습니다.");

            if (CAXM.AxmMoveStartPos(_handler.AxisIndex, 
                                     targetPosition, 
                                     base._absParam.Velocity, 
                                     base._absParam.Accel, 
                                     base._absParam.Decel) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                return true;
            else
                return false;
        }
    }
}
