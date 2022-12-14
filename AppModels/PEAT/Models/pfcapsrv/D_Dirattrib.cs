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
    [DataWindow("d_dirattrib", DwStyle.Default)]
    public class D_Dirattrib
    {
        [DwColumn("filename")]
        public string Filename { get; set; }

        [DwColumn("lastwritedate")]
        public DateTime? Lastwritedate { get; set; }

        [DwColumn("lastwritetime")]
        public TimeSpan? Lastwritetime { get; set; }

        [DwColumn("filesize")]
        public double? Filesize { get; set; }

        [DwColumn("readonly")]
        public double? Readonly { get; set; }

        [DwColumn("hidden")]
        public double? Hidden { get; set; }

        [DwColumn("system")]
        public double? System { get; set; }

        [DwColumn("subdirectory")]
        public double? Subdirectory { get; set; }

        [DwColumn("archive")]
        public double? Archive { get; set; }

        [DwColumn("drive")]
        public double? Drive { get; set; }

        [DwColumn("altfilename")]
        public string Altfilename { get; set; }

        [DwColumn("creationdate")]
        public DateTime? Creationdate { get; set; }

        [DwColumn("creationtime")]
        public TimeSpan? Creationtime { get; set; }

        [DwColumn("lastaccessdate")]
        public DateTime? Lastaccessdate { get; set; }

        [DwColumn("extension")]
        public string Extension { get; set; }

        [DwColumn("sortfilename")]
        public string Sortfilename { get; set; }

        [DwColumn("filegroup")]
        public double? Filegroup { get; set; }

    }

}