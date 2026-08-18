using ClassLibrary1.Motions._98.MotorAxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._98.MotorControls.Base
{
    /// <summary>
    /// Axis의 컬렉션으로 관리한다
    /// Motion 기준
    /// </summary>
    public abstract class MotionControlBase
    {
        protected Dictionary<string, MotionAxis> motionAxes = new Dictionary<string, MotionAxis>();

        public MotionAxis this[string axisName]
        {
            get
            {
                return motionAxes[axisName];
            }
        }

        public virtual bool ConnectionMotionDevice()
        {
            throw new Exception("구현부에 Connection을 오버라이딩 하지 않았습니다. 확인하세요.");
        }

        public virtual void AddAxis(string name, MotionAxis axis)
        {
            if (axis == null || !(axis is MotionAxis)) throw new Exception("MotionAxis 확인 바랍니다.");
            else if (motionAxes.ContainsKey(name)) throw new Exception("중복 이름이 확인 되었습니다.");


            motionAxes.Add(name, axis);
        }


        public virtual void RemoveAxis(string name)
        {
            if (!motionAxes.ContainsKey(name)) throw new Exception("요청하신 축은 존재 하지 않습니다.");
            motionAxes.Remove(name);
        }

        public virtual IEnumerable<string> GetList()
        {
            return motionAxes.Keys;
        }
    }
}
