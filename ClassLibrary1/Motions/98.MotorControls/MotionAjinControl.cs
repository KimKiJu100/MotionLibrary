using ClassLibrary1.Motions._02.MotionConnections;
using ClassLibrary1.Motions._02.MotionConnections.Base;
using ClassLibrary1.Motions._98.MotorAxes;
using ClassLibrary1.Motions._98.MotorControls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._98.MotorControls
{
    public class MotionAjinControl : MotionControlBase
    {
        private readonly IMotionConnection _motionConnection = new MotionAJINConnection();
        Dictionary<string, MotionAxis> motionAxes = new Dictionary<string, MotionAxis>();
        public MotionAjinControl()
        {
                
        }
        public MotionAxis GetMotionAxis(string keyName)
        {
            if (motionAxes.TryGetValue(keyName, out var Axis))
                return Axis;
            else
                throw new Exception("해당 Control에는 존재하는 Axis가 없습니다.");
        }

        public override bool ConnectionMotionDevice()
        {
            return _motionConnection.Connect();
        }
    }
}
