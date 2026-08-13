using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._04.MotionOperations.Base;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._04.MotionOperations
{
    /// <summary>
    /// 모션 동작에 대한 환경 제어 기능을 책임진다.
    /// </summary>
    public class MotionAxisAJINOperation : MotionOperationBase , IMotionOperation
    {
        private readonly IMotionAxisHandler _handler = null;
        public MotionAxisAJINOperation(IMotionAxisHandler handler)
        {
            _handler = handler;
        }

        public bool ServoOnOff(bool OnOff)
        {
            uint duOnOff = (uint)Convert.ToInt32(OnOff);
            if (CAXM.AxmSignalServoOn(_handler.AxisIndex, duOnOff) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                return true;
            else
                return false;
        }
        public bool ServoReset(bool OnOff)
        {
            uint duOnOff = (uint)Convert.ToInt32(OnOff);
            if (CAXM.AxmSignalServoAlarmReset(_handler.AxisIndex, duOnOff) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                return true;
            else
                return false;
        }
    }
}
