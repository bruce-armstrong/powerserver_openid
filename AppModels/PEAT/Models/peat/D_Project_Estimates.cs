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
    [DataWindow("d_project_estimates", DwStyle.Default)]
    [Table("project_category_item")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"project_category_item\" )  TABLE(NAME=\"project_role\" ) @(_COLUMNS_PLACEHOLDER_) JOIN (LEFT=\"project_role.role_id\"    OP =\"=\"RIGHT=\"project_category_item.role_id\" )    JOIN (LEFT=\"project_role.project_id\"    OP =\"=\"RIGHT=\"project_category_item.project_id\" )WHERE(    EXP1 =\"( ( project_category_item.project_id\"   OP =\"=\"    EXP2 =\":project_id ) )\" ) ) ARG(NAME = \"project_id\" TYPE = number)")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.Update)]
    public class D_Project_Estimates
    {
        [ConcurrencyCheck]
        [DwColumn("project_category_item", "name")]
        public string Project_Category_Item_Name { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_category_item", "complexity_id")]
        public int? Project_Category_Item_Complexity_Id { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_category_item", "estimated_hours")]
        public decimal? Project_Category_Item_Estimated_Hours { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_category_item", "role_id")]
        public int? Project_Category_Item_Role_Id { get; set; }

        [Key]
        [DwColumn("project_category_item", "category_id")]
        public int? Project_Category_Item_Category_Id { get; set; }

        [Key]
        [DwColumn("project_category_item", "project_id")]
        public int? Project_Category_Item_Project_Id { get; set; }

        [Key]
        [Identity]
        [DwColumn("project_category_item", "category_item_id")]
        public int? Project_Category_Item_Category_Item_Id { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("(project_category_item.estimated_hours * project_role.multipler)    ")]
        public decimal? Adjusted_Hours { get; set; }

    }

}