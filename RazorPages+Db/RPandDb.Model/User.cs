﻿using System.ComponentModel.DataAnnotations;

namespace RPandDb.Model
{
    public class User
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
