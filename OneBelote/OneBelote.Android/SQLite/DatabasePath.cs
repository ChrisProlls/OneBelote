using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OneBelote.SQLite;
using Xamarin.Forms;
using OneBelote.Droid.SQLite;
using System.IO;

[assembly: Dependency(typeof(DatabasePath))]
namespace OneBelote.Droid.SQLite
{
    public class DatabasePath : IFileHelper
    {
        public DatabasePath()
        {}
        
        public string GetLocalFilePath(string filePath)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filePath);
        }
    }
}