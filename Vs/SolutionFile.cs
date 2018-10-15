using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Vs
{
    public class VersionInformation
    {
        public uint Major { get; set; }
        public uint Minor { get; set; }
        public VersionInformation(uint major, uint minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
    }
    public class SolutionFile : File
    {
        public Solution Solution { get; protected set; }
        public string FormatVersionString { get; protected set; }
        public VersionInformation FormatVersionNumber
        {
            get
            {
                string[] ver = this.FormatVersionString.Split('.');
                uint major = 0;
                uint minor = 0;
                if (ver.Length > 1)
                    uint.TryParse(ver[0], out major);
                if (ver.Length > 2)
                    uint.TryParse(ver[1], out minor);

                return new VersionInformation(major, minor);
            }
        }
        public SolutionFile(string strPath = ""): base(strPath, FileTypes.Solution)
        {
            this.Solution = null;
            this.FormatVersionString = string.Empty;
        }

        protected virtual Solution ConstructSolution() { return null; }

        protected override void OnFileReadBegin()
        {
            
        }

        protected virtual void OnLineData(LineReadingEventArgs e){; }
        sealed protected override void OnLineReading(LineReadingEventArgs e)
        {
            if(e.Data != null)
            {
                string strLine = e.Data.Trim();
                if (strLine == string.Empty || strLine.Length <= 0)
                    return;

                bool bDiff = (e.Data.Length != strLine.Length);
                if(bDiff)
                    Debug.Print(string.Format("{0,3}: \"{1}\"[{2}] ||| \"{3}\"[{4}] ***DIFF***", e.Line, e.Data, e.Data.Length, strLine, strLine.Length));
                else
                    Debug.Print(string.Format("{0,3}: \"{1}\"[{2}] ||| \"{3}\"[{4}]",e.Line, e.Data, e.Data.Length, strLine, strLine.Length));

                if (strLine.Length > 0)
                {
                    if (this.Solution == null)
                    {
                        Regex regex = new Regex(@"Microsoft Visual Studio Solution File, Format Version (\d{2}){1}.(\d{2}){1}$");
                        if (!regex.IsMatch(strLine))
                        {
                            e.Cancel = true;
                            return;
                        }

                        this.FormatVersionString = strLine.Substring("@Microsoft Visual Studio Solution File, Format Version".Length).Trim();

                        this.Solution = ConstructSolution();
                    }
                    else
                    {
                        OnLineData(e);
                    }
                }
            }
        }
        protected override void OnFileReadEnd()
        {
            if (this.Solution != null)
            {
                if (!this.Solution.Valid)
                {
                    this.Solution = null;
                }
            }
        }
    }
}
