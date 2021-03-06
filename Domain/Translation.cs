﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Translation
    {
        public int TranslationID { get; set; }

        [MaxLength(40960)]
        public string Value { get; set; }

        public int MultiLangStringID { get; set; }
        public virtual MultiLangString MultiLangString { get; set; }

        [MaxLength(12)]
        public string Culture { get; set; }
    }
}