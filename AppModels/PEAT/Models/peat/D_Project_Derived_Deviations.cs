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
    [DataWindow("d_project_derived_deviations", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("WITH x AS (SELECT sum(project_category_item.estimated_hours * \r\n "
                  +"project_role.multipler ) as est_hours \r\n "
                  +"FROM project_category_item, \r\n "
                  +"project_complexity, \r\n "
                  +"project_role \r\n "
                  +"WHERE ( project_complexity.complexity_id = project_category_item.complexity_id ) and \r\n "
                  +"( project_category_item.role_id = project_role.role_id ) and \r\n "
                  +"( ( project_category_item.project_id = :project_id) )) \r\n "
                  +"SELECT project_derived_item.derived_item_id, \r\n "
                  +"project_derived_item.project_id, \r\n "
                  +"project_derived_item.actual_hours, \r\n "
                  +"project_derived_item.name, \r\n "
                  +"project_derived_item.percentage, \r\n "
                  +"x.est_hours, \r\n "
                  +"(project_derived_item.actual_hours / x.est_hours) \r\n "
                  +"FROM project_derived_item, \r\n "
                  +"x \r\n "
                  +"WHERE (project_derived_item.project_id = :project_id ) and \r\n "
                  +"((project_derived_item.actual_hours >= \r\n "
                  +"((project_derived_item.percentage / 100) * x.est_hours) * (1 + :deviation)) or \r\n "
                  +"(project_derived_item.actual_hours <= \r\n "
                  +"((project_derived_item.percentage / 100) * x.est_hours) * (1 - :deviation)))")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [DwParameter("deviation", typeof(double?))]
    public class D_Project_Derived_Deviations
    {
        [DwColumn("derived_item_id")]
        public int? Derived_Item_Id { get; set; }

        [DwColumn("project_id")]
        public int? Project_Derived_Item_Project_Id { get; set; }

        [DwColumn("actual_hours")]
        public decimal? Project_Derived_Item_Actual_Hours { get; set; }

        [DwColumn("name")]
        public string Name { get; set; }

        [DwColumn("percentage")]
        public decimal? Percentage { get; set; }

        [DwColumn("a")]
        public decimal? Ca { get; set; }

        [DwColumn("compute_0007")]
        public decimal? Compute_0007 { get; set; }

    }

}