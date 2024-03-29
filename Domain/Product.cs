﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Size { get; set; } = string.Empty;
        [Required]
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        [Required]
        public int Deadline { get; set; }
        [Required]
        public bool IsAvaliable { get; set; }
        [Required]
        [MaxLength(4)]
        public int PhotoHeight { get; set; }
        [Required]
        [MaxLength(4)]
        public int PhotoWidth { get; set; }
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
    }
}
