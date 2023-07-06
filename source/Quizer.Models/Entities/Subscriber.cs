﻿using Quizer.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.Entities
{
    public class Subscriber : BaseEntity<Guid>
    {
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
