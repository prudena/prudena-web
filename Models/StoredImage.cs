﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class StoredImage
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        public Guid UID { get; set; }

        [StringLength(1024)]
        public string AltTag { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }
    }

}