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
    [DataWindow("d_dddw_project_role", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"project_role\" ) @(_COLUMNS_PLACEHOLDER_) WHERE(    EXP1 =\"project_role.project_id\"   OP =\"=\"    EXP2 =\":project_id\" ) ) ORDER(NAME=\"project_role.name\" ASC=yes ) ARG(NAME = \"project_id\" TYPE = number)")]
    #endregion
    [DwParameter("project_id", typeof(double?))]
    public class D_Dddw_Project_Role
    {
        [DwColumn("project_role", "role_id")]
        public int? Project_Role_Role_Id { get; set; }

        [DwColumn("project_role", "name")]
        public string Name { get; set; }

        [DwColumn("project_role", "multipler")]
        public decimal? Multipler { get; set; }

    }

}