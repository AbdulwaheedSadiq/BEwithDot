
namespace fishers.ViewModels{
    public class GroupMembersRequest{
         public string GroupMembersFirstName { get; set; }
        public string  GroupMembersMiddleName { get; set; }
        public string GroupMembersLastName { get; set; }
        public string gender { get; set; }  
        public string GroupMembersPosition { get; set; }
        public string GroupMembersZMANumber { get; set; }

       public int FisherMansGroupId { get; set; }
    }
}