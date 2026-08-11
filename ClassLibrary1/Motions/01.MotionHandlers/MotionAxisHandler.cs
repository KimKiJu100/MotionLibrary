using ClassLibrary1.Motions._01.MotionHandlers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions.MotionHandler
{
    /// <summary>
    /// 축 핸들러 클래스입니다. 이 클래스는 모션 축을 처리하는 기능을 제공합니다.    
    /// </summary>
    public sealed class MotionAxisHandler : MotionHandlerBase , IMotionAxisHandler
    {
        public int AxisIndex { get; set; }
        public MotionAxisHandler()
        {
                
        }
    }
}
