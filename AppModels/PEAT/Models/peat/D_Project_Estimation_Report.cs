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
    [DataWindow("d_project_estimation_report", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"project\" ) @(_COLUMNS_PLACEHOLDER_) WHERE(    EXP1 =\"project.project_id\"   OP =\"=\"    EXP2 =\":project_id\" ) ) ARG(NAME = \"project_id\" TYPE = number)")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    public class D_Project_Estimation_Report
    {
        [DwColumn("project", "name")]
        public string Name { get; set; }

        [DwColumn("project", "project_leader")]
        public string Project_Leader { get; set; }

        [SqlCompute("0")]
        public int? Total_Estimated_Hours { get; set; }

        [SqlCompute("0")]
        public int? Total_Estimated_Cost { get; set; }

        [DwColumn("project", "start_date", TypeName = "date")]
        public DateTime? Start_Date { get; set; }

        [DwColumn("project", "end_date", TypeName = "date")]
        public DateTime? End_Date { get; set; }

    }

}