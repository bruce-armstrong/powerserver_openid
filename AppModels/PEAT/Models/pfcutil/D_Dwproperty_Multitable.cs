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
    [DataWindow("d_dwproperty_multitable", DwStyle.Grid)]
    public class D_Dwproperty_Multitable
    {
        [DwColumn("pfc_sort")]
        public double? Pfc_Sort { get; set; }

        [DwColumn("pfc_register")]
        public string Pfc_Register { get; set; }

        [DwColumn("pfc_table")]
        public string Pfc_Table { get; set; }

        [DwColumn("pfc_column")]
        public string Pfc_Column { get; set; }

        [DwColumn("pfc_key")]
        public string Pfc_Key { get; set; }

        [DwColumn("pfc_update")]
        public string Pfc_Update { get; set; }

        [DwColumn("pfc_keyinplace")]
        public string Pfc_Keyinplace { get; set; }

        [DwColumn("pfc_whereoption")]
        public double? Pfc_Whereoption { get; set; }

    }

}