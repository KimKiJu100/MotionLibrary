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
        public virtual bool ConnectionMotionDevice()
        {
            throw new Exception("구현부에 Connection을 오버라이딩 하지 않았습니다. 확인하세요.");
        }
    }
}
