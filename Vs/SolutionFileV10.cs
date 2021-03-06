﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public sealed class SolutionFileV10 : SolutionFile
    {
        public SolutionFileV10(string strPath = "") : base(strPath)
        {

        }
        sealed protected override void OnLineData(LineReadingEventArgs e)
        {

        }
        protected sealed override Solution ConstructSolution()
        {
            return new SolutionV10(this.Name);
        }
    }
}
