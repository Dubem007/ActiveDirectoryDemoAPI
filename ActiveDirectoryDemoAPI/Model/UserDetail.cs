using Microsoft.Graph;

namespace ActiveDirectoryDemoAPI.Model
{
    public class UserDetail
    {

        public bool AccountEnabled { get; set; }
        public string DisplayName { get; set; }
        public string MailNickname { get; set; }
        public string UserPrincipalName { get; set; }
        public string[] BusinessPhones { get; set; }
        public string GivenName { get; set; }
        public string Mail { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public DateTimeOffset employeeHireDate { get; set; }
        public string employeeId { get; set; }
        public string employeeOrgData { get; set; }
        public string employeeType { get; set; }
        public string jobTitle { get; set; }
        public string mobilePhone { get; set; }
        public string password { get; set; }
        public string postalCode { get; set; }
        public string preferredDataLocation { get; set; }
        public string preferredLanguage { get; set; }
        public string state { get; set; }
        public string streetAddress { get; set; }
        public string userType { get; set; }
        public string birthday { get; set; }
        public string hireDate { get; set; }
        public string manager { get; set; }
        public string memberOf { get; set; }
        public string photo { get; set; }
        public string odatatype { get; set; }
    }

    public class UserNew
    {

        public bool AccountEnabled { get; set; }
        public string DisplayName { get; set; }
        public string MailNickname { get; set; }
        public string UserPrincipalName { get; set; }
        public string[] BusinessPhones { get; set; }
        public string GivenName { get; set; }
        public string Mail { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string employeeHireDate { get; set; }
        public string employeeId { get; set; }
        public string employeeOrgData { get; set; }
        public string employeeType { get; set; }
        public string jobTitle { get; set; }
        public string mobilePhone { get; set; }
        public string passwordProfile { get; set; }
        public string postalCode { get; set; }
        public string preferredDataLocation { get; set; }
        public string preferredLanguage { get; set; }
        public string state { get; set; }
        public string streetAddress { get; set; }
        public string userType { get; set; }
        public string birthday { get; set; }
        public string hireDate { get; set; }
        public string manager { get; set; }
        public string memberOf { get; set; }
        public string photo { get; set; }
        public string odatatype { get; set; }
    }

}
