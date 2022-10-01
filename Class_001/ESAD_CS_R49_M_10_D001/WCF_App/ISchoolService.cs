using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_App.Models;

namespace WCF_App
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISchoolService" in both code and config file together.
    [ServiceContract]
    public interface ISchoolService
    {
        [OperationContract]
        List<Student> ShowAllStudent();

        [OperationContract]
        void UpdateStudent(string stuId,string stuName,string stuAddress);

        [OperationContract]
        void InsertStudent(string stuId, string stuName, string stuAddress);

        [OperationContract]
        Student FindStudent(string stuId);

        [OperationContract]
        void DeleteStudent(string stuId);
    }
}
