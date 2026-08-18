using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Motions._05.MotionState.Logic.DataTypes
{
    public class MotionStatus
    {
        private readonly Dictionary<string, bool> _states = new Dictionary<string, bool>();

        public IEnumerable<bool> Values => _states.Values;

        public bool this[string key]
        {
            get => _states[key];
            set => _states[key] = value;
        }

        
    }
}
