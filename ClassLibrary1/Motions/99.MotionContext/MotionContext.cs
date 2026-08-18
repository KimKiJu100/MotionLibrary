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

        public void AddControl(string name, MotionControlBase ctl)
        {
            if (ctl == null || !(ctl is MotionControlBase))                     throw new Exception("Control 확인 바랍니다.");
            else if (_controls.ContainsKey(name))                               throw new Exception("중복 이름이 확인 되었습니다.");
            
            
            _controls.Add(name, ctl);
        }


        public void RemoveControl(string name)
        {
            if (!_controls.ContainsKey(name))                                   throw new Exception("요청하신 컨트롤은 존재 하지 않습니다.");
            _controls.Remove(name);
        }
    }
}
