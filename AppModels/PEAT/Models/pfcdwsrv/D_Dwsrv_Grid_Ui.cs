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
    [DataWindow("d_dwsrv_grid_ui", DwStyle.Grid)]
    public class D_Dwsrv_Grid_Ui
    {
        [DwColumn("column_visible")]
        public string Column_Visible { get; set; }

        [DwColumn("column_name")]
        public string Column_Name { get; set; }

        [DwColumn("column_order")]
        public string Column_Order { get; set; }

        [DwColumn("column_width")]
        public string Column_Width { get; set; }

        [DwColumn("column_id")]
        public string Column_Id { get; set; }

        [DwColumn("selector")]
        public string Selector { get; set; }

    }

}