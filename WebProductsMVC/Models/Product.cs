﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebProductsMVC.Models
{
    public class Product
    {
        [Key()]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
        [DisplayName("Name")]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [DisplayName("Available Date")]
        public DateTime AvailableDate { get; set; }
    }
}