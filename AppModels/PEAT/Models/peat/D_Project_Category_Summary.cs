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
    [DataWindow("d_project_category_summary", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("SELECT  @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM project_category_item ,           project_role , \r\n "
                  +"project_category \r\n "
                  +"WHERE ( project_category_item.role_id = project_role.role_id ) and \r\n "
                  +"( project_category.category_id = project_category_item.category_id ) and \r\n "
                  +"( ( project_category_item.project_id = :project_id ) )")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    public class D_Project_Category_Summary
    {
        [DwColumn("project_category_item", "category_item_id")]
        public int? Project_Category_Item_Category_Item_Id { get; set; }

        [DwColumn("project_category_item", "name")]
        public string Project_Category_Item_Name { get; set; }

        [DwColumn("project_category_item", "category_id")]
        public int? Project_Category_Item_Category_Id { get; set; }

        [DwColumn("project_category_item", "role_id")]
        public int? Project_Category_Item_Role_Id { get; set; }

        [DwColumn("project_role", "rate")]
        public decimal? Project_Role_Rate { get; set; }

        [DwColumn("project_role", "multipler")]
        public decimal? Project_Role_Multipler { get; set; }

        [DwColumn("project_category_item", "estimated_hours")]
        public decimal? Project_Category_Item_Estimated_Hours { get; set; }

        [DwColumn("project_category_item", "complexity_id")]
        public int? Project_Category_Item_Complexity_Id { get; set; }

        [DwColumn("project_category", "name")]
        public string Project_Category_Name { get; set; }

        [DwColumn("project_role", "name")]
        public string Project_Role_Name { get; set; }

    }

}