using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Vs
{
    public enum FileTypes
    {
        Unknown = 0,
        Solution,
        Project,
        Source,
    }
    public class LineReadingEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
        public string Data { get; set; }
        public long Line { get; internal set; }
        public LineReadingEventArgs()
        {
            this.Cancel = false;
            this.Data = string.Empty;
            this.Line = 0;
        }
    }
    public class File
    {
        private System.IO.FileInfo Info { get; set; }
        public FileTypes Kind{ get; protected set; }
        public string Path {
            get
            {
                return this.Info.FullName;
            }
            set
            {
                this.Info = new System.IO.FileInfo(value);
            }
        }
        
        public bool Exist
        {
            get
            {
                return this.Info.Exists;
            }
        }

        public string DirectoryPath
        {
            get
            {
                return this.Info.DirectoryName;
            }
        }

        public string Name
        {
            get
            {
                return this.Info.Name;
            }
        }

        public string Extension
        {
            get
            {
                return this.Info.Extension;
            }
        }

        public long Size
        {
            get
            {
                return this.Info.Length;
            }
        }

        public File(string strPath = "", FileTypes kind = FileTypes.Unknown)
        {
            this.Path = strPath;
            this.Kind = kind;
            try
            {
                this.Info = new System.IO.FileInfo(this.Path);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        protected virtual void OnFileReadBegin() {; }
        protected virtual void OnLineReading(LineReadingEventArgs e){ ; }
        protected virtual void OnFileReadEnd() {; }

        public bool Load()
        {
            System.IO.StreamReader streamReader = null;
            try
            {
                streamReader = new System.IO.StreamReader(this.Path);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                streamReader = null;
            }

            if (streamReader == null)
            {
                return false;
            }

            LineReadingEventArgs e = new LineReadingEventArgs();
            OnFileReadBegin();
            while((e.Data = streamReader.ReadLine()) != null)
            {
                e.Line++;
                e.Cancel = false;
                OnLineReading(e);
                if (e.Cancel)
                    break;
            }
            streamReader.Close();
            OnFileReadEnd();
            return true;
        }
    }
}
