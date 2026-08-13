using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._02.MotionConnections.Base;
using ClassLibrary1.Motions._03.MotionMoves.Base;
using ClassLibrary1.Motions._04.MotionOperations.Base;
using ClassLibrary1.Motions._05.MotionState.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._98.MotorAxes
{
    public class MotionAxis
    {
        private readonly IMotionAxisHandler _handler;
        private readonly IMotionConnection _connection;
        private readonly IMotionMoveBase _move;
        private readonly IMotionOperation _operation;
        private readonly IMotionStateBase _state;
        public MotionAxis()
        {
                
        }
    }
}
