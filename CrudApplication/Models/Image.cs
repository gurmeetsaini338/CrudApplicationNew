﻿using Microsoft.Build.Framework;

namespace CrudApplication.Models
{
    public class Image
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
