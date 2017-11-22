using System;
using System.Collections.Generic;
using System.Text;

namespace OneBelote.SQLite
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
