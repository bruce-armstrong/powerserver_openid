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
    [DataWindow("d_project_derived_item", DwStyle.Default)]
    [Table("project_derived_item")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"project_derived_item\" ) @(_COLUMNS_PLACEHOLDER_) WHERE(    EXP1 =\"project_derived_item.project_id\"   OP =\"=\"    EXP2 =\":project_id\" ) ) ORDER(NAME=\"project_derived_item.name\" ASC=yes ) ARG(NAME = \"project_id\" TYPE = number)")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Project_Derived_Item
    {
        [Key]
        [Identity]
        [DwColumn("project_derived_item", "derived_item_id")]
        public int? Derived_Item_Id { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_derived_item", "project_id")]
        public int? Project_Id { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_derived_item", "name")]
        public string Name { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_derived_item", "percentage")]
        public decimal? Percentage { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_derived_item", "rate")]
        public decimal? Rate { get; set; }

    }

}