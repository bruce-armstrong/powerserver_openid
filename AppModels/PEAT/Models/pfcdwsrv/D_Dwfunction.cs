using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using SnapObjects.Data;
using DWNet.Data;
using Newtonsoft.Json;
using System.Collections;

namespace PEAT
{
    [DataWindow("d_dwfunction", DwStyle.Default)]
    public class D_Dwfunction
    {
        [DwColumn("category")]
        public string Category { get; set; }

        [DwColumn("functionname")]
        public string Functionname { get; set; }

        [DwColumn("syntax")]
        public string Syntax { get; set; }

        [DwColumn("help")]
        public string Help { get; set; }

    }

}