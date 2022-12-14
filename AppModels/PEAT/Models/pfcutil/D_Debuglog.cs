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
    [DataWindow("d_debuglog", DwStyle.Default)]
    public class D_Debuglog
    {
        [DwColumn("When")]
        public DateTime? When { get; set; }

        [DwColumn("MSG")]
        public string Msg { get; set; }

    }

}