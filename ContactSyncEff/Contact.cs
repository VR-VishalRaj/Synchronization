using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSyncEff
{
    public class Contact
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public DateTime LastModified { get; set; }
        public string IsDeleted { get; set; }
    }
}
