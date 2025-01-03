using System.Xml.Serialization;
using System;
using System.IO;
[Serializable]
public class IOFiles
{
	public void RoomsFile(List<Room> rooms = null)
	{
		if (rooms == null)
		{
			rooms = new List<Room>
			{
			new Room(442, "Single", 25, true),
			new Room(102, "Double", 30, true),
			new Room(506, "Double", 32, false),
			new Room(702, "Suit", 40, true),
			new Room(333, "Double", 34, true)
			};
		}
		FileStream RoomsData = new FileStream("RoomsFile.txt", FileMode.Create, FileAccess.Write);
		XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
		serializer.Serialize(RoomsData, rooms);
		RoomsData.Close();
	}
	public void GuestFile()
	{
		List<Guest> guests = new List<Guest>
			{
			 new Guest("12345", "Omar", "11", 05215, 450),
			 new Guest("12546", "Khaled", "22", 01459, 550),
			 new Guest("16556", "Salma", "33", 04122, 660),
			 new Guest("18730", "Ahmad", "44", 02250, 720)
			};
		FileStream GuestsData = new FileStream("GuestsFile.txt", FileMode.Create, FileAccess.Write);
		XmlSerializer serializer = new XmlSerializer(typeof(List<Guest>));
		serializer.Serialize(GuestsData, guests);
		GuestsData.Close();
	}
	public void ReservationFile()
	{
		FileStream ReservationData = new FileStream("ReservationFile.txt", FileMode.Create, FileAccess.Write);
		List<Reservation> Reservation = new List<Reservation>();
		XmlSerializer serializer = new XmlSerializer(typeof(List<Reservation>));
		serializer.Serialize(ReservationData, Reservation);
		ReservationData.Close();
	}
	public void ServiceFile()
	{
		FileStream ServiceData = new FileStream("ServiceFile.txt", FileMode.Create, FileAccess.Write);
		List<Service> services = new List<Service>();
		XmlSerializer serializer = new XmlSerializer(typeof(List<Service>));
		serializer.Serialize(ServiceData, services);
		ServiceData.Close();
	}
	public void PaymentFile()
	{
		FileStream PaymentData = new FileStream("PaymentFile.txt", FileMode.Create, FileAccess.Write);
		List<Payment> payments = new List<Payment>();
		XmlSerializer serializer = new XmlSerializer(typeof(List<Payment>));
		serializer.Serialize(PaymentData, payments);
		PaymentData.Close();
	}
}
[Serializable]
public class Guest
{
	public Guest(string ID, string Name, string Password, double PhoneNumber, double Bankbalance)
	{
		this.ID = ID;
		this.Name = Name;
		this.Password = Password;
		this.BankBalance = BankBalance;
		this.PhoneNumber = PhoneNumber;
	}
	public Guest(string ID, string Password)
	{
		this.ID = ID;
		this.Password = Password;
	}
	public Guest()
	{

	}
	public string ID
	{
		get;
		set;
	}
	public string Name
	{
		get;
		set;
	}
	public string Password
	{
		get;
		set;
	}
	public double PhoneNumber
	{
		get;
		set;
	}
	public double BankBalance
	{
		get;
		set;
	}
	public override string ToString()
	{
		return "Your name is : " + Name +
			"\nYour ID is : " + ID +
			"\nYour Phone Number is : " + PhoneNumber +
			"\nYour Bank Balance is : " + BankBalance;
	}
	public void GuestFunctions()
	{
		Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
		Console.WriteLine("You're here to? Pleas Select a number...\n\n\n" +
			"[1] Reserve a room\n" +
			"[2] Check-In\n" +
			"[3] Request a service\n" +
			"[4] Check-Out\n" +
			"[5] Pay for a reservation\n" +
			"[6] Pay for a service\n" +
			"[7] Log-Out");
		Console.Write("Enter your choice : ");
		int KindofUsage = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

		HotelSystem HS0 = new HotelSystem();
		Reservation RS0 = new Reservation();
		Service RV0 = new Service();
		switch (KindofUsage)
		{
			case 1:
				RS0.StartNewReservation();
				break;
			case 2:
				RS0.CheckInReservation();
				break;
			case 3:
				RV0.RequestAService();
				break;
			case 4:
				RS0.CheckOutReservation();
				break;
			case 5:
				Payment PY0 = new Payment();
				
				break;
			case 6:
				
				break;
			case 7:
				HS0.LogoutG();
				break;
			default:
				Console.WriteLine("Try Again");
				break;
		}
	}
	public override bool Equals(object obj) 
	{
		if (obj is Guest guest)
		{
			return ID == guest.ID && Password == guest.Password;
		}
		return false;
	}
	//public override int GetHashCode(){}
}
[Serializable]
public class Manager
{
	public string ID
	{
		get;
		set;
	}
	private string Password
	{
		get;
		set;
	}
	public void ManagerFunctions()
	{
		Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
		Console.WriteLine("You're here to? Pleas Select a number...\n\n\n" +
			"[1] View all guests \n" +
			"[2] View all reservations \n" +
			"[3] View all services\n" +
			"[4] View all payments \n" +
			"[5] View all rooms\n" +
			"[6] Update room information\n" +
			"[7] Generate profit report\n" +
			"[8] Log-Out");
		Console.Write("Enter your choice : ");
		int KindofUsage = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

		HotelSystem HS0 = new HotelSystem();
		switch (KindofUsage)
		{
			case 1:
				HS0.ViewAllGuests();
				break;
			case 2:
				HS0.ViewAllReservations();
				break;
			case 3:
				HS0.ViewAllServices();
				break;
			case 4:
				HS0.ViewAllPayments();
				break;
			case 5:
				HS0.ViewAllRooms();
				break;
			case 6:
				HS0.LoadRoomsFromFile();
				Room RM0 = new Room();
				// chose room to be updated
				//RM0.UpdateRoomInfo();
				break;
			case 7:
				Payment PY0 = new Payment();
				PY0.GenerationOfProfitReport();
				break;
			case 8:
				HS0.LogoutM();
				break;
			default:
				Console.WriteLine("Try Again");
				break;
		}
	}
}
[Serializable]
public class Service : Guest
{
	public string SID
	{
		get;
		set;
	}
	public int Notes
	{
		get;
		set;
	}
	int i = 0;
	private string[] description = { "Car-Rental", "Kids-Zone" }; // Service types (description)
	public string Description
	{
		get
		{
			return this.description[i];
		}
		set
		{

		}
	}
	public void RequestAService()
	{
		Console.WriteLine("What Service do you want to get?");
		int j = 1;
		foreach (string option in description)
		{
			Console.WriteLine("[" + j + "]" + " " + option);
			j++;
		}
		Console.Write("Enter your choice : ");
		int op = Convert.ToInt32(Console.ReadLine());
		if (op == 1)
		{
			Description = description[0];
		}
		else if (op == 2)
		{
			Description = description[1];
		}
		else
		{
			Console.WriteLine("Enter Available service");
		}
		CalculateServiceAmount();
	}
	public string CalculateServiceAmount()
	{
		int TotalServiceAmount;
		if (Description == description[0])
		{
			Console.Write("You choose the Car-Rental service, How many days you want to rent a car? ");
			int RentalDays = Convert.ToInt32(Console.ReadLine());
			this.Notes = RentalDays;
			TotalServiceAmount = 10 * RentalDays;
			return "Your service will cost : " + TotalServiceAmount;
		}
		else if (Description == description[1])
		{
			Console.Write("You choose the Kids-Zone service, How many kids do you have? ");
			int NumberOfKids = Convert.ToInt32(Console.ReadLine());
			this.Notes = NumberOfKids;
			TotalServiceAmount = 5 * NumberOfKids;
			return "Your service will cost : " + TotalServiceAmount;
		}
		return " ";
	}
}
[Serializable]
public class Payment : Reservation 
{
	// banck balance from guest class 
	public string BillNumber
	{
		get;
		set;
	} // bill number 
	  //**********************************************************************
	private string ReservationID { get; set; } // could be deleted and get fron reservation class when needed 
											   // as well as bank balance											   //**********************************************************************
	public double TotalAmount
	{
		get;
		set;
	}
	public string PaymentSource
	{
		get;
		set;
	}
	public string PaymentStatus
	{
		get;
		set;
	}
	public bool IsbalancePayable(double TotalAmount, Guest g)
	{
		double Balance = g.BankBalance;
		return TotalAmount <= Balance;
	}
	public void CreatePaymentRecord(string reservationID, double amount, string source) { }
	public void CalculateTotalBillAmount() { }
	public void UpdatePaymentStatus(string newStatus) { }
	public void GenerationOfProfitReport() { }
	public void PayForReservation() { }
	public void PayForService() { }
}
[Serializable]
public class Room : Guest
{
	public int Number
	{
		get;
		set;
	}
	public string Type
	{
		get;
		set;
	}
	public double PricePerDay
	{
		get;
		set;
	}
	public bool AvailabilityStatus
	{
		get;
		set;
	}
	public Room(int Number, string Type, double PricePerDay, bool AvailabilityStatus)
	{
		this.Number = Number;
		this.Type = Type;
		this.PricePerDay = PricePerDay;
		this.AvailabilityStatus = AvailabilityStatus;
	}
	public Room() { }
	public void UpdateRoomInfo(int Number, string Type, double PricePerDay, bool AvailabilityStatus)
	{

	}
	public bool AvailableRoomsOnly()
	{
		List<Room> list;
		HotelSystem hS = new HotelSystem();
		list = hS.LoadRoomsFromFile();
		// for all rooms


		List<Room> AvailableRooms = new List<Room>();
		foreach (Room i in list)
		{
			if (i.AvailabilityStatus)
			{
				AvailableRooms.Add(i);
			}
		}
		// seperate only available rooms 
		int j = 1;
		foreach (Room room in AvailableRooms)
		{
			Console.Write("[" + j + "]");
			Console.WriteLine($" Room Number: {room.Number}, Room Type: {room.Type}");
			j++;
		}
		// print available rooms only 
		Console.Write("Enter your choice : ");
		string y0 = Console.ReadLine();
		int y1 = Convert.ToInt32(y0);
		Room RTBU = AvailableRooms[y1 - 1];
		RTBU.AvailabilityStatus = false;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].Number == RTBU.Number)
			{
				list[i] = RTBU;
				break;
			}
		}
		IOFiles io = new IOFiles();
		io.RoomsFile(list);

		if (y0 != null)
		{
			return true;
		}
		return false;
	}
}
[Serializable]
public class Reservation : Room 
{
	private static readonly string[] MealOptions = { "Break-fast", "Break-fast and Lunch", "Full-Board" };
	public string RID
	{
		get;
		set;
	}
	public DateTime CheckInDate
	{
		get;
		set;
	}
	public DateTime CheckOutDate
	{
		get;
		set;
	}
	public string MealOption
	{
		get;
		set;
	}
	public string ReservationStatus
	{
		get;
		set;
	}
	public Reservation(string RID, DateTime CheckInDate, DateTime CheckOutDate, string MealOption, string ReservationStatus, int Number, string Type, double PricePerDay, bool AvailabilityStatus) :
		base( Number, Type, PricePerDay, AvailabilityStatus)
	{
		this.RID = RID;
		this.CheckInDate = CheckInDate;
		this.CheckOutDate = CheckOutDate;
		this.MealOption = MealOption;
		this.ReservationStatus = ReservationStatus;
	}
	public Reservation() { }
	public int GenerateUnique4DigitIDNumber()
	{
		HotelSystem hotelSystem = new HotelSystem();
		List<Reservation> reservations = hotelSystem.LoadReservationsFromFile();
		int reservationCounter = reservations.Count;
		int baseNumber = 0004;
		reservationCounter++;
		int uniqueIDNumber = baseNumber + reservationCounter;
		return uniqueIDNumber; 
	}
	public bool StartNewReservation()
	{
		int UIDN = GenerateUnique4DigitIDNumber();
		Console.WriteLine("Your Reservation ID is :" + UIDN);
		Console.WriteLine("Choose the appropriate room for your stay : ");
		Room room = new Room();
		room.AvailableRoomsOnly();
		Console.WriteLine("Select the meal option that suits you best : ");
		int i = 1;
		foreach (string option in MealOptions)
		{
			Console.WriteLine("[" + i + "]" + " " + option);
			i++;
		}
		Console.Write("Enter your choice : ");
		int op = Convert.ToInt32(Console.ReadLine());
		if (op == 1)
		{
			MealOption = MealOptions[0];
		}
		else if (op == 2)
		{
			MealOption = MealOptions[1];
		}
		else if (op == 3)
		{
			MealOption = MealOptions[2];
		}
		else
		{
			Console.WriteLine("Enter Available meal option");
		}
		ReservationStatus = "Confirmed";

		if (op != 1 || op != 2 || op != 3)
		{
			if (room.AvailableRoomsOnly())
			{
				return true;
			}
		}
		return false;
	}
	public double CalculateReservationAmount()
	{
		TimeSpan residenceDays = this.CheckOutDate - this.CheckInDate;
		//Days is a proparity in time span structure 
		int days = residenceDays.Days;
		Console.WriteLine($"Your reservation is for {days} days.");
		double amount = days * this.PricePerDay;
		if (this.MealOption == MealOptions[0])
		{
			return amount;
		}
		else if (this.MealOption == MealOptions[1])
		{
			return 1.2 * amount;
		}
		else if (this.MealOption == MealOptions[2])
		{
			return 1.4 * amount;
		}
		return 0;
	}
	public double ApplyDiscount(double amount)
	{
		double FinalAmount = amount * 0.6;
		return FinalAmount;
	}
	public string CheckInReservation()
	{
		Console.Write("Please enter your Check-In date (yyyy-MM-dd): ");
		string checkInInput = Console.ReadLine();
		if (DateTime.TryParseExact(checkInInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime CheckInDate))
		{
			this.ReservationStatus = "Checked-in";
			if (checkInInput == "2025-02-01")
			{
				double i = CalculateReservationAmount();
				double j = ApplyDiscount(i);
				return "Your Check-in date is :" + checkInInput + "Your total reservation cost is :" + j;
			}
			else if (checkInInput == "2025-04-22")
			{
				double i = CalculateReservationAmount();
				double j = ApplyDiscount(i);
				return "Your Check-in date is :" + checkInInput + "Your total reservation cost is :" + j;
			}
			else if (checkInInput == "2025-10-10")
			{
				double i = CalculateReservationAmount();
				double j = ApplyDiscount(i);
				return "Your Check-in date is :" + checkInInput + "Your total reservation cost is :" + j;
			}
			else
			{
				double i = CalculateReservationAmount();
				return "Your Check-in date is :" + checkInInput + "Your total reservation cost is :" + i;
			}
		}
		else
		{
			return ("Invalid date format. Please enter the date in the format yyyy-MM-dd.");
		}
	}
	public string CheckOutReservation()
	{
		this.ReservationStatus = "Checked-out";
		Console.Write("Please enter your Check-Out date (yyyy-MM-dd): ");
			string checkOutInput = Console.ReadLine();
			if (DateTime.TryParseExact(checkOutInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime CheckOutDate))
			{
				if (CheckOutDate > CheckInDate)
				{
				return "Your Check-Out date is :" + checkOutInput;
			}
				else
				{
					return "Check-Out date must be later than Check-In date. Please enter a valid date.";
				}
			}
			else
			{
				return "Invalid date format. Please enter the date in the format yyyy-MM-dd.";
			}
	}
}
[Serializable]
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
	public void ViewAllGuests()
	{
		int v = 1;
		foreach (Guest guest in Guests)
		{
			Console.Write("[" + v + "]");
			Console.WriteLine(
				$" Guest Name : {guest.Name}," +
				$" Guest Phone-Number : {guest.PhoneNumber}," +
				$" Guest National-ID : {guest.ID}," +
				$" Guest Bank-Balance : {guest.BankBalance}," +
				$" Guest Password : {guest.Password}"
				);
			v++;
		}
	}
	public void ViewAllServices()
	{
		int v = 1;
		foreach (Service service in Services)
		{
			Console.Write("[" + v + "]");
			Console.WriteLine(
				$" Service ID : {service.SID}," +
				$" Service Description : {service.Description},"+
				$" Service Notes : {service.Notes},"+
				$" Guest's national ID (who order this service) : {service.ID}"
				);
			v++;
		}
	}
	public void ViewAllPayments()
	{
		int v = 1;
		foreach (Payment payment in Payments)
		{
			Console.Write("[" + v + "]");
			Console.WriteLine(
				$" Room Number : {payment.BillNumber}," +
				$" Room Type : {payment.PaymentSource},"+
				$" Room Type : {payment.PaymentStatus}," +
				$" Room Type : {payment.TotalAmount}," +
			    $" Guest's national ID (who order this service or reserve a room) : {payment.ID}" 
				);
			v++;
		}
	}
	public void ViewAllReservations()
	{
		int v = 1;
		foreach (Reservation reservation in Reservations)
		{
			Console.Write("[" + v + "]");
			Console.WriteLine(
				$" Reservation ID : {reservation.RID}," +
				$" Check-in Date : {reservation.CheckInDate},"+
				$" Check-out Date : {reservation.CheckOutDate},"+
				$" Reservation Status : {reservation.ReservationStatus},"+
				$" Meals Option : {reservation.MealOption},"+
			    $" Guest's national ID (who reserve this room) : {reservation.ID},"+
			    $" Room Number : {reservation.Number}"
				);
			v++;
		}
	}
	public void ViewAllRooms()
	{
		int v = 1;
		foreach (Room room in Rooms)
		{
			Console.Write("[" + v + "]");
			Console.WriteLine(
				$" Room Number: {room.Number}," +
				$" Room Type: {room.Type}," +
				$" Room Price-per Day: {room.PricePerDay}," +
				$" Room Availability Status: {room.AvailabilityStatus}"
				);
			v++;
		}
	}
	public bool LoginM()
	{
		Console.Write("Enter your ID :");
		string id = Console.ReadLine();
		while (id != "m2024")
		{
			Console.Write("Pleas enter valid ID (Note: There's only one Manager) : ");
			id = Console.ReadLine();
		}
		Console.Write("Enter your Password :");
		string password = Console.ReadLine();
		while (password != "00")
		{
			Console.Write("Pleas enter correct Password : ");
			password = Console.ReadLine();
		}
		Console.WriteLine("Log-in is successfully done!");
		return true;
	}
	public void LogoutM()
	{
		if (LoginM())
		{
			Console.WriteLine(" You loged-out successfully, Goodbye");
		}
	}
	public void NewUser()
	{
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
		Guest NewGuest = new Guest(name, id, password, phonenumber, Balance);
		Console.WriteLine("Your registration is successfully done! Welcome ");
		SaveGuestToFile(NewGuest);
	}
	public bool LoginG()
	{
		Console.WriteLine(); Console.WriteLine();
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
		Guest p = Guests.Find(guest => guest.ID == id && guest.Password == password);
		if (p != null)
		{
			Console.WriteLine("Log-in process is successfully done! Welcome");
			p.GuestFunctions();
			return true;
		}
		else
		{
			Console.WriteLine("Error, re-check your Password or ID, it does not compatable with any that is in our system!");
			return false;
		}
	}
	public void LogoutG()
	{
		if (LoginG())
		{
			Console.WriteLine("Thanks for Choosing us! We hope you had a delightful experience and look forward to welcoming you back soon." +
				"\nGoodbye!");
		}
	}
	public void SaveGuestToFile(Guest guest)
	{
		List<Guest> guests = LoadGuestsFromFile();
		guests.Add(guest);
		FileStream GuestsDataSave = new FileStream("GuestsFile.txt", FileMode.Append, FileAccess.Write);
		XmlSerializer serializer = new XmlSerializer(typeof(List<Guest>));
		serializer.Serialize(GuestsDataSave, guests);
		GuestsDataSave.Close();
	}
	public List<Guest> LoadGuestsFromFile()
	{
		List<Guest> Guests = new List<Guest>();
		if (!File.Exists("GuestsFile.txt"))
		{
			throw new FileNotFoundException("The file 'GuestsFile.txt' does not exist.");
		}
		FileStream GuestsDataLoad = new FileStream("GuestsFile.txt", FileMode.Open, FileAccess.Read);
		XmlSerializer serializer = new XmlSerializer(typeof(List<Guest>));
		if (GuestsDataLoad.Length > 0)
		{
			Guests = (List<Guest>)serializer.Deserialize(GuestsDataLoad);
		}
		GuestsDataLoad.Close();
		return Guests;
	}
	public List<Room> LoadRoomsFromFile()
	{
		List<Room> Rooms = new List<Room>();
		if (!File.Exists("RoomsFile.txt"))
		{
			throw new FileNotFoundException("The file 'RoomsFile.txt' does not exist.");
		}
		FileStream RoomsDataLoad = new FileStream("RoomsFile.txt", FileMode.Open, FileAccess.Read);
		XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
		if (RoomsDataLoad.Length > 0)
		{
			Rooms = (List<Room>)serializer.Deserialize(RoomsDataLoad);
		}
		RoomsDataLoad.Close();
		return Rooms;
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
		return new List<Service>();
	}
	public void SavePaymentToFile(Payment payment)
	{
	}
	public List<Payment> LoadPaymentsFromFile()
	{
		return new List<Payment>();
	}
	public void Exit()
	{
		Console.WriteLine("Press any key to exit the system...");
		Console.ReadKey();
	}
}
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
				int KindofUser =Convert.ToInt32( Console.ReadLine());
				switch (KindofUser)
				{
					case 1:
						hotelSystem.LoginG();
						break;
					case 2:
						hotelSystem.LoginM();
						break;
					case 3:
						hotelSystem.NewUser();
						break;
					case 4:
						hotelSystem.Exit();
						exit = true;
						break;
					default:
						Console.WriteLine("Invalid choice, please try again.");
						break;
				}
			}
		}
	}
}
