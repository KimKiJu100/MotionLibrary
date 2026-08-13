using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._04.MotionOperations.Base
{
    public interface IMotionOperation
    {
        bool ServoOnOff(bool OnOff);
        bool ServoReset(bool OnOff);
    }
}
