﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptlex.Net.Entities
{
    public class Metadata
    {
        public string? id { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? key { get; set; }
        public string? value { get; set; }
        public bool visible { get; set; }
    }
}