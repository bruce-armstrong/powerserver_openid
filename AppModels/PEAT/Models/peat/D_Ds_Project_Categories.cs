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
    [DataWindow("d_ds_project_categories", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("SELECT  @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM project_category \r\n "
                  +"WHERE project_category.project_id = :project_id \r\n "
                  +"ORDER BY project_category.name          ASC")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    public class D_Ds_Project_Categories
    {
        [DwColumn("project_category", "name")]
        public string Name { get; set; }

        [DwColumn("project_category", "category_id")]
        public int? Category_Id { get; set; }

    }

}