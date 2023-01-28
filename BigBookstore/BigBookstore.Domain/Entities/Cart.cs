﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }

        public ICollection<CartItem> Books { get; set; } = new List<CartItem>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
