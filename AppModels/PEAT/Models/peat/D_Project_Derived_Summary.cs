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
    [DataWindow("d_project_derived_summary", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM project_derived_item \r\n "
                  +"WHERE project_derived_item.project_id = :project_id")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    public class D_Project_Derived_Summary
    {
        [DwColumn("project_derived_item", "name")]
        public string Name { get; set; }

        [DwColumn("project_derived_item", "percentage")]
        public decimal? Percentage { get; set; }

        [DwColumn("project_derived_item", "rate")]
        public decimal? Rate { get; set; }

        [SqlCompute("(SELECT sum(project_category_item.estimated_hours* " 
                  + "project_role.multipler ) "
                  + "FROM project_category_item, "
                  + "project_complexity, "
                  + "project_role "
                  + "WHERE ( project_complexity.complexity_id = project_category_item.complexity_id ) and "
                  + "( project_category_item.role_id = project_role.role_id ) and "
                  + "( ( project_category_item.project_id = :project_id) ))")]
        public decimal? Compute_0004 { get; set; }

    }

}