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
    [DataWindow("d_project_team", DwStyle.Default)]
    [Table("project_role")]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM project_role \r\n "
                  +"WHERE project_role.project_id = :project_id \r\n "
                  +"ORDER BY project_role.name ASC")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Project_Team
    {
        [Key]
        [DwColumn("project_role", "role_id")]
        public int? Role_Id { get; set; }

        [Identity]
        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("project_role.role_id role")]
        public int? Role { get; set; }

        [Key]
        [DwColumn("project_role", "project_id")]
        public int? Project_Id { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_role", "name")]
        public string Name { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_role", "rate")]
        public decimal? Rate { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project_role", "multipler")]
        public decimal? Multipler { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [SqlCompute("(SELECT count(*) " 
                  + "FROM project_category_item "
                  + "WHERE project_category_item.project_id = :project_id AND "
                  + "project_category_item.role_id = project_role.role_id)")]
        public int? Dependent_Count { get; set; }

    }

}