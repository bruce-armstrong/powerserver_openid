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
    [DataWindow("d_ds_projectlist", DwStyle.Default)]
    [Table("project")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"project\" ) @(_COLUMNS_PLACEHOLDER_) )")]
    #endregion
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Ds_Projectlist
    {
        [Key]
        [Identity]
        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project", "project_id")]
        public int? Project_Id { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project", "name")]
        public string Name { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project", "project_leader")]
        public string Project_Leader { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project", "start_date", TypeName = "date")]
        public DateTime? Start_Date { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("project", "end_date", TypeName = "date")]
        public DateTime? End_Date { get; set; }

    }

}