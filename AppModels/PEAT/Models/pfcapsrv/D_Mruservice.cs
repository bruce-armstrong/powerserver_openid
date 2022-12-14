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
    [DataWindow("d_mruservice", DwStyle.Default)]
    public class D_Mruservice
    {
        [DwColumn("s_id")]
        public string S_Id { get; set; }

        [DwColumn("s_classname")]
        public string S_Classname { get; set; }

        [DwColumn("s_menuitemname")]
        public string S_Menuitemname { get; set; }

        [DwColumn("s_menuitemkey")]
        public string S_Menuitemkey { get; set; }

        [DwColumn("s_menuitemmhelp")]
        public string S_Menuitemmhelp { get; set; }

        [DwColumn("n_identity")]
        public double? N_Identity { get; set; }

    }

}