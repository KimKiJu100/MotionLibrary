using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._02.MotionConnections.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._02.MotionConnections
{
    public class MotionAJINConnection : MotionConnectionBase 
    {
        public MotionAJINConnection()
        {
        }

        public bool Connect()
        {
            if(CAXL.AxlOpenNoReset(7) == AXT_FUNC_RESULT.AXT_rt_secess)
            return 
        }
    }
}
