namespace FreshersManagementSystem
{
    class Fresher
    {
        public Fresher() { }
        public Fresher(int id, string name, long mobileNumber, string address, DateTime dateOfBirth, string qualification)
        {
            Id = id;
            Name = name;
            MobileNumber = mobileNumber;
            Address = address;
            DateOfBirth = dateOfBirth;
            Qualification = qualification;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public long MobileNumber { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Qualification { get; set; }
    }
}
