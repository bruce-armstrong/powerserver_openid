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
    [DataWindow("d_project_analyzer_summary", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("SELECT 'Derived Items', \r\n "
                  +"project_derived_item.name, \r\n "
                  +"project_derived_item.rate, \r\n "
                  +"(SELECT sum(project_category_item.estimated_hours* \r\n "
                  +"project_role.multipler ) * (project_derived_item.percentage / 100) \r\n "
                  +"FROM project_category_item, \r\n "
                  +"project_complexity, \r\n "
                  +"project_role \r\n "
                  +"WHERE ( project_complexity.complexity_id = project_category_item.complexity_id ) and \r\n "
                  +"( project_category_item.role_id = project_role.role_id ) and \r\n "
                  +"( ( project_category_item.project_id = :project_id) )), \r\n "
                  +"project_derived_item.actual_hours \r\n "
                  +"FROM project_derived_item \r\n "
                  +"WHERE ( ( project_derived_item.project_id = :project_id ) ) \r\n "
                  +"UNION \r\n "
                  +"SELECT project_category.name, \r\n "
                  +"project_category_item.name, \r\n "
                  +"project_role.rate, \r\n "
                  +"(project_category_item.estimated_hours * project_role.multipler), \r\n "
                  +"project_category_item.actual_hours \r\n "
                  +"FROM project_category_item, \r\n "
                  +"project_role, \r\n "
                  +"project_category \r\n "
                  +"WHERE ( project_category_item.role_id = project_role.role_id ) and \r\n "
                  +"( project_category.category_id = project_category_item.category_id ) and \r\n "
                  +"( ( project_category_item.project_id = :project_id ) )")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    public class D_Project_Analyzer_Summary
    {
        [DwColumn("compute_0001")]
        public string Group_Item { get; set; }

        [DwColumn("name")]
        public string Name { get; set; }

        [DwColumn("rate")]
        public decimal? Rate { get; set; }

        [DwColumn("compute_0004")]
        public decimal? Estimated_Hours { get; set; }

        [DwColumn("actual_hours")]
        public decimal? Project_Derived_Item_Actual_Hours { get; set; }

    }

}