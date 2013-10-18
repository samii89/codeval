// -----------------------------------------------------------------------
// <copyright file="MyBuffer.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Oct17T1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MyBuffer
    {
        public string StoringToBuffer()
        {
            string path = @"C:\source.cs";
            string fileContent = null;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    fileContent = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            return fileContent;
        }
    }
}
