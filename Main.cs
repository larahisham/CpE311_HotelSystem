namespace Program
{
	class Program
	{
		static void Main(string[] args)
		{
			HotelSystem hotelSystem = new HotelSystem();

			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("Welcome to our hotel self-service system...");
				Console.WriteLine("Please select a number to complete \n\n" +
								  "[1] Log-in as Guest\n" +
								  "[2] Log-in as Manager\n" +
								  "[3] Sign-in as new Guest\n" +
								  "[4] Exit");
				Console.Write("Enter your choice : ");
				int KindofUser = Convert.ToInt32(Console.ReadLine());

				switch (KindofUser)
				{
					case 1:
						Guest loggedInGuest = hotelSystem.LoginG();
						if (loggedInGuest != null)
						{
							loggedInGuest.GuestFunctions(loggedInGuest);
							hotelSystem.LogoutG();
						}
						break;
					case 2:
						bool isManagerLoggedIn = hotelSystem.LoginM();
						if (isManagerLoggedIn)
						{
							Manager manager = new Manager();
							manager.ManagerFunctions();
							hotelSystem.LogoutM();
						}
						break;
					case 3:
						hotelSystem.NewUser();
						break;
					case 4:
						exit = true;
						hotelSystem.Exit();
						break;
					default:
						Console.WriteLine("Invalid choice, please try again.");
						break;
				}
			}
		}
	}
}
