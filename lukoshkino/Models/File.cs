﻿using System.ComponentModel.DataAnnotations;

namespace lukoshkino.Models
{
    public class File
    {
        public int Id { get; set; }

        [Required]
        public byte[] Path { get; set; }
    }
}
