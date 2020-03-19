using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Core.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        public string FullName
        {
            get
            {
                return $"{Title} {FirstName} {LastName}";
            }
        }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public FormFile ProfilePicture { get; set; }
    }
}
