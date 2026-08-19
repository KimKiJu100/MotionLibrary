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
    public enum AJINEndStopState
    {
        P_LimitStateState = 0,
        N_LimitStateState = 1,
        P_SW_EStopState = 4,
        N_SW_EStopState = 5,
        P_SW_SStopState = 6,
        N_SW_SStopState = 7,
        ServoAlramState = 8,
        EmergencyState = 9,
        EMGStopCMDState = 10,
        SlowStopCMDState = 11,
        EncoderInputState = 15,
        CurrentMoveDirectionState = 28,
        AbnormalDriveStopState = 30,
        InterpolationDataErrorState= 31,
    }
    public class AxisEndStateLogic : IMotionAxisStateLogic
    {
        private readonly IMotionAxisHandler _handler = null;
        private int[] digitEndIndex = {
            (int)AJINEndStopState.P_LimitStateState,
            (int)AJINEndStopState.N_LimitStateState,
            (int)AJINEndStopState.P_SW_EStopState,
            (int)AJINEndStopState.N_SW_EStopState,
            (int)AJINEndStopState.P_SW_SStopState,
            (int)AJINEndStopState.N_SW_SStopState,
            (int)AJINEndStopState.ServoAlramState,
            (int)AJINEndStopState.EmergencyState,
            (int)AJINEndStopState.EMGStopCMDState,
            (int)AJINEndStopState.SlowStopCMDState,
            (int)AJINEndStopState.EncoderInputState,
            (int)AJINEndStopState.CurrentMoveDirectionState,
            (int)AJINEndStopState.AbnormalDriveStopState,
            (int)AJINEndStopState.InterpolationDataErrorState };
        public AxisEndStateLogic(IMotionAxisHandler handler)
        {
            this._handler = handler;
        }

        public MotionStatusBase GetState()
        {
            MotionStatus result = new MotionStatus();
            int iIndex = 0, iCheck = 0;
            uint duRetCode, duStatus = 0;

            //++ 지정 축의 End Status(정지 상태)를 확인합니다.
            // ※ [CAUTION] 각 제품별로 정지 상태가 다르기 때문에 매뉴얼 및 AXHS.xxx 파일을 참고하십시요.
            duRetCode = CAXM.AxmStatusReadStop(_handler.AxisIndex, ref duStatus);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                for (iIndex = 0; iIndex < 14; iIndex++)
                {
                    var state = (AJINEndStopState)digitEndIndex[iIndex];
                    iCheck = ((int)duStatus >> digitEndIndex[iIndex] & 0x1);
                    result[state.ToString()] = Convert.ToBoolean(iCheck);
                }
            }

            return result;
        }
    }
}
