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
    [DataWindow("d_timerlist", DwStyle.Default)]
    public class D_Timerlist
    {
        [DwColumn("index")]
        public int? Index { get; set; }

        [DwColumn("next_time")]
        public DateTime? Next_Time { get; set; }

    }

}