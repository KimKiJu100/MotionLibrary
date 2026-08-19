using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._05.MotionState.Base;
using ClassLibrary1.Motions._05.MotionState.Logic;
using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes;
using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes.Base;
using ClassLibrary1.Motions._05.MotionState.Logic.Factorys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._05.MotionState
{
    public class MotionAJINState : MotionStateBase , IMotionStateBase
    {
        private readonly IMotionAxisHandler _handler = null;

        private IMotionAxisStateLogic logic = null;

        public MotionAJINState(IMotionAxisHandler handler)
        {
            _handler = handler;
        }

        public MotionStatusBase GetState(IMotionAxisStateLogic logic)
        {
            return logic.GetState();
        }
    }
}
