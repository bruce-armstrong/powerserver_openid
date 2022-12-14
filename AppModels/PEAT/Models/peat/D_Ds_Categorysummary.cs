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
    [DataWindow("d_ds_categorysummary", DwStyle.Default)]
    [Table("project_category_item")]
    #region DwSelectAttribute  
    [DwSelect("SELECT  @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM project_category_item ,           project_role \r\n "
                  +"WHERE ( project_role.role_id = project_category_item.role_id ) and \r\n "
                  +"( ( project_category_item.project_id = :project_id ) and \r\n "
                  +"( project_category_item.category_id = :category_id ) )")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [DwParameter("category_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Ds_Categorysummary
    {
        [Key]
        [Identity]
        [DwColumn("project_category_item", "category_item_id")]
        public int? Category_Item_Id { get; set; }

        [Key]
        [DwColumn("project_category_item", "project_id")]
        public int? Project_Id { get; set; }

        [Key]
        [DwColumn("project_category_item", "category_id")]
        public int? Default_Category_Id { get; set; }

        [DwColumn("project_category_item", "complexity_id")]
        public int? Complexity_Id { get; set; }

        [DwColumn("project_category_item", "role_id")]
        public int? Role_Id { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project_category_item", "name")]
        public string Name { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project_category_item", "estimated_hours")]
        public decimal? Estimated_Hours_1 { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project_category_item", "actual_hours")]
        public decimal? Actual_Hours { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project_role", "name")]
        public string Role_Name { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project_role", "rate")]
        public decimal? Role_Rate { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project_role", "multipler")]
        public decimal? Role_Multiplier { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("project_category_item.estimated_hours * project_role.multipler as estimated_hours")]
        public decimal? Estimated_Hours { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("project_category_item.estimated_hours * project_role.rate * project_role.multipler as estimated_cost")]
        public decimal? Estimated_Cost { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("project_category_item.actual_hours * project_role.rate as actual_cost")]
        public decimal? Actual_Cost { get; set; }

    }

}