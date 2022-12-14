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
    [DataWindow("d_ds_projectsummary", DwStyle.Default)]
    [Table("project_category_item")]
    #region DwSelectAttribute  
    [DwSelect("SELECT project_category.name, \r\n "
                  +"sum(project_category_item.estimated_hours * project_role.multipler), \r\n "
                  +"sum(project_category_item.actual_hours), \r\n "
                  +"project_category_item.project_id, \r\n "
                  +"project_category_item.category_id, \r\n "
                  +"'peatappl.bmp', \r\n "
                  +"'peatappl.bmp', \r\n "
                  +"'peatappl.bmp' \r\n "
                  +"FROM project_category_item, \r\n "
                  +"project_category, \r\n "
                  +"project_role \r\n "
                  +"WHERE ( project_category.category_id = project_category_item.category_id ) and \r\n "
                  +"( project_role.role_id = project_category_item.role_id ) and \r\n "
                  +"( ( project_category_item.project_id = :project_id ) ) \r\n "
                  +"GROUP BY project_category_item.project_id, \r\n "
                  +"project_category_item.category_id, \r\n "
                  +"project_category.name \r\n "
                  +"UNION \r\n "
                  +"SELECT project_category.name, \r\n "
                  +"0, \r\n "
                  +"0, \r\n "
                  +"0, \r\n "
                  +"0, \r\n "
                  +"'peatappl.bmp', \r\n "
                  +"'peatappl.bmp', \r\n "
                  +"'peatappl.bmp' \r\n "
                  +"FROM project_category \r\n "
                  +"WHERE (project_category.project_id = :project_id) and (project_category.category_id not in \r\n "
                  +"(Select project_category_item.category_id from project_category_item \r\n "
                  +"Where project_category.project_id = :project_id)) \r\n "
                  +"UNION \r\n "
                  +"SELECT 'Derived Items', \r\n "
                  +"(SELECT sum(project_category_item.estimated_hours* \r\n "
                  +"project_role.multipler   * \r\n "
                  +"project_derived_item.percentage / 100) \r\n "
                  +"FROM project_category_item, \r\n "
                  +"project_complexity, \r\n "
                  +"project_derived_item, \r\n "
                  +"project_role \r\n "
                  +"WHERE ( project_complexity.complexity_id = project_category_item.complexity_id ) and \r\n "
                  +"( project_derived_item.project_id = project_role.project_id ) and \r\n "
                  +"( project_category_item.role_id = project_role.role_id ) and \r\n "
                  +"( ( project_category_item.project_id = :project_id) )), \r\n "
                  +"sum(project_derived_item.actual_hours), \r\n "
                  +"0, \r\n "
                  +"0, \r\n "
                  +"'peatappl.bmp', \r\n "
                  +"'peatappl.bmp', \r\n "
                  +"'peatappl.bmp' \r\n "
                  +"FROM project_derived_item \r\n "
                  +"WHERE ( project_derived_item.project_id = :project_id )")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Ds_Projectsummary
    {
        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("name")]
        public string Name { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("compute_0002")]
        public decimal? Estimated_Hours_All { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("compute_0003")]
        public decimal? Actual_Hours_All { get; set; }

        [Key]
        [DwColumn("project_id")]
        public int? Project_Category_Item_Project_Id { get; set; }

        [Key]
        [DwColumn("category_id")]
        public int? Project_Category_Item_Category_Id { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("compute_0006")]
        public string Picture { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("compute_0007")]
        public string State { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("compute_0008")]
        public string Overlay { get; set; }

    }

}