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
    [DataWindow("d_sortdragdrop", DwStyle.Default)]
    public class D_Sortdragdrop
    {
        [DwColumn("columnname")]
        public string Columnname { get; set; }

        [DwColumn("sort_order")]
        public string Sort_Order { get; set; }

        [DwColumn("displayname")]
        public string Displayname { get; set; }

        [DwColumn("use_display")]
        public string Use_Display { get; set; }

    }

}