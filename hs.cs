using System;
using System.IO;
using System.Text.Json;
using static IOFiles;
interface User
{
	public void Login(string ID, string Password);
	public void Logout();
	public void NewUser(string ID, string Name, string Password);
}
[Serializable]
public class Guest : User 
{
	public Guest(string ID, string Name, string Password, double PhoneNumber, double Bankbalance)
	{
		this.id = ID;
		this.name = Name;	
		this.password = Password;
		this.bankbalance = Bankbalance;
		this.phonenumber = PhoneNumber;
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
	public void Login(string ID, string Password) { } 
	public void Logout() { } 
	public void NewUser(string ID, string Name, string Password) { }
}
[Serializable]
public class Manager : User 
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
	}
	private string password;
	private string Password
	{
		get
		{
			return this.password;
		}
		set
		{

		}
	}
	// should be verify (ID == m2024) (Passward == 00)
	public void Login(string ID, string Password)
	{ 
		ID = "m2024";
		Password = "00";
		// Method for manager login
		if (this.ID == ID && this.Password == Password)
		{
			Console.WriteLine("Log-in is successfully done!");
		}
		else
		{
			Console.WriteLine("Error, re-check your Password or ID"); ;
	    }
	}
	public void Logout()
	{
		// Method for manager logout
	}
	public void NewUser(string ID, string Name, string Password) { } // adding new manager to the system who does not have account 
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
	private int roomnumber;
	public int RoomNumber 
	{
		get
		{
			return this.roomnumber;
		}
		set
		{

		}
	}
	//**********************************************************************
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
		Guest g0 = new Guest("12345","Omar","11",05215,450);
		Guest g1 = new Guest("12546","Khaled", "22",01459,550);
		Guest g2 = new Guest("16556","Salma", "33",04122,660);
		Guest g3 = new Guest("18730","Ahmad", "44",02250,720);
		JsonSerializer.Serialize(GuestsData, g0);
		JsonSerializer.Serialize(GuestsData, g1);
		JsonSerializer.Serialize(GuestsData, g2);
		JsonSerializer.Serialize(GuestsData, g3);
		GuestsData.Close();
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
		Room r0 = new Room(442,"Single",25,true);
		Room r1 = new Room(102,"Double",30,true);
		Room r2 = new Room(506,"Double",32,false);
		Room r3 = new Room(702,"Suit",40,true);
		Room r4 = new Room(333,"Double",34,true);
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
	public class HotelSystem : User
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
		public void Login(string ID, string Password) { }
		public void Logout() { }
		public void NewUser(string ID, string Name, string Password) { }
		public void AddGuest(Guest guest)
		{
			Guests.Add(guest);
			SaveGuestToFile(guest);
		}
		public void AddRoom(Room room)
		{
			Rooms.Add(room);
			SaveRoomToFile(room);
		}
		public void AddReservation(Reservation reservation)
		{
			Reservations.Add(reservation);
			SaveReservationToFile(reservation);
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
		public void SaveGuestToFile(Guest guest)
		{
			// Code to save guest data to file
		}
		public List<Guest> LoadGuestsFromFile()
		{
			// Code to load guest data from file
			return new List<Guest>();
		}
		public void SaveReservationToFile(Reservation reservation)
		{
			// Code to save reservation data to file
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
		public void SaveRoomToFile(Room room)
		{
			// Code to save room data to file
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
		static void Main()
		{
			HotelSystem hotelSystem = new HotelSystem();
			Console.WriteLine("Welcome to our hotel self-service system, You're here as ?\nPleas select a number \n\n\n1.Guest \n2.Manager");

			int KindofUser = Convert.ToInt32(Console.ReadLine());
			switch (KindofUser) 
			{

				case 1:
					Console.WriteLine("Guest");
					break;
				case 2:
					Console.WriteLine("Manager");
					break;
				default:
					Console.WriteLine("Try Again");
				break;
			}

		}
	}
}
