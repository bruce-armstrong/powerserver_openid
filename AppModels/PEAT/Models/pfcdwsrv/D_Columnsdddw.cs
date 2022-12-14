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
    [DataWindow("d_columnsdddw", DwStyle.Default)]
    public class D_Columnsdddw
    {
        [DwColumn("columnname")]
        public string Columnname { get; set; }

        [DwColumn("sort_order")]
        public string Sort_Order { get; set; }

        [DwColumn("display_column")]
        public string Display_Column { get; set; }

        [DwColumn("use_display")]
        public string Use_Display { get; set; }

    }

}