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
    [DataWindow("d_dwproperty_services", DwStyle.Default)]
    public class D_Dwproperty_Services
    {
        [DwColumn("serviceenabled")]
        public string Serviceenabled { get; set; }

        [DwColumn("servicename")]
        public string Servicename { get; set; }

        [DwColumn("servicedescription")]
        public string Servicedescription { get; set; }

        [DwColumn("servicepropertypages")]
        public string Servicepropertypages { get; set; }

        [DwColumn("serviceclassname")]
        public string Serviceclassname { get; set; }

        [DwColumn("serviceswitchbuttons")]
        public string Serviceswitchbuttons { get; set; }

    }

}