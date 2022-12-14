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
    [DataWindow("d_filtersimple", DwStyle.Default)]
    public class D_Filtersimple
    {
        [DwColumn("colname")]
        public string Colname { get; set; }

        [DwColumn("oper")]
        public string Oper { get; set; }

        [DwColumn("colvalue")]
        public string Colvalue { get; set; }

        [DwColumn("and_or")]
        public string And_Or { get; set; }

    }

}