using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserIdentityDAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
    }
}
