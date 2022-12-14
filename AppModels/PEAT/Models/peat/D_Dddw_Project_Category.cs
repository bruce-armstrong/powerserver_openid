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
    [DataWindow("d_dddw_project_category", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"project_category\" ) @(_COLUMNS_PLACEHOLDER_) WHERE(    EXP1 =\"project_category.project_id\"   OP =\"=\"    EXP2 =\":project_id\" ) ) ORDER(NAME=\"project_category.name\" ASC=yes ) ARG(NAME = \"project_id\" TYPE = number)")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    public class D_Dddw_Project_Category
    {
        [DwColumn("project_category", "category_id")]
        public int? Category_Id { get; set; }

        [DwColumn("project_category", "name")]
        public string Name { get; set; }

    }

}