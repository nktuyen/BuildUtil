using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Build;
using Microsoft.Build.Construction;

namespace BuildUtil
{
    public class BuildCommandLine
    {
        public string[] Arguments { get; private set; }
        public Vs.Solution Solution { get; private set; }

        public Exception Error { get; private set; } = null;
        public BuildCommandLine(string[] args)
        {
            this.Arguments = args;
            this.Solution = null;
        }

        public bool Parse()
        {

            if (Arguments.Length <= 0) return false;

            if (this.Solution == null)
            {
                this.Error = new Exception("Unknown error");
                Vs.SolutionFile slnFile = new Vs.SolutionFile(Arguments[0]);
                {

                    if (!slnFile.Exist)
                    {
                        this.Error = new FileNotFoundException();
                        return false;
                    }

                    if (!slnFile.Load())
                    {
                        this.Error = new FileLoadException();
                        return false;
                    }

                    switch (slnFile.FormatVersionNumber.Major)
                    {
                        case 8:
                            {
                                Vs.SolutionFileV8 solutionFileV8 = new Vs.SolutionFileV8(this.Arguments[0]);
                                if (!solutionFileV8.Exist)
                                {
                                    this.Error = new FileNotFoundException();
                                    return false;
                                }

                                if (!solutionFileV8.Load())
                                {
                                    this.Error = new FileLoadException();
                                    return false;
                                }

                                if (solutionFileV8.Solution == null)
                                {
                                    this.Error = new FileLoadException();
                                    return false;
                                }

                                this.Solution = solutionFileV8.Solution;
                            }
                            break;
                        case 9:
                            {
                                Vs.SolutionFileV9 solutionFileV9 = new Vs.SolutionFileV9(this.Arguments[0]);
                                if (!solutionFileV9.Exist)
                                {
                                    this.Error = new FileNotFoundException();
                                    return false;
                                }

                                if (!solutionFileV9.Load())
                                {
                                    this.Error = new FileLoadException();
                                    return false;
                                }

                                if (solutionFileV9.Solution == null)
                                {
                                    this.Error = new FileLoadException();
                                    return false;
                                }

                                this.Solution = solutionFileV9.Solution;
                            }
                            break;
                        case 10:
                            {
                                Vs.SolutionFileV10 solutionFileV10 = new Vs.SolutionFileV10(this.Arguments[0]);
                                if (!solutionFileV10.Exist)
                                {
                                    this.Error = new FileNotFoundException();
                                    return false;
                                }

                                if (!solutionFileV10.Load())
                                {
                                    this.Error = new FileLoadException();
                                    return false;
                                }

                                if (solutionFileV10.Solution == null)
                                {
                                    this.Error = new FileLoadException();
                                    return false;
                                }

                                this.Solution = solutionFileV10.Solution;
                            }
                            break;
                        case 11:
                            {
                                Vs.SolutionFileV11 solutionFileV11 = new Vs.SolutionFileV11(this.Arguments[0]);
                                if (!solutionFileV11.Exist)
                                {
                                    this.Error = new FileNotFoundException();
                                    return false;
                                }

                                if (!solutionFileV11.Load())
                                {
                                    this.Error = new FileLoadException();
                                    return false;
                                }

                                if (solutionFileV11.Solution == null)
                                {
                                    this.Error = new FileLoadException();
                                    return false;
                                }

                                this.Solution = solutionFileV11.Solution;
                            }
                            break;
                        case 12:
                            {
                                Vs.SolutionFileV12 solutionFileV12 = new Vs.SolutionFileV12(this.Arguments[0]);
                                if (!solutionFileV12.Exist)
                                {
                                    this.Error = new FileNotFoundException();
                                    return false;
                                }

                                if (!solutionFileV12.Load())
                                {
                                    this.Error = new FileLoadException();
                                    return false;
                                }

                                if (solutionFileV12.Solution == null)
                                {
                                    this.Error = new FileLoadException();
                                    return false;
                                }

                                this.Solution = solutionFileV12.Solution;
                            }
                            break;
                        default:
                            this.Error = new NotSupportedException();
                            return false;
                    }
                }
            }

            return this.Solution != null;
        }
    }
}
