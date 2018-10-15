using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public enum ModelTypes
    {
        Unknown = 0,
        Solution,
        Project,
    }

    public class Model
    {
        public string Name { get; internal set; }
        public ModelTypes Kind { get; protected set; }
        public bool Valid { get { return this.Validate(); } }
        public Model(ModelTypes kind, string name = "")
        {
            this.Kind = kind;
            this.Name = name;
        }

        protected virtual bool Validate() { return true; }
    }
}
