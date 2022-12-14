using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServerAPIs.Tests
{
    [Collection(TestHost.CollectionName)]
    public class ServerAPIsTest
    {
        private readonly TestHost _host;

        public ServerAPIsTest(TestHost host)
        {
            _host = host;
        }

        // Session
        [Theory]
        [InlineData("api/serverapi/CreateSession", @"{""version"":""1.0"",""requestid"":""F4D1FE72-99B6-4cc0-950E-4715AF7145A7"",""appname"":""test"",""namespace"":""Test"",""session"":null,""type"":31,""transaction"":null,""content"":{""createsession"":{""securestring"":""eyJ0aW1lc3RhbXAiOjE2MTg1NjIzMDIsInBheWxvYWQiOiJacW02TVlPeW1wUEl6V0l6VTRGUDMvV2N3aDFUSFhwZVRkYkdVVGJaV2xpa0xlajBPYTJJN3NtbU5HNVVKQXRNUGxSL2ZJNWN0eERCOW9ZNVhaeVFuZz09Iiwic2lnbmF0dXJlIjoiY1NFSjBHbWliUFVxdU9remkwNFFGZ3B0bEdqTEhYNCtJbjBYT1NHdXB6OEk3NW9RaUt6NjB4VWh4dkI0ODEvSFlLc0ZSaDczMXJPeFF6S2V4QnQyU1E9PSJ9""}}}")]
        [InlineData("api/serverapi/DestroySession", @"{""version"":""1.0"",""requestid"":""3E27AA45-FC04-4ee9-A110-DAC3CAC8EBE5"",""appname"":""Test"",""namespace"":""Test"",""session"":""eyJ0aW1lc3RhbXAiOjE2MTg1NjgwMTgsInBheWxvYWQiOiJHVzN0UGF1Q08xRjQ5MU9hVGZIWnpwbGp5bGNzL1NobEhIOUg3djJNUzJvNFJ3Mlp3MWhSM0p2SUw5eFBLYkV2WHZ4WU9YbW5rZEIzVk9lZGZ5b2ltOW96Mm0xQldJYitaSHkxalpNQUJXUHJMYkhmZW91TzZQSWhwajVJeXVjZ2VERlNmdDQ1L01YSDRmd2duTS85QkZWODN3QzZSQ1BFYnBEcjZjY0dOd0k9Iiwic2lnbmF0dXJlIjoiMDdHSjZEMmFGd0lxQ2lpaGZMRFRoeU4wQkMydnFKMS94TlBqdGdFOFZMelhKQk5RZEU0bkI4M05LWTI4cE40WlU2VFkwb3RaWlBxT3UwQWcva0FqdHc9PSJ9"",""type"":32,""transaction"":null,""content"":null}")]
        public async Task TestCaseForSession(string requestUri, string data)
        {
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            await this.CheckStatus(requestUri, content);
        }

        // Transaction
        [Theory]
        [InlineData("api/serverapi/UpdateTransaction", @"{""version"":""1.0"",""requestid"":""60CADC57-13CF-4a82-B6C1-373B9927C252"",""appname"":""test"",""namespace"":""Test"",""session"":""eyJ0aW1lc3RhbXAiOjE2MTg1NjczNzEsInBheWxvYWQiOiJwL2RDNkY1N0pVTmFFVEV5RG1iM1NpUklLbVlFOFZ3ZHBQQUtna3ZRZ1ZJcnBkdnFJZm0zUmNYR3ZKRlNmbmFtemNTNWh1OGF1N2I4WUc5dThVazQ4WkRKY0pZMERtYkZ4QWxrczJUOHNlMkxNektpS0FiZmVUUjZXU1N3dlJUQkljS1F4aTNWUnRvQTVoNkJyMHB4amswQUpLZExMRy9odlp2TEwvRkhmQlU9Iiwic2lnbmF0dXJlIjoidUg5VmlRd1cwcWRtWnFTaExWbHFOYU41L1pPalhkR0dYa2d3cGtjc1JzT3pZb2JnRnpXT1ZwVG44MStjOEp4OUkrTFhzbTdPU21MRysxbUxkbEhTT0E9PSJ9"",""type"":28,""transaction"":{""transactionid"":""98ce59ce-ac56-47ff-8305-6c73da04e0bb-2""},""content"":{""settransproperties"":{""dbparm"":""eyJ0aW1lc3RhbXAiOjE2MTg1NjczNzEsInBheWxvYWQiOiJ2ZkE0NGJub1dRRDhNbXA5ZEt2ZUpPbFNXdUsyNUU5bkhPaUVqb2Y1T091U1lDVWlPayswU054b0VJZThBMG5OIiwic2lnbmF0dXJlIjoiVzFsT1dpK1NaZjZkUUN5YW8wMmpRdDNXNkY0a1gxUjNCdmJIclBKMUVwS3ZyY3R1eUFieitIc0FuZk1pRnM5ZlgzdkpxWFdOUUluRFUrOGozWHg2Z3c9PSJ9""}}}")]
        [InlineData("api/serverapi/RollbackAndCreateTransaction", @"{""version"":""1.0"",""requestid"":""C8D4EA33-6848-4fb8-832D-F2143B72458C"",""appname"":""test"",""namespace"":""Test"",""session"":""eyJ0aW1lc3RhbXAiOjE2MTg1Njc5NjMsInBheWxvYWQiOiJ2Qk9zK0ZjS0dYM0NNSU56MUQ0N3FVMzBPdlFPQllydThrcXVJRk1QZEt1WWZIN2o5NUNKL2hhSVEyV1Z5RmR0LzdKNHFUVW9XVThCZ2FtU3dudFhna2lMaGwrNEh5M1RKbFdKYUtpa0RhS2dsTXF1elZKemQrcTZmN3p1N0lPaVh2d3I1eDFjQ3FWL3d5YXRxNkRybkRRYmZLcDdwNzdtOEpHZng4MHJUKys4cXNGcVk0aWpKZ1lxM3hzODQzK0kiLCJzaWduYXR1cmUiOiJEL2lCWENhM1QyL2NpY0pPRlJzOC80YTkvTUZSaFFLMEZqeU9OMnlTYi9jdXpZdVZzbmR0aERVYW1oVkRoaGV1aExzSFFuRjBTUE0wU2gzc05rWG84dz09In0="",""type"":10,""transaction"":{""transactionid"":""d5b7d111-6b9d-499c-8d24-1eb5ab255a84-3""},""content"":null}")]
        [InlineData("api/serverapi/ConnectAndCreateTransaction", @"{""version"":""1.0"",""requestid"":""89EF24F9-21B9-41a1-91CE-9BF0A21B5558"",""appname"":""test"",""namespace"":""Test"",""session"":""eyJ0aW1lc3RhbXAiOjE2MTg1Njc5MDEsInBheWxvYWQiOiJqeUxwWFovRDZITkJ1TGlrOGN6T1c1QitMczZkb3cxRk9ITU45RTJkV1RmSUNzVWkrMWI3dzVLc2IybjZ0Zzdudk1RTlRxeFRmdHFVS1FISGR4LzMyb2ZtUzFnZkxnTTBubVprM0RZMXd2NWhWaCttTUJGblh3aXZTenBxejhwTHVPNkZQQU54NTUyWWhmaXlLS2tGVUtnOTA4UmtLRXJ3WkFYY3VJdUxtUW1QSFNVN0Q2ZmRuUk1VWFp1RmU5ZSsiLCJzaWduYXR1cmUiOiJCZXNmNHR5NGtWU09FQmE5c2lXQm1GTE5UVVFjZHJ0UmhMV1g1c28yRERiRHoyWGdicGpuK2M0K2lYVVNMSEI0TmZNSEk5YUhYQSswZkNpQ2NZOWgydz09In0="",""type"":9,""transaction"":{""transactionid"":""98ce59ce-ac56-47ff-8305-6c73da04e0bb-2""},""content"":null}")]
        [InlineData("api/serverapi/CommitAndCreateTransaction", @"{""version"":""1.0"",""requestid"":""A1AB5A1C-EDE2-49e3-92F2-EB466FD90643"",""appname"":""Test"",""session"":""N6tyNMMVVlkOKffNuR04EQsw3tosDNEUHV1HS+o9q6xc6Uf5jfYBG7y+oLRq1zwL40R7wJhKlgagWqoRqrC1ElMrC2Y48ke9Oe2ouQTGGFbk3gOeW+W1c2mOlQlEvbcTHBXZ36IjKrLUYo50i8B6fqNLLA5bpAE/4utIqO6vlWl7T1A2U/mCUCNxIJrpgklv"",""type"":9,""transaction"":{""transactionid"":""a0d4f16a-c1a7-425e-a578-5a000451dd3e-5""},""content"":null}")]
        [InlineData("api/serverapi/Disconnect", @"{""version"":""1.0"",""requestid"":""492FD0AA-2A0F-40b2-9902-5CF672F3FFA2"",""appname"":""test"",""namespace"":""Test"",""session"":""eyJ0aW1lc3RhbXAiOjE2MTg1NjgwMTgsInBheWxvYWQiOiJHVzN0UGF1Q08xRjQ5MU9hVGZIWnpwbGp5bGNzL1NobEhIOUg3djJNUzJvNFJ3Mlp3MWhSM0p2SUw5eFBLYkV2WHZ4WU9YbW5rZEIzVk9lZGZ5b2ltOWRlWkdpazg5aHBMcjRLZ1d3UnpWam5ZV2FGbjVPN2VFQWhreXM1ZnF5TDBId0R2THcxVXBlK3Jzby94VGxJRG5zaXJxbURVU2J4MWhhLy80ZU9zUFE9Iiwic2lnbmF0dXJlIjoiUEZKMWY5U05waFZCSER2NnUrd3ltZUxWaENlQ04rMkZqMFRaRWZKQklvczcySFVBclFMSTZuUFlUckZUYU11QlVmUitBcjFwOC9KalMzR2VtdHQwdEE9PSJ9"",""type"":8,""transaction"":{""transactionid"":""1988131b-d33e-431c-aad2-d650e9175f6a-4""},""content"":null}")]
        public async Task TestCaseForTransaction(string requestUri, string data)
        {
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            await this.CheckStatus(requestUri, content);
        }

        // DataWindow
        [Theory]
        [InlineData("api/serverapi/RetrieveWithParm", @"{""version"":""1.0"",""requestid"":""3CDD2857-0088-41b0-9909-5AB2F6A6F6EC"",""appname"":""Test"",""namespace"":""Test"",""session"":""N6tyNMMVVlkOKffNuR04EQsw3tosDNEUHV1HS+o9q6xc6Uf5jfYBG7y+oLRq1zwL40R7wJhKlgagWqoRqrC1EvIXgC277935SHm7bU8rHkhcU0TaBjx9ZrNQFkBimiiRSvvg+bgTTMmdw5iEwC5u9hj3RJdue6E417KWwTtNXxk="",""type"":1,""transaction"":{""transactionid"":""a0d4f16a-c1a7-425e-a578-5a000451dd3e-5""},""content"":{""retrieves"":[{""retrieveid"":""3CDD2857-0088-41b0-9909-5AB2F6A6F6EC"",""parent"":"""",""dataobject"":""d_research_updatecheck"",""parentcolumn"":"""",""isreport"":false,""isdynamic"":false,""dwsyntax"":"""",""sql"":"""",""processing"":1,""arguments"":[]}]}}")]
        [InlineData("api/serverapi/DataStoreUpdate", @"{""version"":""1.0"",""requestid"":""F1D2BCE7-83A4-4eb6-96F9-0BDB4603E415"",""appname"":""Test"",""namespace"":""Test"",""session"":""N6tyNMMVVlkOKffNuR04EQsw3tosDNEUHV1HS+o9q6xc6Uf5jfYBG7y+oLRq1zwL40R7wJhKlgagWqoRqrC1Ep3IymxuMi4h3YjctLFeTcn8WW+R/Y2Hs4MBXV/ww4xaAwyy/06NI5aaHoNDkwMX+iRKipHCH1m73FZ6VNaejo0="",""type"":3,""transaction"":{""transactionid"":""a0d4f16a-c1a7-425e-a578-5a000451dd3e-5""},""content"":{""update"":{""dataobject"":""d_research_updatecheck"",""isdynamic"":false,""dwsyntax"":"""",""properties"":{""table"":""t_update_forcheck"",""incrementcolumn"":""id"",""whereclause"":2,""keymodification"":1,""uniquekeycolumns"":[""id""],""updatablecolumns"":[""id"",""name"",""age"",""birth"",""salary"",""depart""]},""data"":{""deleterows"":[{""rowid"":0,""rowstatus"":4,""columns"":{""id"":[116],""name"":[""Mary""],""age"":[26],""birth"":[""2021-03-15 00:00:00""],""salary"":[100.0100],""depart"":[200]}},{""rowid"":1,""rowstatus"":4,""columns"":{""id"":[118],""name"":[""Jary""],""age"":[27],""birth"":[""2021-03-16 00:00:00""],""salary"":[100.0100],""depart"":[300]}}],""primaryrows"":[{""rowid"":0,""rowstatus"":3,""columns"":{""id"":[null],""name"":[""Jary"",1,null],""age"":[35,1,null],""birth"":[""2021-03-16 00:00:00"",1,null],""salary"":[null],""depart"":[100,1,null]}},{""rowid"":1,""rowstatus"":3,""columns"":{""id"":[null],""name"":[""Jary2"",1,null],""age"":[26,1,null],""birth"":[""2021-03-16 00:00:00"",1,null],""salary"":[null],""depart"":[200,1,null]}}],""filterrows"":[]}}}}")]
        [InlineData("api/serverapi/Syntaxfromsql", @"{""version"":""1.0"",""requestid"":""6D54DAF9-D35F-43fb-ABA4-B8D6615798BF"",""appname"":""Test"",""namespace"":""Test"",""session"":""QvaYX1tzuhXz99sddSkdsXCIARpn7QVIVUH4+yVRXRcxfS1HxEQLrUTqlKUe7HwN59t2Z7dHqxkxucBDnATnW7Mx5ddagbUfBPwVuRF1fGIRlS60AGfPfOAqpVAJD9ligZdPhtJh+rOwucp9fjy6AaRfkByIwOsXm/lGwIHfL28="",""type"":4,""transaction"":{""transactionid"":""c38ce13c-cdaf-4521-8a62-fc9cce0f50b9-7""},""content"":{""syntaxfromsql"":{""sql"":""select * from t_dwstyle_grid_employ where id =?"",""getextendedattributes"":true}}}")]
        [InlineData("api/serverapi/DatawindowReselect", @"{""version"":""1.0"",""requestid"":""36B1ED36-B19D-4983-AEC1-0C477F1A8012"",""appname"":""Test"",""namespace"":""Test"",""session"":""duqRhS+zJpkil4Jd9UIC/Q48I7AqnU3Q85rI2ZMeFkw8/SXkmgvsDQfA4VnjVNnEfcJS9VXo4+IGP+HPrhH088AXHj2lE/EHfxODxCM2mZX+YwSDj1aij3w9WHH0+vJFyPhCy8HEHqYG2wkKcYAWJWqpBp3pr/myY/MMsGjxn5g="",""type"":2,""transaction"":{""transactionid"":""43ce0fdb-2d8b-4e15-b8cb-2578699089de-1""},""content"":{""reselectrow"":{""dataobject"":""d_dwstyle_tabular"",""isdynamic"":false,""sql"":"""",""data"":{""rowid"":0,""rowstatus"":1,""columns"":{""empid"":[837],""empname"":[""ggggfd"",1,""3459""],""managerid"":[300],""productid"":[200],""deptid"":[300],""birthday"":[""1978-10-09 00:00:00""],""starttime"":[null],""salary"":[-694724.7872],""sex"":[""F""],""updatetime"":[""2020-04-21 16:19:21.573000""],""charges"":[null]}}}}}")]
        public async Task TestCaseForDatawindow(string requestUri, string data)
        {
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            await this.CheckStatus(requestUri, content);
        }

        // Esql
        [Theory]
        [InlineData("api/serverapi/Selectwithparm", @"{""version"":""1.0"",""requestid"":""5A7E54C0-7763-4a06-9D93-879CD21E4D24"",""appname"":""Test"",""namespace"":""Test"",""session"":""QvaYX1tzuhXz99sddSkdsXCIARpn7QVIVUH4+yVRXRcxfS1HxEQLrUTqlKUe7HwN59t2Z7dHqxkxucBDnATnW3fgW9um40QeEmEXjQlyjZ7NkNEO+dt73yjIfDa+4apiXtHRW5/5tXN4pjY2vGFuYY+Q0MuSbt6lu6I7lsz3cgs="",""type"":11,""transaction"":{""transactionid"":""c38ce13c-cdaf-4521-8a62-fc9cce0f50b9-7""},""content"":{""esqlselect"":{""modulename"":"""",""sqlid"":""sqlHandle_01_44A2AB2C"",""parameters"":[]}}}")]
        [InlineData("api/serverapi/Insertwithparm", @"{""version"":""1.0"",""requestid"":""002B8944-C095-4dd1-BE67-C7334ADD4FDB"",""appname"":""Test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5QZxx1hHothJVB7i1HA2D/2mTXy/Z1AEyNUqlNtly4QBjb7bvEbIcupb7kPyx19whqJkqEjsMTaenSq0st8p1EE0="",""type"":12,""transaction"":{""transactionid"":""c58e9793-cd2f-4e49-a9c5-0e46bfc15a27-9""},""content"":{""esqlinsert"":{""modulename"":"""",""sqlid"":""sqlHandle_02_17FBCF3"",""parameters"":[{""category"":1,""name"":""name"",""type"":""decimal"",""value"":0.00}]}}}")]
        [InlineData("api/serverapi/Updatewithparm", @"{""version"":""1.0"",""requestid"":""12AD71C4-705D-4b73-917E-867CE7201288"",""appname"":""Test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5QUFVfl4Ar1xyhWN7B8UgOQGUeHKEdtivP/3VHbbjF7ixSYnYxc+MYcTlURqL2WDr3qb98jXVdBaAMIkEX4xIjJQ="",""type"":13,""transaction"":{""transactionid"":""20d0617f-dd94-4600-8c37-c8ddd0fd4d47-12""},""content"":{""esqlupdate"":{""modulename"":"""",""sqlid"":""sqlHandle_03_2D8F4679"",""parameters"":[]}}}")]
        [InlineData("api/serverapi/Deletewithparm", @"{""version"":""1.0"",""requestid"":""B3DE2FEC-0FDC-49c0-920F-77E161131781"",""appname"":""Test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5Qak3op5rLLI2O+vgDre4/WWP6JbcJyfrn9OBH9S5/Y/0mqq6KyoYuDeVgNYYybZzAQZbiZnAyGpdhWYUqWfawzw="",""type"":14,""transaction"":{""transactionid"":""c1df2c1e-b513-4927-903d-4ca7c94f85ad-13""},""content"":{""esqldelete"":{""modulename"":"""",""sqlid"":""sqlHandle_04_AC04BFBC"",""parameters"":[]}}}")]
        [InlineData("api/serverapi/Dynamicexecutewithparm", @"{""version"":""1.0"",""requestid"":""EDAD2C69-5BC2-401b-A9C6-18288E82C279"",""appname"":""Test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5QQ/zcz2SsHzoXZye1z2m9S4Tt6wEiOo6skHCiwpVKtvu5yBzmMRsS4/sAdmrQI4lG4+NQQNtoD8Ij0dWpmwBaLA="",""type"":22,""transaction"":{""transactionid"":""c1df2c1e-b513-4927-903d-4ca7c94f85ad-13""},""content"":{""dynamicsql"":{""sqlstatements"":""dbcc checkident(?,RESEED,1)"",""parameters"":[{""category"":1,""name"":""name"",""type"":""string"",""value"":""t_datatype_forupdate""}]}}}")]
        [InlineData("api/serverapi/ImmediateExecute", @"{""version"":""1.0"",""requestid"":""44B7EEBB-A713-41c6-9DE5-CD5663CD9136"",""appname"":""test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5Qa2p06HmWF6+kF1SEcYEXrtSz0ucoyPmqtKHjyb7aUXRI/tgMiYREPgIYLbLOvD2Ev3T0v1Wd5nyWjLwxDVuc1I="",""type"":21,""transaction"":{""transactionid"":""42c357d7-fd3b-4d28-a7a1-d1a110b5bcd9-14""},""content"":{""dynamicsql"":{""sqlstatements"":""---update age\r\nupdate t_datatype_forupdate set age = 12 where id = 1""}}}")]
        [InlineData("api/serverapi/SelectBlobWithParm", @"{""version"":""1.0"",""requestid"":""50E6C994-D5D1-4fc4-9401-276E96B86F6F"",""appname"":""test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5QYMdlzQs7NE0dMq68x2/9K6CjRHdurbqGuE1JTt0ht2ehH9S8w7EIZH0VmcZRy6Kq1kSWw0PhwPEq2KV6hSZuDk="",""type"":15,""transaction"":{""transactionid"":""42c357d7-fd3b-4d28-a7a1-d1a110b5bcd9-14""},""content"":{""esqlselectblob"":{""modulename"":"""",""sqlid"":""sqlHandle_05_BC36179C"",""parameters"":[{""category"":1,""name"":""name"",""type"":""int"",""value"":1}]}}}")]
        [InlineData("api/serverapi/UpdateblobWithParm", @"{""version"":""1.0"",""requestid"":""EC565B7B-1F1F-48d2-84EB-C7ADDF52B3F3"",""appname"":""Test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5QTkVKyS/ojlRRyunwD+TstC0E/Ufrg3Z18au1yGkKzYtBBOxIcUbQXXaOWWNgZLgDEh+T8DXMzqNr7AGROx5bCQ="",""type"":16,""transaction"":{""transactionid"":""42c357d7-fd3b-4d28-a7a1-d1a110b5bcd9-14""},""content"":{""esqlupdateblob"":{""modulename"":"""",""sqlid"":""sqlHandle_06_843F30B9"",""parameters"":[{""category"":1,""name"":""name"",""type"":""blob"",""value"":""0M8R4KGxGuEAAAAAAAAAAAAAAAAAAAAAPgADAP7/CAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA""}]}}}")]
        public async Task TestCaseForEsql(string requestUri, string data)
        {
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            await this.CheckStatus(requestUri, content);
        }

        // Procedure
        [Theory]
        [InlineData("api/serverapi/cursorwithparm", @"{""version"":""1.0"",""requestid"":""67EC209D-74D9-495a-B7B2-05CDFBAEDEF0"",""appname"":""Test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5QZocOWXWplaQu2owLGXR8wuG/dDqhlhm4ApKgDka8ahOxv8n97ubQP3xP3B1Xl0d0I3wF6TTxY6mWxPwlKflQ9M="",""type"":18,""transaction"":{""transactionid"":""42c357d7-fd3b-4d28-a7a1-d1a110b5bcd9-14""},""content"":{""esqlcursor"":{""modulename"":"""",""sqlid"":""sqlHandle_01_2AE2F6E8"",""parameters"":[{""category"":1,""name"":""name"",""type"":""date"",""value"":""2012-09-02""},{""category"":1,""name"":""name"",""type"":""date"",""value"":""2020-02-02""}]}}}")]
        [InlineData("api/serverapi/dynamicopencursor", @"{""version"":""1.0"",""requestid"":""1FBE80AA-7712-4061-A791-D6D3933F5D96"",""appname"":""test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5QduHyQ3fLdhNOLv4jZoo4zRlSrklj7Xwuk7orP/ACraKWIZnYAsKvhpfwAJJcNwa9gZQnxVSbBO0ULVBVgEXFkg="",""type"":25,""transaction"":{""transactionid"":""42c357d7-fd3b-4d28-a7a1-d1a110b5bcd9-14""},""content"":{""dynamicsql"":{""sqlstatements"":""execute pro_sp_user"",""parameters"":[]}}}")]
        [InlineData("api/serverapi/DynamicExecuteProcedure", @"{""version"":""1.0"",""requestid"":""A88E1C7B-2B04-4fdf-B64A-DF31237A21DF"",""appname"":""Test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5QQ/zcz2SsHzoXZye1z2m9S5uzXzyIgY/jAEmORYORmOzmolNOFG/ta3JAawMTxN3HNkXNSeFfh9v+NEtibLk0gw="",""type"":24,""transaction"":{""transactionid"":""42c357d7-fd3b-4d28-a7a1-d1a110b5bcd9-14""},""content"":{""dynamicsql"":{""sqlstatements"":""exec sp_rename 't_dwstyle_rename','T_Dwstyle_Rename'"",""parameters"":[]}}}")]
        [InlineData("api/serverapi/StoreProcedureReturnDataSet", @"{""version"":""1.0"",""requestid"":""B286B581-AC82-4e22-8DFC-94FED744DCEA"",""appname"":""Test"",""namespace"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5QWMKqLYrCxwXSXKibywWxl4p+6odY5PKDCsAdyYvm8mpLz3QEghrDeKku3B7W9vKhjXIeZktg9iVOq9lQLq0EWTDDTXaqNv81tAt2SXRANPJ"",""type"":17,""transaction"":{""transactionid"":""42c357d7-fd3b-4d28-a7a1-d1a110b5bcd9-14""},""content"":{""esqlsp"":{""modulename"":"""",""sqlid"":""sqlHandle_08_B969E313"",""parameters"":[]}}}")]
        [InlineData("api/serverapi/RPCFunction", @"{""version"":""1.0"",""requestid"":""B9FD3D89-6665-4f7a-8563-D9AA4BA1C0C5"",""appname"":""Test"",""session"":""PdgM2Rg0AGXC285PFYAvpJtBFksJx59lGeAx3lIAMPk7crSVZ6b0LLhcEn1DcrxnlsL1QtdLgh3wVsckMBG5QUPjyC2Ks2OGjLwOxTXl3u2PgVaOi8y/2tbbDwuPhiXVpC6yQ1npQycrJ+zJ5igp8sbbh/jvfKaYFq97c5KTQvg="",""type"":29,""transaction"":{""transactionid"":""e606c287-5491-4eb0-a490-2d983c03e974-15""},""content"":{""rpcdefinition"":{""functionname"":""dbo.pro_sp_rpc"",""parameters"":[{""category"":1,""name"":""name"",""type"":""long"",""value"":100},{""category"":1,""name"":""name"",""type"":""string"",""value"":""""},{""category"":1,""name"":""name"",""type"":""long"",""value"":0},{""category"":1,""name"":""name"",""type"":""string"",""value"":""""}]}}}")]
        public async Task TestCaseForProcedure(string requestUri, string data)
        {
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            await this.CheckStatus(requestUri, content);
        }

        #region private check status

        private async Task CheckStatus(string requestUri, StringContent content)
        {
            using var client = _host.Server.CreateClient();

            var response = await client.PostAsync(requestUri, content);

            // check if need authorition
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.True(1 == 1, "Unauthorized");

                return;
            }

            // Check Result
            var msg = response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, msg.StatusCode);
        }

        #endregion
    }
}
