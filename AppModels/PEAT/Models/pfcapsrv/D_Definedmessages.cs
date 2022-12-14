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
    [DataWindow("d_definedmessages", DwStyle.Grid)]
    [Table("messages")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"messages\" ) @(_COLUMNS_PLACEHOLDER_) )")]
    #endregion
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Definedmessages
    {
        [Key]
        [DwColumn("messages", "msgid")]
        public string Msgid { get; set; }

        [ConcurrencyCheck]
        [DwColumn("messages", "msgtitle")]
        public string Msgtitle { get; set; }

        [ConcurrencyCheck]
        [DwColumn("messages", "msgtext")]
        public string Msgtext { get; set; }

        [ConcurrencyCheck]
        [DwColumn("messages", "msgicon")]
        public string Msgicon { get; set; }

        [ConcurrencyCheck]
        [DwColumn("messages", "msgbutton")]
        public string Msgbutton { get; set; }

        [ConcurrencyCheck]
        [DwColumn("messages", "msgdefaultbutton")]
        public int? Msgdefaultbutton { get; set; }

        [ConcurrencyCheck]
        [DwColumn("messages", "msgseverity")]
        public int? Msgseverity { get; set; }

        [ConcurrencyCheck]
        [DwColumn("messages", "msgprint")]
        public string Msgprint { get; set; }

        [ConcurrencyCheck]
        [DwColumn("messages", "msguserinput")]
        public string Msguserinput { get; set; }

    }

}