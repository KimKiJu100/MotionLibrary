using ClassLibrary1.Motions._03.MotionMoves.ParamsType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._03.MotionMoves.Base
{
    public interface IMotionMoveBase
    {
        void SetJogParam(MotionSpeedParam SpeedParam);
        void SetMoveParam(MotionSpeedParam SpeedParam);
        void JogMove();
        bool AbsMove(double targetPosition);
        bool MoveStop();
    }
}
