using System.Collections.Generic;
using System.Linq;

namespace Assembly_Emulator
{
    class History<Type>
    {
        List<Type> data = new List<Type>();
        int idx = -1;

        public void Add(Type d)
        {
            data = data.Take(idx + 1).ToList();
            data.Add(d);
            idx++;
        }

        public Type Back { get { return data[--idx]; } }
        public Type Next { get { return data[++idx]; } }
        public Type Active { get { return data[idx]; } }

        public bool CanBack { get { return idx > 0; } }
        public bool CanNext { get { return idx + 1 < data.Count && idx >= 0; } }
    }
}
