﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.Append))
            {
                formatter.Serialize(fs, item);
            }
        }

        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.Append))
            {
                if (formatter.Deserialize(fs) is T items)
                { return items; }
                else
                { return default(T); }
            }
        }
    }
}
