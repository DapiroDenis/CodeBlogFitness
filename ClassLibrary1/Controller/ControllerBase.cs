using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    abstract internal class ControllerBase
    {
        protected void Save<T>(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.Append))
            {
                formatter.Serialize(fs, item);
            }
        }

          User Load()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.Append))
            {
                return formatter.Deserialize(fs) as User;
            }
        }
    }
}
