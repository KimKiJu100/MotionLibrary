using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._05.MotionState.Logic.AJIN
{
    public enum AJINMechanicalState
    {
        P_LimitState = 0,
        N_LimitState = 1,
        AlarmState = 4,
        InPositionState = 5,
        EmergencyState = 6,
        HomeState = 7,
        ZPhaseState = 8,
        EncoderUpState = 9,
        EncoderDnState = 10,
        EXPPState = 11,
        EXMPState = 12,
        SQSTR1State = 13,
        SQSTR2State = 14,
        ModeState = 17,
    }
    public class MechanicalStateLogic : IMotionAxisStateLogic
    {
        private readonly IMotionAxisHandler _handler = null;
        private int[] digitMechIndex = {
            (int)AJINMechanicalState.P_LimitState,
            (int)AJINMechanicalState.N_LimitState,
            (int)AJINMechanicalState.AlarmState,
            (int)AJINMechanicalState.InPositionState,
            (int)AJINMechanicalState.EmergencyState,
            (int)AJINMechanicalState.HomeState,
            (int)AJINMechanicalState.ZPhaseState,
            (int)AJINMechanicalState.EncoderUpState,
            (int)AJINMechanicalState.EncoderDnState,
            (int)AJINMechanicalState.EXPPState,
            (int)AJINMechanicalState.EXMPState,
            (int)AJINMechanicalState.SQSTR1State,
            (int)AJINMechanicalState.SQSTR2State,
            (int)AJINMechanicalState.ModeState };
        public MechanicalStateLogic(IMotionAxisHandler handler)
        {
            this._handler = handler;
        }

        public MotionStatus GetState()
        {
            MotionStatus result = new MotionStatus();
            int iIndex = 0, iCheck = 0;
            uint duRetCode, duStatus = 0;

            //++ 지정 축의 Mechanical Signal Data(현재 기계적인 신호상태)를 확인합니다.
            // ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
            duRetCode = CAXM.AxmStatusReadMechanical(_handler.AxisIndex, ref duStatus);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                for (iIndex = 0; iIndex < digitMechIndex.Length; iIndex++)
                {
                    var state = (AJINMechanicalState)digitMechIndex[iIndex];
                    iCheck = ((int)duStatus >> digitMechIndex[iIndex] & 0x1);
                    result[state.ToString()] = Convert.ToBoolean(iCheck);
                }
            }

            return result;
        }
    }
}
