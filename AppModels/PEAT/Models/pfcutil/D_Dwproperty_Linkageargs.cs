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
    [DataWindow("d_dwproperty_linkageargs", DwStyle.Grid)]
    public class D_Dwproperty_Linkageargs
    {
        [DwColumn("mastercolumn")]
        public string Mastercolumn { get; set; }

        [DwColumn("detailcolumn")]
        public string Detailcolumn { get; set; }

    }

}