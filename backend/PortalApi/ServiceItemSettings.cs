﻿
// This code was generated by RAML Web Api 2 Scaffolder

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Latitude55.Api.Models
{
    public partial class ServiceItemSettings
    {
        [Required]
		[JsonProperty("attributes")]
        public Attribute[] Attributes { get; set; }
    } // end class

} // end Models namespace

