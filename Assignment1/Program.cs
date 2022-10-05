namespace Assignment1
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

            foreach (Member member in memberList)
            {
                if (member.Gender == "Male")
                {
                    Console.WriteLine(member.Info);
                }
            }

            Console.WriteLine("====================================");
        }

        public void SearchForOldestMember()
        {
            Console.WriteLine("The oldest member based on “Age” on the list is: ");

            int maxValue = int.MinValue;

            foreach (Member member in memberList)
            {
                if (member.Age > maxValue)
                {
                    maxValue = member.Age;
                }
            }

            foreach (Member member in memberList)
            {
                if (member.Age == maxValue)
                {
                    Console.WriteLine(member.Info);
                    break;
                }
            }

            Console.WriteLine("====================================");
        }

        public void GetListFullNameOnly()
        {
            Console.WriteLine("List that contains Full Name only: ");

            foreach (Member member in memberList)
            {
                Console.WriteLine(member.FullName);
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

                        foreach (Member member in memberList)
                        {
                            if (member.DateOfBirth.Year == 2000)
                            {
                                Console.WriteLine(member.Info);
                            }
                        }

                        Console.WriteLine("====================================");
                        break;
                    case 2:
                        Console.WriteLine("List of members who has birth year greater than 2000: ");

                        foreach (Member member in memberList)
                        {
                            if (member.DateOfBirth.Year > 2000)
                            {
                                Console.WriteLine(member.Info);
                            }
                        }

                        Console.WriteLine("====================================");
                        break;
                    case 3:
                        Console.WriteLine("List of members who has birth year less than 2000: ");

                        foreach (Member member in memberList)
                        {
                            if (member.DateOfBirth.Year < 2000)
                            {
                                Console.WriteLine(member.Info);
                            }
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
            int firstBornInHaNoi = 0;

            while (memberList[firstBornInHaNoi].BirthPlace != "Ha Noi")
            {
                firstBornInHaNoi++;
            }

            Console.WriteLine("The first person who was born in Ha Noi: ");
            Console.WriteLine(memberList[firstBornInHaNoi].Info);
            Console.WriteLine("====================================");
        }
    }
}