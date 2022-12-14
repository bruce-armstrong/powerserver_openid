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
    [DataWindow("d_columnnames", DwStyle.Default)]
    public class D_Columnnames
    {
        [DwColumn("columnname")]
        public string Columnname { get; set; }

        [DwColumn("display_name")]
        public string Display_Name { get; set; }

        [DwColumn("db_name")]
        public string Db_Name { get; set; }

    }

}