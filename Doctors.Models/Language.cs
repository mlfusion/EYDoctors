﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Doctors.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
