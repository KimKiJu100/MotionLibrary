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
    public enum AJINDriveState
    {
        BUSY = 0,
        Deceleration = 1,
        ConstantSpeed = 2,
        Acceleration = 3,
        MoveContinuousDrive = 4,
        MoveAssingedDrive= 5,
        MoveMPGDrive = 6,
        MoveHomeDrive = 7,
        MoveSlaveDrive = 10,
        DirectionMotorDrive= 11,
    }
    public class DriveMotionState : IMotionAxisStateLogic
    {
        private readonly IMotionAxisHandler _handler = null;
        private int[] digitDriveIndex = {
            (int)AJINDriveState.BUSY,
            (int)AJINDriveState.Deceleration,
            (int)AJINDriveState.ConstantSpeed,
            (int)AJINDriveState.Acceleration,
            (int)AJINDriveState.MoveContinuousDrive,
            (int)AJINDriveState.MoveAssingedDrive,
            (int)AJINDriveState.MoveMPGDrive,
            (int)AJINDriveState.MoveHomeDrive,
            (int)AJINDriveState.MoveSlaveDrive,
            (int)AJINDriveState.DirectionMotorDrive };

        public DriveMotionState(IMotionAxisHandler handler)
        {
            this._handler = handler;
        }

        public MotionStatusBase GetState()
        {
            MotionStatus result = new MotionStatus();
            int iIndex = 0, iCheck = 0;
            uint duRetCode, duStatus = 0;

            //++ 지정 축의 Drive Status(모션중 상태)를 확인합니다.
            // ※ [CAUTION] 각 제품별로 모션중 상태가 다르기 때문에 매뉴얼 및 AXHS.xxx 파일을 참고하십시요.
            duRetCode = CAXM.AxmStatusReadMotion(_handler.AxisIndex, ref duStatus);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                for (iIndex = 0; iIndex < digitDriveIndex.Length; iIndex++)
                {
                    var state = (AJINDriveState)digitDriveIndex[iIndex];
                    iCheck = ((int)duStatus >> digitDriveIndex[iIndex] & 0x1);
                    result[state.ToString()] = Convert.ToBoolean(iCheck);
                }
            }

            return result;
        }
    }
}
