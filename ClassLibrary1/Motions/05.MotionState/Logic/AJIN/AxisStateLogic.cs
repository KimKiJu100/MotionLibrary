using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes;
using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._05.MotionState.Logic.AJIN
{
    public enum AxisMoveState
    {
        CommandPosition = 0,
        CommnadSpeed = 1,
        FeedBackPosition = 2,
    }

    public class AxisStateLogic : IMotionAxisStateLogic
    {
        private readonly IMotionAxisHandler _handler = null;

        public AxisStateLogic(IMotionAxisHandler handler)
        {
            this._handler = handler;
        }

        public MotionStatusBase GetState()
        {
            MotionStatus<double> result = new MotionStatus<double>();
            uint duRetCode = 0;
            double dCmdPos = 0.0, dActPos = 0.0, dCmdVel = 0.0;

            // 지정 축의 Command 위치를 반환한다.
            duRetCode = CAXM.AxmStatusGetCmdPos(_handler.AxisIndex, ref dCmdPos);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                result[nameof(AxisMoveState.CommandPosition)] = dCmdPos;
            }
            // 지정 축의 Actual 위치를 반환한다.
            duRetCode = CAXM.AxmStatusGetActPos(_handler.AxisIndex, ref dActPos);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                result[nameof(AxisMoveState.FeedBackPosition)] = dActPos;
            }
            // 지정 축의 구동 속도를 반환한다.
            duRetCode = CAXM.AxmStatusReadVel(_handler.AxisIndex, ref dCmdVel);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                result[nameof(AxisMoveState.CommnadSpeed)] = dCmdVel;
            }

            return result;
        }
    }
}
