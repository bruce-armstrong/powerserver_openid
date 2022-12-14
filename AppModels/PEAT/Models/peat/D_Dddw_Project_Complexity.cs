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
    [DataWindow("d_dddw_project_complexity", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"project_complexity\" ) @(_COLUMNS_PLACEHOLDER_) WHERE(    EXP1 =\"project_complexity.project_id\"   OP =\"=\"    EXP2 =\":project_id\" ) ) ORDER(NAME=\"project_complexity.name\" ASC=yes ) ARG(NAME = \"project_id\" TYPE = number)")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    public class D_Dddw_Project_Complexity
    {
        [DwColumn("project_complexity", "complexity_id")]
        public int? Complexity_Id { get; set; }

        [DwColumn("project_complexity", "name")]
        public string Name { get; set; }

        [DwColumn("project_complexity", "estimated_hours")]
        public decimal? Estimated_Hours { get; set; }

    }

}