using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTest
{
    public class JobInfo
    {
        public string TaskRoleSpaces { get; set; }
        public string TaskRoles { get; set; }
        public string ProxyUserID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserSystemName { get; set; }
        public string OperationName { get; set; }
        public string OperationValue { get; set; }
        public string OperationValueText { get; set; }
        public DateTime SignDate { get; set; }
        public string Comment { get; set; }
        public string FormDataHashCode { get; set; }
        public string SignatureDivID { get; set; }
    }
}
