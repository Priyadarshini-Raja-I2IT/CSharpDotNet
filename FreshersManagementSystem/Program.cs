using System.Text;

namespace FreshersManagementSystem
{
    class Program
    {
        public static void Main(String[] args)
        {        
            int userInput;
            FreshersList freshersList = new FreshersList();
            Console.WriteLine("<-- FRESHERS MANAGEMENT SYSTEM -->");
            StringBuilder options = new StringBuilder("\n\nSelect Operation:\n")
                   .Append("\n1. Add fresher\n2. Get all freshers details\n")
                   .Append("3. Search fresher\n4. Exit");

            do
            {
                Console.WriteLine(options);         
                userInput = getValidUserInput();

                switch (userInput)
                {
                    case 1:
                        addFresher(freshersList);
                        break;
                    case 2:
                        getAllFreshers(freshersList);
                        break;
                    case 3:
                        searchFresher(freshersList);
                        break;
                    case 4:
                        Console.WriteLine("Good bye!");
                        break;
                    default:
                        Console.WriteLine("Invalid Request! Please enter any number from 1 to 4.");
                        break;
                }
            } while (4 != userInput);
            
        }

        private static int getValidUserInput()
        {
            int input = 0;
            bool isValidInput;

            do
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    isValidInput = true;
                }
                catch (SystemException)
                {
                    isValidInput = false;
                    Console.WriteLine("\n*** Invalid Input! Input should be an integer ***\n");
                }
            } while (!isValidInput);

            return input;
        }

        private static void addFresher(FreshersList freshersList)
        { 
            Console.WriteLine("\nHow many freshers details do you want to add? ");
            int numberOfInputs = Convert.ToInt32(Console.ReadLine());

            for (int input = 1; input <= numberOfInputs; input++)
            {
                Console.WriteLine("\nEnter details of fresher: {0}", input);
                int id = getId();
                string name = getName();
                long mobileNumber = getMobileNumber();
                string address = getAddress();
                DateTime dateOfBirth = getDateOfBirth();
                string qualification = getQualification();
                Fresher fresher = new Fresher(id, name, mobileNumber, address, dateOfBirth, qualification);
                freshersList.addFresher(fresher);
            }
        }

        private static string getQualification()
        {
            string qualification;
            bool isEmpty;

            do
            {
                Console.WriteLine("Qualification:");
                qualification = Console.ReadLine();
                isEmpty = true;

                if ("" == qualification || null == qualification)
                {
                    Console.WriteLine("Qualification cannot be empty or null");
                    isEmpty = false;
                }
            } while (!isEmpty);

            return qualification;
        }

        private static DateTime getDateOfBirth()
        {
            DateTime dateOfBirth;
            bool isValidDOB;
            do
            {
                Console.WriteLine("DOB (dd/MM/yyyy): ");
                string dob = Console.ReadLine();
                dateOfBirth = DateTime.ParseExact(dob, "dd/MM/yyyy", null);
                isValidDOB = true;

                if (CalculateYears(dateOfBirth) < 18)
                {
                    Console.WriteLine("Age should be greater than 18. But, the age is " + CalculateYears(dateOfBirth));
                    isValidDOB = false;
                }
                    
            } while (!isValidDOB);

            return dateOfBirth;
        }

        public static int CalculateYears(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Year - dob.Year;
            if (DateTime.Now.DayOfYear < dob.DayOfYear)
                age = age - 1;

            return age;
        }

        private static string getAddress()
        {
            string address;
            bool isValidAddress;

            do
            {
                Console.WriteLine("Address:");
                address = Console.ReadLine();
                isValidAddress = true;

                if ("" == address || null == address)
                {
                    Console.WriteLine("Address cannot be empty or null");
                    isValidAddress = false;
                }
            } while (!isValidAddress);

            return address;
        }

        private static long getMobileNumber()
        {
            long mobileNumber = 0;
            bool isValidMobileNumber;

            do
            {
                Console.WriteLine("Mobile Number: ");
                mobileNumber = Convert.ToInt64(Console.ReadLine());
                isValidMobileNumber = true;

                if (0 >= mobileNumber)
                {
                    Console.WriteLine("Id cannot be 0 or negative number");
                    isValidMobileNumber = false;
                }
            } while (!isValidMobileNumber);

            return mobileNumber;
        }

        private static string getName()
        {
            string name;
            bool isValidName;

            do
            {
                Console.WriteLine("Name:");
                name = Console.ReadLine();
                isValidName = true;

                if ("" == name || null == name)
                {
                    Console.WriteLine("Name cannot be empty or null");
                    isValidName = false;
                }
            } while (!isValidName);

            return name;
        }

        private static int getId()
        {
            int id = 0;
            bool isValidId;

            do
            {
                Console.WriteLine("Id:");
                id = Convert.ToInt32(Console.ReadLine());
                isValidId = true;

                if (0 >= id)
                {
                    Console.WriteLine("Id cannot be 0 or negative number");
                    isValidId = false;
                }
            } while (!isValidId);

            return id;
        }

        private static void getAllFreshers(FreshersList freshersList)
        {
            freshersList.getAllFreshers();
        }


        private static void searchFresher(FreshersList freshersList)
        {
            int userInput;
            StringBuilder searchOptions = new StringBuilder("\nSelect Search Operation:\n")
                   .Append("\n1. Search by Id\n2. Search by Name\n")
                   .Append("3. Go to main menu\n");

            do
            {
                Console.WriteLine(searchOptions);
                userInput = getValidUserInput();

                switch (userInput)
                {
                    case 1:
                        searchById(freshersList);
                        break;
                    case 2:
                        searchByName(freshersList);
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Invalid Request! Please enter any number from 1 to 4.");
                        break;
                }
            } while (3 != userInput);
        }

        private static void searchByName(FreshersList freshersList)
        {
            Console.WriteLine("Enter any letter or letters from name of the fresher");
            var searchInput = Console.ReadLine();
            freshersList.getFreshersByLettersOfName(searchInput);
        }

        private static void searchById(FreshersList freshersList)
        {
            Console.WriteLine("Enter any letter or letters from name of the fresher");
            int searchInput = getValidUserInput();
            freshersList.getFresherById(searchInput);
        }
    }
}