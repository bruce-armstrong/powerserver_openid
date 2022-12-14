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
    [DataWindow("d_dddw_project", DwStyle.Default)]
    [Table("project")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"project\" ) @(_COLUMNS_PLACEHOLDER_) ) ORDER(NAME=\"project.name\" ASC=yes )")]
    #endregion
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Dddw_Project
    {
        [Key]
        [Identity]
        [DwColumn("project", "project_id")]
        public int? Project_Id { get; set; }

        [ConcurrencyCheck]
        [DwColumn("project", "name")]
        public string Name { get; set; }

    }

}