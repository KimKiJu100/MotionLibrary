using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._05.MotionState.Logic.DataTypes
{
    public class MotionStatus : MotionStatusBase
    {
        private readonly Dictionary<string, bool> _states = new Dictionary<string, bool>();

        public IEnumerable<bool> Values => _states.Values;

        public bool this[string key]
        {
            get => _states[key];
            set => _states[key] = value;
        }   
    }

    public class MotionStatus<TValue> : MotionStatusBase
    {
        private readonly Dictionary<string, TValue> _states = new Dictionary<string, TValue>();

        public IEnumerable<TValue> Values => _states.Values;

        public TValue this[string key]
        {
            get => _states[key];
            set => _states[key] = value;
        }
    }
}
