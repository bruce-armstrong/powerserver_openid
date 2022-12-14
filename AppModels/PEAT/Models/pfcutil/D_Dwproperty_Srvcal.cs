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
    [DataWindow("d_dwproperty_srvcal", DwStyle.Default)]
    public class D_Dwproperty_Srvcal
    {
        [DwColumn("register")]
        public string Register { get; set; }

        [DwColumn("columnname")]
        public string Columnname { get; set; }

        [DwColumn("style")]
        public double? Style { get; set; }

    }

}