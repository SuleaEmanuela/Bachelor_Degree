﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralizedQrCodeApp.Data.DataModels
{
    public partial class Customer
    {
        [Column("CustomerId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Customer name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name is 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string Position { get; set; }

    }
}
