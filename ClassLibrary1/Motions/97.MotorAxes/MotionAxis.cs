using ClassLibrary1.Motions._01.MotionHandlers.Base;
using ClassLibrary1.Motions._02.MotionConnections.Base;
using ClassLibrary1.Motions._03.MotionMoves.Base;
using ClassLibrary1.Motions._04.MotionOperations.Base;
using ClassLibrary1.Motions._05.MotionState.Base;
using ClassLibrary1.Motions._05.MotionState.Logic;
using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes;
using ClassLibrary1.Motions._05.MotionState.Logic.Factorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._98.MotorAxes
{
    public class MotionAxis
    {
        private readonly IMotionAxisHandler _handler;
        private readonly IMotionMoveBase _move;
        private readonly IMotionOperation _operation;
        private readonly Dictionary<StateMode, IMotionAxisStateLogic> _stateStrategies = new Dictionary<StateMode, IMotionAxisStateLogic>();
        public MotionAxis(IMotionAxisHandler handler,
                            IMotionMoveBase move,
                            IMotionOperation operation)
        {
            _handler = handler;
            _move = move;
            _operation = operation;
        }

        public bool ServoOnOff(bool OnOff)
        {
            return _operation.ServoOnOff(OnOff);
        }
        public bool ServoAlramReset(bool ringinTrriger)
        {
            if (_operation.ServoReset(ringinTrriger))
            {
                Thread.Sleep(10);
                return _operation.ServoReset(!ringinTrriger);
            }
            else
            {
                return false;
            }
        }
        public MotionStatus GetState(StateMode statusMode)
        {
            if (!_stateStrategies.TryGetValue(statusMode, out var strategy))
            {
                MotionStateFactory _facLogic = new MotionStateFactory();
                strategy = _facLogic.CreateStateStrategy(statusMode, _handler);

                _stateStrategies.Add(statusMode, strategy);
            }

            return strategy.GetState();
        }
    }
}
