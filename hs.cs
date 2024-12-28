using System;
using System.IO;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
[Serializable]
public class Guest 
{
	public Guest(string ID, string Name, string Password, double PhoneNumber, double Bankbalance)
	{
			this.id = ID;
	        this.name = Name; 
			this.password = Password;
			this.bankbalance = Bankbalance;
			this.phonenumber = PhoneNumber;
	}
	public Guest(string ID, string Password)
	{
		this.id = ID;
		this.password = Password;
	}

	private string id;
	public string ID
	{
		get
		{
			return this.id;
		}
		set
		{

		}
	}
	private string name;
	public string Name
	{
		get
		{
			return this.name;
		}
		set
		{

		}
	}
	private string password;
	public string Password
	{
		get
		{
			return this.password;
		}
		set
		{

		}
	}
	private double phonenumber;
	public double PhoneNumber
	{
		get
		{
			return this.phonenumber;
		}
		set
		{

		}
	}
	private double bankbalance;
	public double BankBalance
	{
		get
		{
			return this.bankbalance;
		}
		set
		{

		}
	}
	// when new user is registered, this is appear 
	public override string ToString()
	{
		return "Your name is : " + name + "\nYour ID is : " + id + "\nYour Phone Number is : " + phonenumber + "\nYour Bank Balance is : " + bankbalance;
	}
}
[Serializable]
public class Manager 
{
	private string id;
	public string ID
	{
		get
		{
			return this.id;
		}
	}
	private string password;
	private string Password
	{
		get
		{
			return this.password;
		}
	}
	private bool IsManagerLoggedIn;
	// should be verify (ID == m2024) (Passward == 00)
	public string Login(string id, string password)
	{
		id = "m2024";
		password = "00";
		// Method for manager login
		if (this.ID == id && this.Password == password)
		{
			return ("Log-in is successfully done!");
			IsManagerLoggedIn = true;
		}
		else
		{
			return ("Error, re-check your Password or ID");
			IsManagerLoggedIn =false;
		}
	}
	public void Logout()
	{
		if (IsManagerLoggedIn)
		{

		}
		// Method for manager logout
	} 
}
//=========================================================//
[Serializable]
public class Room
{
	private int number;
	public int Number
	{
		get
		{
			return number;
		}
		set
		{

		}
	} // Room number
	private string type;
	public string Type
	{
		get
		{
			return type;
		}
		set
		{

		}
	} // Room type
	private double pricePerDay;
	public double PricePerDay
	{
		get
		{
			return pricePerDay;
		}
		set
		{

		}
	} // Price per day
	private bool availabilityStatus;
	public bool AvailabilityStatus
	{
		get
		{
			return availabilityStatus;
		}
		set
		{

		}
	} // Room availability
	public Room(int Number, string Type, double PricePerDay, bool AvailabilityStatus)
	{
		this.number = Number;
		this.type = Type;
		this.pricePerDay = PricePerDay;
		this.availabilityStatus = AvailabilityStatus;
	}
	public void UpdateRoomInfo(int Number, string Type, double PricePerDay, bool AvailabilityStatus)
	{
		// Method to update room type and price per day
	}
}
//=========================================================//
[Serializable]
public class Reservation
{
	private static readonly string[] MealOptions = { "Breakfast", "BreakfastAndLunch", "FullBoard" };

	private string id;
	public string ID
	{
		get
		{
			return this.id;
		}
		set
		{

		}
	}

