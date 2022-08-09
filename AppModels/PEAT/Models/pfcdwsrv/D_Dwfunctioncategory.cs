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
    [DataWindow("d_dwfunctioncategory", DwStyle.Default)]
    public class D_Dwfunctioncategory
    {
        [DwColumn("category")]
        public string Category { get; set; }

    }

}