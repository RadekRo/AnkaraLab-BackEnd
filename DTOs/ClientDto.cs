﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class ClientDto
    {
        private int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public double Discount { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool Newsletter { get; set; } =  false;
        public bool IsActive { get; set; } = true;
        public bool IsAdmin { get; set; } = false;
        public int Status { get; set; } = 1;
        public string FtpLogin { get; set; } = string.Empty;
        public string FtpPassword { get; set; } = string.Empty;
        public int Epoint { get; set; } = 0;
        public double Deposit { get; set; } = 0;
        public DateTime Deadline { get; set; }
        public string Street { get; set; } = string.Empty;
        public string LocalNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
