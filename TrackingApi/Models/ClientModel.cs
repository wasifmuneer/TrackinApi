﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApi.Enums;

namespace TrackingApi.Models
{
    public class ClientModel
    {

        public string Id { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ApplicationTypes ApplicationType { get; set; }

        public bool Active { get; set; }

        public int RefreshTokenLifeTime { get; set; }

        [MaxLength(100)]
        public string AllowedOrigin { get; set; }
    }

    
}
