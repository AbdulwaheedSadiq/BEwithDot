namespace fishers.Models{
    public class GroupMembers{
        public int GroupMembersId { get; set; }
        public string GroupMembersFirstName { get; set; }
        public string  GroupMembersMiddleName { get; set; }
        public string GroupMembersLastName { get; set; }
        public string gender { get; set; }  
        public string GroupMembersPosition { get; set; }
        public string GroupMembersZMANumber { get; set; }

        public int FisherMansGroupId { get; set; }
        public FisherMansGroup FisherMansGroup { get; set; }

    }
}