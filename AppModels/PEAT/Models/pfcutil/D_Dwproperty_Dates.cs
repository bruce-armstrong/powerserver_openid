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
    [DataWindow("d_dwproperty_dates", DwStyle.Default)]
    public class D_Dwproperty_Dates
    {
        [DwColumn("date")]
        public DateTime? Date { get; set; }

    }

}