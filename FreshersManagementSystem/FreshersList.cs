namespace FreshersManagementSystem
{
    class FreshersList
    {
        string filePath = @"C:\Users\Lenovo\Documents\FreshersManagementSystem\FreshersInfo.txt";

        public List<Fresher> storeDataToListFromFile()
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            List<Fresher> freshers = new List<Fresher>();

            foreach (string line in lines)
            {
                Fresher newFresher = new Fresher();
                string[] entries = line.Split(',');

                newFresher.Id = int.Parse(entries[0]);
                newFresher.Name = entries[1];
                newFresher.MobileNumber = long.Parse(entries[2]);
                newFresher.Address = entries[3];
                newFresher.DateOfBirth = Convert.ToDateTime(entries[4]);
                newFresher.Qualification = entries[5];

                freshers.Add(newFresher);
            }
           
            return freshers;
        }
        public void addFresher(Fresher fresher)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
                                    
            lines.Add($"{ fresher.Id },{fresher.Name},{fresher.MobileNumber}," +
                $"{fresher.Address},{fresher.DateOfBirth.ToShortDateString()}," +
                $"{fresher.Qualification}");
            
            File.WriteAllLines(filePath, lines);
        }

        public void getAllFreshers()
        {
            List<Fresher> freshers = storeDataToListFromFile();
            foreach (var fresher in freshers)
            {
                Console.WriteLine($"Id: {fresher.Id}, Name: {fresher.Name}," +
                    $" MobileNumber: {fresher.MobileNumber}, Address: {fresher.Address}," +
                    $" DOB: {fresher.DateOfBirth.ToShortDateString()}," +
                    $" Qualification: {fresher.Qualification}");
            }        
        }

        public void getFreshersByLettersOfName(string searchInput)
        {
            List<Fresher> freshers = storeDataToListFromFile();
            var matchingFreshersList = freshers.Where(fresher => 
                    fresher.Name.Contains(searchInput, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var fresher in matchingFreshersList)
            {
                Console.WriteLine($"Id: {fresher.Id}, Name: {fresher.Name}," +
                    $" MobileNumber: {fresher.MobileNumber}, Address: {fresher.Address}," +
                    $" DOB: {fresher.DateOfBirth.ToShortDateString()}," +
                    $" Qualification: {fresher.Qualification}");
            }
        }

        public void getFresherById(int searchInput)
        {
            List<Fresher> freshers = storeDataToListFromFile();
            foreach (var fresher in freshers)
            {
                if (fresher.Id == searchInput)
                {
                    Console.WriteLine($"Id: {fresher.Id}, Name: {fresher.Name}, " +
                        $"MobileNumber: {fresher.MobileNumber}, Address: {fresher.Address}," +
                        $" DOB: {fresher.DateOfBirth.ToShortDateString()}, " +
                        $" Qualification: {fresher.Qualification}");
                    return;
                }                
            }
        }
    }
}
