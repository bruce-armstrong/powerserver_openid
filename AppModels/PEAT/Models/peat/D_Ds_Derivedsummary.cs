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
    [DataWindow("d_ds_derivedsummary", DwStyle.Default)]
    [Table("project_derived_item")]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM project_derived_item \r\n "
                  +"WHERE project_derived_item.project_id = :project_id")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Ds_Derivedsummary
    {
        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project_derived_item", "name")]
        public string Name { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project_derived_item", "rate")]
        public decimal? Rate { get; set; }

        [DwColumn("project_derived_item", "actual_hours")]
        public decimal? Actual_Hours { get; set; }

        [Key]
        [Identity]
        [DwColumn("project_derived_item", "derived_item_id")]
        public int? Derived_Item_Id { get; set; }

        [Key]
        [DwColumn("project_derived_item", "project_id")]
        public int? Project_Id { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("(SELECT sum(project_category_item.estimated_hours* " 
                  + "project_role.multipler ) * "
                  + "(project_derived_item.percentage / 100) "
                  + "FROM project_category_item, "
                  + "project_complexity, "
                  + "project_role "
                  + "WHERE ( project_complexity.complexity_id = project_category_item.complexity_id ) and "
                  + "( project_category_item.role_id = project_role.role_id ) and "
                  + "( ( project_category_item.project_id = :project_id) ))")]
        public decimal? Estimated_Hours { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("project_derived_item.actual_hours  * project_derived_item.rate")]
        public decimal? Actual_Cost { get; set; }

    }

}