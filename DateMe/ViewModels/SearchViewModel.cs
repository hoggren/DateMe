﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DateMe.ViewModels
{
    public class SearchViewModel
    {
        public string NicknameQuery { get; set; }

        public string InterestQuery { get; set; }

        public string CityQuery { get; set; }
    }
}