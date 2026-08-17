using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._02.MotionConnections.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._02.MotionConnections
{
    public class MotionAJINConnection : MotionConnectionBase, IMotionConnection
    {
        private readonly IMotionAxisHandler _handler = null;

        public MotionAJINConnection()
        {       
        }

        public MotionAJINConnection(IMotionAxisHandler handler)
        {
            _handler = handler;
        }

        public bool Connect()
        {
            if (CAXL.AxlOpenNoReset(7) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                return true;
            else
                return false;
        }
    }
}
