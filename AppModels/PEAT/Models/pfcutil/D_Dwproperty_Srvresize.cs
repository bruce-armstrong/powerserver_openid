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
    [DataWindow("d_dwproperty_srvresize", DwStyle.Default)]
    public class D_Dwproperty_Srvresize
    {
        [DwColumn("objectname")]
        public string Objectname { get; set; }

        [DwColumn("register")]
        public string Register { get; set; }

        [DwColumn("method")]
        public string Method { get; set; }

        [DwColumn("movex")]
        public double? Movex { get; set; }

        [DwColumn("movey")]
        public double? Movey { get; set; }

        [DwColumn("scalex")]
        public double? Scalex { get; set; }

        [DwColumn("scaley")]
        public double? Scaley { get; set; }

    }

}