using ClassLibrary1.Motions._05.MotionState.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._05.MotionState.Logic.DataTypes.Base
{
    public static class MotionStatusBaseExtention
    {
        public static T Cast<T>(this MotionStatusBase state) where T : MotionStatusBase
        {
            return (T)state;
        }
    }

    //제네릭 타입 및 bool타입을 모두 묶어주기 위한 클래스
    public abstract class MotionStatusBase
    {
    }
}
