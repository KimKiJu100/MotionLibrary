using ClassLibrary1.Motions._03.MotionMoves.ParamsType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._03.MotionMoves.Base
{
    public abstract class MotionMoveBase
    {
        protected MotionSpeedParam _jogParam = null;
        protected MotionSpeedParam _absParam = null;
        protected MotionMoveBase()
        {

        }

        public void SetJogParams(MotionSpeedParam jogParam)
        {
            this._jogParam = jogParam;
        }

        public void SetMoveParams(MotionSpeedParam AbsParam)
        {
            this._absParam = AbsParam;
        }
    }
}
