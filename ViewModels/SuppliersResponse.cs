using System;
using auth;

namespace users.ViewModels{
    public class SupplierResponse{
            public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string SupplierCode { get; set; }
        public string nationality { get; set; }
        public string gender { get; set; }
        public string physicalAddress { get; set; }
        public string fromWhere { get; set; }
        public string phoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public string email { get; set; }
        public Login Login { get; set; }
    }
}