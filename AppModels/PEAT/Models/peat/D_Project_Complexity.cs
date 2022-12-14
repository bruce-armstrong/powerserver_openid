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
    [DataWindow("d_project_complexity", DwStyle.Default)]
    [Table("project_complexity")]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM project_complexity \r\n "
                  +"WHERE project_complexity.project_id = :project_id \r\n "
                  +"ORDER BY project_complexity.name ASC")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Project_Complexity
    {
        [Key]
        [DwColumn("project_complexity", "complexity_id")]
        public int? Complexity_Id { get; set; }

        [Identity]
        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("project_complexity.complexity_id as complexity")]
        public int? Complexity { get; set; }

        [Key]
        [DwColumn("project_complexity", "project_id")]
        public int? Project_Id { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_complexity", "name")]
        public string Name { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_complexity", "estimated_hours")]
        public decimal? Estimated_Hours { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("(SELECT count(*) " 
                  + "FROM project_category_item "
                  + "WHERE project_category_item.project_id = :project_id AND "
                  + "project_category_item.complexity_id = project_complexity.complexity_id)")]
        public int? Dependent_Count { get; set; }

    }

}