	//********************************************************************** 
	private int roomnumber;
	public int RoomNumber
	{
	} // we can take it from class room get 
	private string GuestID { get; set; } // Guest ID (from Guest class) we may get iy from guest class when needed  
	//**********************************************************************
	private string CheckIndate;
	public string CheckInDate
	{
		get
		{
			return this.CheckIndate;
		}
		set
		{

		}
	}
	private string CheckOutdate;
	public string CheckOutDate
	{
		get
		{
			return this.CheckOutdate;
		}
		set
		{

		}
	}
	private string Mealoption;
	public string MealOption
	{
		get
		{
			return this.Mealoption;
		}
		set
		{

		}
	} // Meal option selected by guest 
	private string Reservationstatus;
	public string ReservationStatus
	{
		get
		{
			return this.Reservationstatus;
		}
		set
		{

		}
	} // Reservation status ("confirmed", "checked-in", "checked-out")
	private void CalculateReservationAmount()
	{
		// Method to calculate the reservation amount based on room price, meal option, and discounts
	}
	private void ApplyDiscount()
	{
		// Method to apply discount based on the check-in date
	}
	public void CheckInReservation(string ID)
	{
		// Code to check in a reservation
		ReservationStatus = "checked-in";
	}
	public void CheckOutReservation(string ID)
	{
		// Code to check out a reservation
		ReservationStatus = "checked-out";
	}
}
//=========================================================//
[Serializable]
public class Payment
{
	// banck balance from guest class 
	private string Billnumber;
	private string BillNumber
	{
		get
		{
			return this.Billnumber;
		}
		set
		{

		}
	} // bill number 
	  //**********************************************************************
	private string ReservationID { get; set; } // could be deleted and get fron reservation class when needed 
											   // as well as bank balance 
	//**********************************************************************
	private double Totalamount;
	public double TotalAmount
	{
		get
		{
			return this.Totalamount;
		}
		set
		{

		}
	} // total amount could be deleted 
	private string Paymentsource;
	public string PaymentSource
	{
		get
		{
			return this.Paymentsource;
		}
		set
		{

		}
	}  // Payment source ("reservation" or "service")
	private string Paymentstatus;
	public string PaymentStatus
	{
		get
		{
			return this.Paymentstatus;
		}
		set
		{

		}
	}  // Payment status ("paid", "not paid")
	public bool IsbalancePayable(double TotalAmount, Guest g)
	{
		double Balance = g.BankBalance;
		return TotalAmount <= Balance;
	}
	public void CreatePaymentRecord(string reservationID, double amount, string source)
	{
		// Method to create a new payment record
	}
	public void CalculateTotalBillAmount()
	{
		// Method to calculate the total bill amount
	}
	public void UpdatePaymentStatus(string newStatus)
	{
		// Method to update the payment status
	}
	public void GenerationOfProfitReport()
	{
		// Method to calculate the profits from different sources
	}
}
//=========================================================//
public class IOFiles
{
	public void GuestFile()
	{
		FileStream GuestsData = new FileStream("GuestsFile.txt", FileMode.Create, FileAccess.Write);
		Guest g0 = new Guest("12345", "Omar", "11", 05215, 450);
		Guest g1 = new Guest("12546", "Khaled", "22", 01459, 550);
		Guest g2 = new Guest("16556", "Salma", "33", 04122, 660);
		Guest g3 = new Guest("18730", "Ahmad", "44", 02250, 720);
		//BinaryFormatter GDbf = new BinaryFormatter();
		JsonSerializer.Serialize(GuestsData, g0);
		JsonSerializer.Serialize(GuestsData, g1);
		JsonSerializer.Serialize(GuestsData, g2);
		JsonSerializer.Serialize(GuestsData, g3);
		/*GDbf.Serialize(GuestsData, g0);
		GDbf.Serialize(GuestsData, g1);
		GDbf.Serialize(GuestsData, g2);
		GDbf.Serialize(GuestsData, g3);
		GuestsData.Close();*/
	}
	public void ReservationFile()
	{
		FileStream ReservationData = new FileStream("ReservationFile.txt", FileMode.Create, FileAccess.Write);
	}
	public void ServiceFile()
	{
		// when any guesr request service, store here 
		FileStream ServiceData = new FileStream("ServiceFile.txt", FileMode.Create, FileAccess.Write);
	}
	public void PaymentFile()
	{
		FileStream PaymentData = new FileStream("PaymentFile.txt", FileMode.Create, FileAccess.Write);
	}
	public void RoomsFile()
	{
		FileStream RoomsData = new FileStream("RoomsFile.txt", FileMode.Create, FileAccess.Write);
		//int Number, string Type, double PricePerDay, bool AvailabilityStatus
		Room r0 = new Room(442, "Single", 25, true);
		Room r1 = new Room(102, "Double", 30, true);
		Room r2 = new Room(506, "Double", 32, false);
		Room r3 = new Room(702, "Suit", 40, true);
		Room r4 = new Room(333, "Double", 34, true);
		//BinaryFormatter RDbf = new BinaryFormatter();
		/*RDbf.Serialize(RoomsData, r0);
		RDbf.Serialize(RoomsData, r1);
		RDbf.Serialize(RoomsData, r2);
		RDbf.Serialize(RoomsData, r3);
		RDbf.Serialize(RoomsData, r4);*/
		JsonSerializer.Serialize(RoomsData, r0);
		JsonSerializer.Serialize(RoomsData, r1);
		JsonSerializer.Serialize(RoomsData, r2);
		JsonSerializer.Serialize(RoomsData, r3);
		JsonSerializer.Serialize(RoomsData, r4);
		RoomsData.Close();
		/*using (FileStream RoomsData = new FileStream("RoomsFile.txt", FileMode.Create, FileAccess.Write))
		using (StreamWriter writer = new StreamWriter(RoomsData))
		{
			Room[] rooms = new Room[] 
			{
				new Room(442, "Single", 25, true),
				new Room(102, "Double", 30, true),
				new Room(506, "Double", 32, false),
				new Room(702, "Suit", 40, true),
				new Room(333, "Double", 34, true)
			};
			foreach (var room in rooms)
			{
				string json = JsonSerializer.Serialize(room); writer.WriteLine(json);
			}*/
	}
}
//=========================================================//
[Serializable]
public class Service
{
	private string id;
	public string ID
	{
		get
		{
			return this.id;
		}
		set
		{

		}
	}  // Service ID
	private string notes;
	private string Notes
	{
		get
		{
			return this.notes;
		}
		set
		{

		}
	}  // Service notes
	   //**********************************************************************
	private string GuestID { get; set; } // Guest ID (from Guest class)
										 //**********************************************************************

