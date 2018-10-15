using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Project : Model
    {
        public Project(string name=""):base (ModelTypes.Project, name)
        {

        }

        protected override bool Validate()
        {
            return base.Validate();
        }
    }
}
