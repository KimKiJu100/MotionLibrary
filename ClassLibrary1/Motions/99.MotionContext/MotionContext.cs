using ClassLibrary1.Motions._98.MotorAxes;
using ClassLibrary1.Motions._98.MotorControls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._99.MotionContext
{
    public class MotionContext
    {
        Dictionary<string, MotionAxis> motionAxes = new Dictionary<string, MotionAxis>();
        private readonly Dictionary<string, MotionControlBase> _controls = new Dictionary<string, MotionControlBase>();

        public MotionContext()
        {
                
        }

        public MotionAxis GetMotionAxis(string keyName)
        {
            if (motionAxes.TryGetValue(keyName, out var Axis))
                return Axis;
            else
                throw new Exception("해당 Control에는 존재하는 Axis가 없습니다.");
        }

        public MotionControlBase GetMotionControls(string keyName)
        {
            if (_controls.TryGetValue(keyName, out var control))
                return control;
            else
                throw new Exception("해당 Control에는 존재하는 Axis가 없습니다.");
        }
    }
}