	int i = 0;
	private string[] description = { "Car-Rental", "Kids-Zone" }; // Service types
	public string Description
	{
		get
		{
			return this.description[i];
		}
		set
		{

		}
	}  // Service description

	public void CalculateServiceAmount()
	{
		// Method to calculate the service amount
	}
}
//=========================================================//
public class HotelSystem 
{
	private List<Guest> Guests;
	private List<Room> Rooms;
	private List<Reservation> Reservations;
	private List<Payment> Payments;
	private List<Service> Services;
	private IOFiles ioFiles;
	public HotelSystem()
	{
		ioFiles = new IOFiles();
		ioFiles.GuestFile();
		ioFiles.RoomsFile();
		ioFiles.ReservationFile();
		ioFiles.PaymentFile();
		ioFiles.ServiceFile();
		Rooms = LoadRoomsFromFile();
		Guests = LoadGuestsFromFile();
		Payments = LoadPaymentsFromFile();
		Services = LoadServicesFromFile();
		Reservations = LoadReservationsFromFile();
	}
	public string LoginG()
	{
		List<Guest> Guests = LoadGuestsFromFile();
		Console.Write("Enter your ID : ");
		string id = Console.ReadLine();
		while (id.Length != 5)
		{
			Console.Write("Pleas enter valid ID (Note: Of 5 digits) : ");
			id = Console.ReadLine();
		}
		Console.WriteLine("");
		Console.Write("Enter Your Password : ");
		string password = Console.ReadLine();
		while (password.Length != 2)
		{
			Console.Write("Pleas enter correct Password : ");
			password = Console.ReadLine();
		}
		bool p = Guests.Contains(new Guest(id,password));
		bool IsGuestLoggedIn = true;
		if (p)
		{
			return ("Log-in process is successfully done! Welcome");
			IsGuestLoggedIn = true;
		}
		else
		{
			return ("Error, re-check your Password or ID, it does not compatable with any that in our system!");
			IsGuestLoggedIn = false;
		}

	}
	public void LogoutG()
	{
		string b = LoginG();
		if (b == "Log-in process is successfully done! Welcome")
		{
			Console.WriteLine("Thanks for Choosing us! We hope you had a delightful experience and look forward to welcoming you back soon.\nGoodbye!");
		}
		
	}
	public void NewUser(/*string ID, string Name, string Password, double PhoneNumber, double Bankbalance*/) 
	{
	//	string ID, string Name, string Password, double PhoneNumber, double Bankbalance
		Console.Write("Enter your Name : ");
		string name = Console.ReadLine();
		while (name == " ")
		{
				Console.Write("Pleas enter valid Name (Note: Readable Name) : ");
				name = Console.ReadLine();
		}
		Console.WriteLine("");
		Console.Write("Enter your ID : ");
		string id = Console.ReadLine();
		while (id.Length != 5)
		{
				Console.Write("Pleas enter valid ID (Note: Of 5 digits) : ");
				id = Console.ReadLine();
		}
		Console.WriteLine("");
		Console.Write("Make a Password : ");
		string password = Console.ReadLine();
		while (password.Length != 2)
		{
				Console.Write("Pleas enter valid Password (Note: Of 2 digits) : ");
				password = Console.ReadLine();
		}
		Console.WriteLine("");
		Console.Write("Enter your PhoneNumber : ");
		string PN = Console.ReadLine();
		double phonenumber = Convert.ToDouble(PN);
		while (PN.Length != 5 || phonenumber == 00000)
		{
			Console.Write("Please enter a valid Phone Number (Note: Of 5 digits) : ");
			PN = Console.ReadLine();
			phonenumber = Convert.ToDouble(PN);
		}
		Console.WriteLine("");
		Console.Write("Enter your Bank information (Balance) : ");
		double Balance = Convert.ToDouble(Console.ReadLine());
		while (Balance == 0)
		{
			Console.Write("Pleas enter valid Bank Account : ");
			Balance = Convert.ToDouble(Console.ReadLine());
		}
		Console.WriteLine("");
		Guest NewGuest = new Guest(name,id,password,phonenumber,Balance);
		Console.WriteLine("Your registration is successfully done! Welcome ");
		SaveGuestToFile(NewGuest);
	}
	public void SaveGuestToFile(Guest guest)
	{
		FileStream GuestsData = new FileStream("GuestsFile.txt", FileMode.Open, FileAccess.Write);
		JsonSerializer.Serialize(GuestsData, guest);
		GuestsData.Close();
	}
	public List<Guest> LoadGuestsFromFile()
	{
		using (FileStream GuestsData = new FileStream("GuestsFile.txt", FileMode.Open, FileAccess.Read))
		using (StreamReader reader = new StreamReader(GuestsData)) 
		{
			string jsonContent = reader.ReadToEnd();
			return JsonSerializer.Deserialize<List<Guest>>(jsonContent);
		}
	}
	public void AddRoom(Room room)
	{
		Rooms.Add(room);
		SaveRoomToFile(room);
	}
	public void SaveRoomToFile(Room room)
	{
		// Code to save room data to file
	}
	public void AddReservation(Reservation reservation)
	{
		Reservations.Add(reservation);
		SaveReservationToFile(reservation);
	}
	public void SaveReservationToFile(Reservation reservation)
	{
		// Code to save reservation data to file
	}
	public void AddPayment(Payment payment)
	{
		Payments.Add(payment);
		SavePaymentToFile(payment);
	}
	public void AddService(Service service)
	{
		Services.Add(service);
		SaveServiceToFile(service);
	}
	public void ViewAllGuests()
	{
		// Code to display all guests
	}
	public void ViewAllRooms()
	{
		// Code to display all rooms
	}
	public void ViewAllReservations()
	{
		// Code to display all reservations
	}
	public void ViewAllPayments()
	{
		// Code to display all payments
	}
	public void ViewAllServices()
	{
		// Code to display all services
	}
	// Methods moved from IOFiles
	public List<Reservation> LoadReservationsFromFile()
	{
		// Code to load reservation data from file
		return new List<Reservation>();
	}
	public void SaveServiceToFile(Service service)
	{
		// Code to save service data to file
	}
	public List<Service> LoadServicesFromFile()
	{
		// Code to load service data from file
		return new List<Service>();
	}
	public void SavePaymentToFile(Payment payment)
	{
		// Code to save payment data to file
	}
	public List<Payment> LoadPaymentsFromFile()
	{
		// Code to load payment data from file
		return new List<Payment>();
	}
	public List<Room> LoadRoomsFromFile()
	{
		// Code to load room data from file
		return new List<Room>();
	}
}
namespace Program
{
	class program
	{
		static void Main(string[] args)
		{
			HotelSystem hotelSystem = new HotelSystem();
			Console.WriteLine("Welcome to our hotel self-service system, You're here as ?\nPleas select a number \n\n\n1.Log-in as Guest \n2.Log-in as Manager \n3.Sign-in as new Guest \n4.Exit");
			int KindofUser = Convert.ToInt32(Console.ReadLine());
			/*if (args.Length > 0 && args[0] == "NewUser")
			{
				hotelSystem.NewUser();
			}*/
			switch (KindofUser)
			{
				case 1:
					hotelSystem.LoginG();
					break;
				case 2:
					Console.WriteLine("Manager");
					break;
				case 4:
					hotelSystem.Logout();
					break;
				case 3:
                    /*ProcessStartInfo psi = new ProcessStartInfo
					{
						FileName = "cmd.exe",
						Arguments = $"/c start \"dotnet run -- NewUser\"",
						UseShellExecute = true
					};
					Process.Start(psi);*/
					hotelSystem.NewUser();
					break;
				default:
					Console.Write("Try Again");
					break;
			}

			//******************************************************

			/*if (KindofUser == "1")
			{
				Console.WriteLine("Guest");
			}
			else if (KindofUser == "2")
			{
				Console.WriteLine("Manager");
			}
			else if (KindofUser == "3")
			{
				hotelSystem.Logout();
			} 
			else
			{
				Console.WriteLine("Try Again");
			}*/
		}
	}
}
