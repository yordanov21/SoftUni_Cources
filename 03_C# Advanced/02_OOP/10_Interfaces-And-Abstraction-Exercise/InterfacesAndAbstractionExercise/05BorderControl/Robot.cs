﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05BorderControl
{
    public class Robot :IIndentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
      
        public string Id { get; private set; }
    }
}
