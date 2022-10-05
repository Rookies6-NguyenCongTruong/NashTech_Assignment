namespace Assignment2
{
    public class Program
    {
        List<Member> memberList = new List<Member>()
        {
            new Member()
            {
                FirstName = "Nguyen Cong",
                LastName = "Truong",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 07, 22),
                PhoneNumber = "0123456789",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },
            new Member()
            {
                FirstName = "Nguyen Tien",
                LastName = "Tai",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 02, 15),
                PhoneNumber = "0123456789",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member()
            {
                FirstName = "Nguyen Van",
                LastName = "Thao",
                Gender = "Others",
                DateOfBirth = new DateTime(2000, 10, 08),
                PhoneNumber = "0123456789",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },
            new Member()
            {
                FirstName = "Nguyen Duc",
                LastName = "Vinh",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 08, 07),
                PhoneNumber = "0123456789",
                BirthPlace = "Ho Chi Minh",
                IsGraduated = false
            },
            new Member()
            {
                FirstName = "Do Tran",
                LastName = "Minh",
                Gender = "Female",
                DateOfBirth = new DateTime(1998, 07, 22),
                PhoneNumber = "0123456789",
                BirthPlace = "Da Nang",
                IsGraduated = true
            },
            new Member()
            {
                FirstName = "Tran Thi",
                LastName = "Thao",
                Gender = "Female",
                DateOfBirth = new DateTime(1998, 05, 17),
                PhoneNumber = "0123456789",
                BirthPlace = "Hai Phong",
                IsGraduated = false
            }
        };

        public static void Main(string[] args)
        {
            Program program = new Program();
            int input;

            do
            {
                Console.WriteLine("Welcome to the program!!!!!!");
                Console.WriteLine("1. Return a list of members who is Male");
                Console.WriteLine("2. Return the oldest one based on “Age” on the list");
                Console.WriteLine("3. Return a new list that contains Full Name only");
                Console.WriteLine("4. Return 3 lists: ");
                Console.WriteLine("List of members who has birth year is 2000");
                Console.WriteLine("List of members who has birth year greater than 2000");
                Console.WriteLine("List of members who has birth year less than 2000");
                Console.WriteLine("5. Return the first person who was born in Ha Noi");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Please choose the function that u want: ");
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        program.SearchForMaleMember();
                        break;
                    case 2:
                        program.SearchForOldestMember();
                        break;
                    case 3:
                        program.GetListFullNameOnly();
                        break;
                    case 4:
                        program.GetListBirthYearComparision();
                        break;
                    case 5:
                        program.GetFirstPersonBornInHaNoi();
                        break;
                    case 6:
                        Console.WriteLine("You have exited the program. See you again!");
                        break;
                    default:
                        Console.WriteLine("Please choose again");
                        break;
                }
            } while (!(input.Equals(6)));
        }

        public void SearchForMaleMember()
        {
            Console.WriteLine("List of members who is Male: ");

            var maleMember = memberList.Where(x => x.Gender == "Male");

            if (maleMember.Any())
            {
                foreach (Member member in maleMember)
                {
                    Console.WriteLine(member.Info);
                }
            }

            Console.WriteLine("====================================");
        }

        public void SearchForOldestMember()
        {
            Console.WriteLine("The oldest member based on “Age” on the list is: ");

            var maxAgeValue = memberList.Max(member => member.Age);
            var oldestMember = memberList.Find(x => x.Age == maxAgeValue);

            if (oldestMember != null)
            {
                Console.WriteLine(oldestMember.Info);
            }

            Console.WriteLine("====================================");
        }

        public void GetListFullNameOnly()
        {
            Console.WriteLine("List that contains Full Name only: ");

            var listFullNameOnly = from member in memberList
                                   select member.FullName;

            if (listFullNameOnly.Any())
            {
                foreach (var member in listFullNameOnly)
                {
                    Console.WriteLine(member);
                }
            }

            Console.WriteLine("====================================");
        }

        public void GetListBirthYearComparision()
        {
            int input;

            do
            {
                Console.WriteLine("Please choose the function that u want: ");
                Console.WriteLine("1. List of members who has birth year is 2000");
                Console.WriteLine("2. List of members who has birth year greater than 2000");
                Console.WriteLine("3. List of members who has birth year less than 2000");
                Console.WriteLine("4. Return");
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("List of members who has birth year is 2000: ");

                        var memberEquals2000 = memberList.FindAll(x => x.DateOfBirth.Year == 2000);

                        if (memberEquals2000.Any())
                        {
                            memberEquals2000.ForEach(item => Console.WriteLine(item.Info));
                        }

                        Console.WriteLine("====================================");
                        break;
                    case 2:
                        Console.WriteLine("List of members who has birth year greater than 2000: ");

                        var memberGreaterThan2000 = memberList.FindAll(x => x.DateOfBirth.Year > 2000);

                        if (memberGreaterThan2000.Any())
                        {
                            memberGreaterThan2000.ForEach(item => Console.WriteLine(item.Info));
                        }

                        Console.WriteLine("====================================");
                        break;
                    case 3:
                        Console.WriteLine("List of members who has birth year less than 2000: ");

                        var memberLessThan2000 = memberList.FindAll(x => x.DateOfBirth.Year < 2000);

                        if (memberLessThan2000.Any())
                        {
                            memberLessThan2000.ForEach(item => Console.WriteLine(item.Info));
                        }

                        Console.WriteLine("====================================");
                        break;
                    default:
                        Console.WriteLine("Please choose again");
                        break;
                }
            } while (!(input.Equals(4)));
        }

        public void GetFirstPersonBornInHaNoi()
        {
            var result = (from member in memberList
                          where member.BirthPlace?.Trim().ToUpper() == "HA NOI"
                          select member).FirstOrDefault();

            if (result != null)
            {
                Console.WriteLine(result.Info);
            }

            Console.WriteLine("====================================");
        }
    }
}