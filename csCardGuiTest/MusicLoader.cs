using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csCardGuiTest
{
    internal static class MusicLoader
    {
        /// <summary> Iterates the root directory 'dir' and adds the full path
        /// name to the returned list. Does not recurse into subdirs, and
        /// will return an empty list on exception/error. Does not discriminate
        /// with regard to music file extension. </summary>
        /// <param name="dir">Directory to be searched for files.</param>
        /// <returns>A list of strings containing the full path to the files, or an empty list on error.</returns>
        public static List<string> GetMusicInDir(string dir)
        {
            try
            {
                if (Directory.Exists(dir))
                {
                    System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(dir);
                    var fileInfos = dirInfo.GetFiles("*.*");
                    List<string> pathList = new();
                    foreach (FileInfo fi in fileInfos)
                    {
                        pathList.Add(fi.FullName);
                    }

                    return pathList;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return new();
        }
    }
}
