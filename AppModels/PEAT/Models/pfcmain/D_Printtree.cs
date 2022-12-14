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
    [DataWindow("d_printtree", DwStyle.Default)]
    public class D_Printtree
    {
        [DwColumn("fullname")]
        public string Fullname { get; set; }

        [DwColumn("name")]
        public string Name { get; set; }

        [DwColumn("bmpname")]
        public string Bmpname { get; set; }

        [DwColumn("selectedbmpname")]
        public string Selectedbmpname { get; set; }

        [DwColumn("selected")]
        public double? Selected { get; set; }

        [DwColumn("open")]
        public double? Open { get; set; }

        [DwColumn("children")]
        public double? Children { get; set; }

        [DwColumn("siblings")]
        public double? Siblings { get; set; }

        [DwColumn("level")]
        public double? Level { get; set; }

        [DwColumn("bmpname1")]
        public string Bmpname1 { get; set; }

        [DwColumn("bmpname2")]
        public string Bmpname2 { get; set; }

        [DwColumn("bmpname3")]
        public string Bmpname3 { get; set; }

        [DwColumn("bmpname4")]
        public string Bmpname4 { get; set; }

        [DwColumn("bmpname5")]
        public string Bmpname5 { get; set; }

        [DwColumn("bmpname6")]
        public string Bmpname6 { get; set; }

        [DwColumn("bmpname7")]
        public string Bmpname7 { get; set; }

        [DwColumn("bmpname8")]
        public string Bmpname8 { get; set; }

        [DwColumn("bmpname9")]
        public string Bmpname9 { get; set; }

        [DwColumn("bmpname10")]
        public string Bmpname10 { get; set; }

        [DwColumn("selectedbmpname1")]
        public string Selectedbmpname1 { get; set; }

        [DwColumn("selectedbmpname2")]
        public string Selectedbmpname2 { get; set; }

        [DwColumn("selectedbmpname3")]
        public string Selectedbmpname3 { get; set; }

        [DwColumn("selectedbmpname4")]
        public string Selectedbmpname4 { get; set; }

        [DwColumn("selectedbmpname5")]
        public string Selectedbmpname5 { get; set; }

        [DwColumn("selectedbmpname6")]
        public string Selectedbmpname6 { get; set; }

        [DwColumn("selectedbmpname7")]
        public string Selectedbmpname7 { get; set; }

        [DwColumn("selectedbmpname8")]
        public string Selectedbmpname8 { get; set; }

        [DwColumn("selectedbmpname9")]
        public string Selectedbmpname9 { get; set; }

        [DwColumn("selectedbmpname10")]
        public string Selectedbmpname10 { get; set; }

        [DwColumn("parentsiblings")]
        public string Parentsiblings { get; set; }

    }

}