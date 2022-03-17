﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIWithSwagger.Dtos
{
    public record BookDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal Price { get; set; }
    }
}
