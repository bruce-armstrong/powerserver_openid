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
    [DataWindow("d_sqlspyprint", DwStyle.Default)]
    public class D_Sqlspyprint
    {
        [DwColumn("text")]
        public string Text { get; set; }

    }

}