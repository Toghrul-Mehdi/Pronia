﻿using Pronia.Models;
using System.ComponentModel.DataAnnotations;

namespace Pronio.Models
{
    public class Slider : BaseEntity
    {
        [MaxLength(32)]
        public string Title { get; set; } = null!;
        [MaxLength(64)]
        public string Subtitle { get; set; } = null!;        
        public string ImageUrl { get; set; } = null!;
    }
}
