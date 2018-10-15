using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public sealed class SolutionFileV9 : SolutionFile
    {
        public SolutionFileV9(string strPath = "") : base(strPath)
        {

        }
        sealed protected override void OnLineData(LineReadingEventArgs e)
        {

        }
        protected sealed override Solution ConstructSolution()
        {
            return new SolutionV9(this.Name);
        }
    }
}
