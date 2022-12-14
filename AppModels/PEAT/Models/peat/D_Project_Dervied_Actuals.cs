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
    [DataWindow("d_project_dervied_actuals", DwStyle.Default)]
    [Table("project_derived_item")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"project_derived_item\" ) @(_COLUMNS_PLACEHOLDER_) WHERE(    EXP1 =\"project_derived_item.project_id\"   OP =\"=\"    EXP2 =\":project_id\" ) ) ARG(NAME = \"project_id\" TYPE = number)")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Project_Dervied_Actuals
    {
        [DwColumn("project_derived_item", "name")]
        public string Derived_Item_Name { get; set; }

        [DwColumn("project_derived_item", "percentage")]
        public decimal? Default_Derived_Item_Percentage { get; set; }

        [DwColumn("project_derived_item", "actual_hours")]
        public decimal? Project_Derived_Item_Actual_Hours { get; set; }

        [Key]
        [Identity]
        [DwColumn("project_derived_item", "derived_item_id")]
        public int? Derived_Item_Id { get; set; }

        [Key]
        [DwColumn("project_derived_item", "project_id")]
        public int? Project_Derived_Item_Project_Id { get; set; }

    }

}