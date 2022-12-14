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
    [DataWindow("d_ds_category", DwStyle.Default)]
    [Table("project_category")]
    #region DwSelectAttribute  
    [DwSelect("SELECT project_category.category_id, \r\n "
                  +"project_category.project_id, \r\n "
                  +"project_category.name \r\n "
                  +"FROM project_category \r\n "
                  +"WHERE (project_category.project_id = :project_id) \r\n "
                  +"UNION \r\n "
                  +"SELECT 0, \r\n "
                  +"project_derived_item.project_id, \r\n "
                  +"'Derived Items' \r\n "
                  +"FROM project_derived_item \r\n "
                  +"WHERE project_derived_item.project_id = :project_id \r\n "
                  +"GROUP BY project_derived_item.project_id")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Ds_Category
    {
        [Key]
        [DwColumn("category_id")]
        public int? Default_Category_Id { get; set; }

        [Key]
        [DwColumn("project_id")]
        public int? Project_Id { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("name")]
        public string Name { get; set; }

    }

}