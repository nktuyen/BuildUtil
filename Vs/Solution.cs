using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Solution : Model
    {
        public ProjectCollection Projects { get; protected set; }
        public Solution(string name = "") : base(ModelTypes.Solution, name)
        {
            
        }

        internal Project AddProject(string name)
        {
            Project prj = Projects.FindProject(name);
            if (prj == null)
            {
                prj = new Project(name);
                Projects.Add(prj);
            }

            return prj;
        }

        protected override bool Validate()
        {
            return base.Validate();
        }
    }
}
