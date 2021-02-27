using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository_Domain;
using Repository_Source;

namespace RepositoryPattern
{
    public class OperatorXMLRepository : XMLRepositoryBase<XMLSet<Operator>, Operator, int>, IOperatorRepository
    {
        public OperatorXMLRepository() : base("OperatorInformation.xml")
        {

        }
    }
}