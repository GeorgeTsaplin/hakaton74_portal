﻿
// This code was generated by RAML Web Api 2 Scaffolder

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Latitude55.Api.Models
{
    public partial class Statistics
    {
        

        [Required]
		[JsonProperty("caption")]
        public string Caption { get; set; }

        [Required]
		[JsonProperty("amount")]
        public int Amount { get; set; }
    } // end class

} // end Models namespace

