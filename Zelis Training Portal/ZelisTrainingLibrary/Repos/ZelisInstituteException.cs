using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZelisTrainingLibrary.Repos
{
    public class ZelisInstituteException:Exception
    {
        public ZelisInstituteException(string err):base(err)
        {
            
        }
    }
}
