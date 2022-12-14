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
    [DataWindow("d_messageprint", DwStyle.Default)]
    public class D_Messageprint
    {
        [DwColumn("title")]
        public string Title { get; set; }

        [DwColumn("message")]
        public string Message { get; set; }

        [DwColumn("comments")]
        public string Comments { get; set; }

    }

}