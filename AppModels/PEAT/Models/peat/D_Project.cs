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
    [DataWindow("d_project", DwStyle.Default)]
    [Table("project")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"project\" ) @(_COLUMNS_PLACEHOLDER_) WHERE(    EXP1 =\"project.project_id\"   OP =\"=\"    EXP2 =\":projec_id\" ) ) ARG(NAME = \"projec_id\" TYPE = number)")]
    #endregion
    [DwParameter("projec_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.Update)]
    public class D_Project
    {
        [ConcurrencyCheck]
        [DwColumn("project", "name")]
        public string Name { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project", "project_leader")]
        public string Project_Leader { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project", "start_date", TypeName = "date")]
        public DateTime? Start_Date { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project", "end_date", TypeName = "date")]
        public DateTime? End_Date { get; set; }

        [Key]
        [Identity]
        [DwColumn("project", "project_id")]
        public int? Project_Id { get; set; }

    }

}