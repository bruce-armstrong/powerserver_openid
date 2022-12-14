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
    [DataWindow("d_json_repository", DwStyle.Grid)]
    public class D_Json_Repository
    {
        [DwColumn("object")]
        public string Object { get; set; }

        [DwColumn("pair")]
        public string Pair { get; set; }

        [DwColumn("val")]
        public string Val { get; set; }

        [DwColumn("oi")]
        public int? Oi { get; set; }

        [DwColumn("kind")]
        public double? Kind { get; set; }

    }

}