﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USERMAINTANCER.Entities
{
    class User
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
         => string.Format(
             "{0} {1}",
             LastName,
             FirstName);
    
    }
}