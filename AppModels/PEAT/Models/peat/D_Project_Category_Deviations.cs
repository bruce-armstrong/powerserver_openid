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
    [DataWindow("d_project_category_deviations", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM project_category_item, \r\n "
                  +"project_role, \r\n "
                  +"project_complexity, \r\n "
                  +"project_category \r\n "
                  +"WHERE ( project_category.category_id = project_category_item.category_id ) and \r\n "
                  +"( project_category.project_id = project_category_item.project_id ) and \r\n "
                  +"( project_complexity.complexity_id = project_category_item.complexity_id ) and \r\n "
                  +"( project_complexity.project_id = project_category_item.project_id ) and \r\n "
                  +"( project_role.role_id = project_category_item.role_id ) and \r\n "
                  +"( project_role.project_id = project_category_item.project_id ) and \r\n "
                  +"(project_category_item.project_id = :project_id) and \r\n "
                  +"((project_category_item.actual_hours <= \r\n "
                  +"project_category_item.estimated_hours * project_role.multipler * (1 - :deviation)) or \r\n "
                  +"(project_category_item.actual_hours >= \r\n "
                  +"project_category_item.estimated_hours * project_role.multipler * (1 + :deviation)))")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [DwParameter("deviation", typeof(double?))]
    public class D_Project_Category_Deviations
    {
        [DwColumn("project_category_item", "name")]
        public string Name { get; set; }

        [DwColumn("project_role", "name")]
        public string Project_Role_Name { get; set; }

        [DwColumn("project_complexity", "name")]
        public string Project_Complexity_Name { get; set; }

        [DwColumn("project_category_item", "category_id")]
        public int? Category_Id { get; set; }

        [DwColumn("project_category_item", "estimated_hours")]
        public decimal? Estimated_Hours { get; set; }

        [SqlCompute("project_category_item.estimated_hours * project_role.multipler")]
        public decimal? Compute_0006 { get; set; }

        [DwColumn("project_category_item", "actual_hours")]
        public decimal? Actual_Hours { get; set; }

        [DwColumn("project_category", "name")]
        public string Project_Category_Name { get; set; }

    }

}