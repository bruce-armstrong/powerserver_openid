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
    [DataWindow("d_project_category", DwStyle.Default)]
    [Table("project_category")]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM project_category \r\n "
                  +"WHERE project_category.project_id = :project_id \r\n "
                  +"ORDER BY project_category.name ASC")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Project_Category
    {
        [Key]
        [DwColumn("project_category", "category_id")]
        public int? Category_Id { get; set; }

        [Identity]
        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("project_category.category_id category")]
        public int? Category { get; set; }

        [Key]
        [DwColumn("project_category", "project_id")]
        public int? Project_Id { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_category", "name")]
        public string Name { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("(SELECT count(*) " 
                  + "FROM project_category_item "
                  + "WHERE project_category_item.project_id = :project_id AND "
                  + "project_category_item.category_id = project_category.category_id)")]
        public int? Dependent_Count { get; set; }

    }

}