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
	public Guest(string ID, string Name, string Password, double PhoneNumber, double BankBalance)
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
	public Guest() { }
	public string ID { get; set; }
	public string Name { get; set; }
	public string Password { get; set; }
	public double PhoneNumber { get; set; }
	public double BankBalance { get; set; }
	public override string ToString()
	{
		return "Your name is : " + Name +
			"\nYour ID is : " + ID +
			"\nYour Phone Number is : " + PhoneNumber +
			"\nYour Bank Balance is : " + BankBalance;
	}
	public void GuestFunctions(Guest guest)
	{
		bool exitGuestMenu = false;
		while (!exitGuestMenu)
		{
			Console.WriteLine("\n");
			Console.WriteLine("You're here to? Please Select a number...\n\n\n" +
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
					Reservation R0 = RS0.StartNewReservation(guest);
					if (R0 != null)
					{
						HS0.AddReservation(R0);
					}
					break;
				case 2:
					string id0 = guest.ID;
					Console.WriteLine(RS0.CheckInReservation(id0));
					break;
				case 3:
					string id1 = guest.ID;
					RV0.RequestAService(id1);
					break;
				case 4:
					string id2 = guest.ID;
					Console.WriteLine(RS0.CheckOutReservation(id2));
					break;
				case 5:
					Payment PY0 = new Payment();
					PY0.PayForReservation(guest);
					break;
				case 6:
					Payment PY1 = new Payment();
					PY1.PayForService(guest);
					break;
				case 7:
					HS0.LogoutG();
					exitGuestMenu = true;
					break;
				default:
					Console.WriteLine("Try Again");
					break;
			}
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
		bool exitManagerMenu = false;
		while (!exitManagerMenu)
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
					Room RM0 = new Room();
					RM0.UpdateRoomInfo();
					break;
				case 7:
					Payment PY0 = new Payment();
					PY0.GenerationOfProfitReport();
					break;
				case 8:
					HS0.LogoutM();
					exitManagerMenu = true;
					break;
				default:
					Console.WriteLine("Try Again");
					break;
			}
		}
	}
}
[Serializable]
public class Service : Guest
{
	public string SID { get; set; }
	public int Notes { get; set; }
	private string[] description = { "Car-Rental", "Kids-Zone" }; 
	public string Description { get; set; }
	public void RequestAService(string guestID)
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
			Console.Write("Enter the number of rental days : ");
			int notes = Convert.ToInt32(Console.ReadLine());
			this.Notes = notes;
		}
		else if (op == 2)
		{
			Description = description[1];
			Console.Write("Enter the number of kids : ");
			int notes = Convert.ToInt32(Console.ReadLine());
			this.Notes = notes;
		}
		else
		{
			Console.WriteLine("Enter Available service");
			return;
		}
		HotelSystem HSS = new HotelSystem();
		HSS.SaveServiceToFile(this);
		string totalAmount = CalculateServiceAmount();
		string amountString = totalAmount.Split(':')[1].Trim();
		int amount;
		if (int.TryParse(amountString, out amount))
		{
			Payment payment = new Payment();
			payment.CreateAndSavePaymentRecord(Description, amount, guestID);
			Console.WriteLine($"Your service request is confirmed. Your bill number is: {payment.BillNumber}. Your bill amount is: {payment.TotalAmount}");
		}
		else
		{
			Console.WriteLine("Error: Unable to parse the total amount.");
		}
	}
	public string CalculateServiceAmount()
	{
		int TotalServiceAmount;
		if (Description == description[0])
		{
			TotalServiceAmount = 10 * this.Notes;
			return "Your service will cost : " + TotalServiceAmount;
		}
		else if (Description == description[1])
		{
			TotalServiceAmount = 5 * this.Notes;
			return "Your service will cost : " + TotalServiceAmount;
		}
		return "Select valid option";
	}
}
[Serializable]
public class Payment : Reservation
{
	public string BillNumber
	{
		get;
		set;
	}
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
	public Payment()
	{
		
	}
	public bool IsbalancePayable(double TotalAmount, Guest g)
	{
		double Balance = g.BankBalance;
		return TotalAmount <= Balance;
	}
	public void CreateAndSavePaymentRecord(string paymentSource, double totalAmount, string guestID)
	{
		this.BillNumber = GenerateUniqueBillNumber().ToString();
		this.PaymentSource = paymentSource;
		this.TotalAmount = totalAmount;
		this.PaymentStatus = "not paid";
		this.ID = guestID; 
		HotelSystem hotelSystem = new HotelSystem();
		hotelSystem.AddPayment(this);
	}
	public string GenerateUniqueBillNumber()
	{
		HotelSystem hotelSystem = new HotelSystem();
		List<Payment> payments = hotelSystem.LoadPaymentsFromFile();
		int paymentCounter = payments.Count;
		paymentCounter++;
		return paymentCounter.ToString("D4");
	}
	public void PayForReservation(Guest guest)
	{
		HotelSystem hotelSystem = new HotelSystem();
		List<Payment> payments = hotelSystem.LoadPaymentsFromFile();
		var unpaidPayments = payments.Where(p => p.PaymentSource == "Reservation" && p.ID == guest.ID && p.PaymentStatus == "not paid").ToList();
		if (unpaidPayments.Count == 0)
		{
			Console.WriteLine("No unpaid reservations found for the logged-in guest.");
			return;
		}
		Console.WriteLine("Your unpaid reservations:");
		foreach (Payment payment in unpaidPayments)
		{
			Console.WriteLine($"Bill Number: {payment.BillNumber}, Amount: {payment.TotalAmount}");
		}
		Console.Write("Enter the bill number to pay for: ");
		string billNumber = Console.ReadLine();
		var selectedPayment = unpaidPayments.FirstOrDefault(p => p.BillNumber == billNumber);
		if (selectedPayment == null)
		{
			Console.WriteLine("Invalid bill number.");
			return;
		}
		if (!IsbalancePayable(selectedPayment.TotalAmount, guest))
		{
			Console.WriteLine("Insufficient bank balance.");
			return;
		}
		guest.BankBalance -= selectedPayment.TotalAmount;
		selectedPayment.PaymentStatus = "paid";
		hotelSystem.UpdateGuestInFile(guest);
		hotelSystem.UpdatePaymentInFile(selectedPayment);
		Console.WriteLine("Payment successful. Your reservation payment status is now 'paid'.");
	}
	public void PayForService(Guest guest)
	{
		HotelSystem hotelSystem = new HotelSystem();
		List<Payment> payments = hotelSystem.LoadPaymentsFromFile();
		var unpaidPayments = payments.Where(p => p.PaymentSource == "Service" && p.ID == guest.ID && p.PaymentStatus == "not paid").ToList();
		if (unpaidPayments.Count == 0)
		{
			Console.WriteLine("No unpaid services found for the logged-in guest.");
			return;
		}
		Console.WriteLine("Your unpaid services:");
		foreach (Payment payment in unpaidPayments)
		{
			Console.WriteLine($"Bill Number: {payment.BillNumber}, Amount: {payment.TotalAmount}");
		}
		Console.Write("Enter the bill number to pay for: ");
		string billNumber = Console.ReadLine();
		var selectedPayment = unpaidPayments.FirstOrDefault(p => p.BillNumber == billNumber);
		if (selectedPayment == null)
		{
			Console.WriteLine("Invalid bill number.");
			return;
		}
		if (!IsbalancePayable(selectedPayment.TotalAmount, guest))
		{
			Console.WriteLine("Insufficient bank balance.");
			return;
		}
		guest.BankBalance -= selectedPayment.TotalAmount;
		selectedPayment.PaymentStatus = "paid";
		hotelSystem.UpdateGuestInFile(guest);
		hotelSystem.UpdatePaymentInFile(selectedPayment);
		Console.WriteLine("Payment successful. Your service payment status is now 'paid'.");
	}
	public void GenerationOfProfitReport()
	{
		double totalRoomReservations = 0;
		double totalCarRental = 0;
		double totalKidsZone = 0;
		HotelSystem HSP = new HotelSystem();
		List<Payment> payments = HSP.LoadPaymentsFromFile();
		var paidPayments = payments.Where(p => p.PaymentStatus == "paid").ToList();

		foreach (Payment payment in paidPayments)
		{
			switch (payment.PaymentSource)
			{
				case "Reservation":
					totalRoomReservations += payment.TotalAmount;
					break;
				case "Car-Rental":
					totalCarRental += payment.TotalAmount;
					break;
				case "Kids-Zone":
					totalKidsZone += payment.TotalAmount;
					break;
			}
		}
		Console.WriteLine("Profit Report:");
		Console.WriteLine($"Total from Room Reservations: {totalRoomReservations}");
		Console.WriteLine($"Total from Car Rental: {totalCarRental}");
		Console.WriteLine($"Total from Kids Zone: {totalKidsZone}");
	}
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
	public void UpdateRoomInfo()
	{
		HotelSystem hotelSystem = new HotelSystem();
		List<Room> rooms = hotelSystem.LoadRoomsFromFile();
		Console.WriteLine("Available rooms:");
		foreach (Room room in rooms)
		{
			Console.WriteLine($"Room Number: {room.Number}, Type: {room.Type}, Price per Day: {room.PricePerDay}");
		}
		Console.Write("Enter the room number to update: ");
		int roomNumber = Convert.ToInt32(Console.ReadLine());
		Room selectedRoom = rooms.FirstOrDefault(r => r.Number == roomNumber);
		if (selectedRoom == null)
		{
			Console.WriteLine("Invalid room number.");
			return;
		}
		Console.Write("Enter new type: ");
		string newType = Console.ReadLine();
		Console.Write("Enter new price per day: ");
		double newPrice = Convert.ToDouble(Console.ReadLine());
		selectedRoom.Type = newType;
		selectedRoom.PricePerDay = newPrice;
		using (FileStream RoomsDataSave = new FileStream("RoomsFile.txt", FileMode.Create, FileAccess.Write))
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
			serializer.Serialize(RoomsDataSave, rooms);
		}
		Console.WriteLine("Room information updated successfully.");
	}


	public bool AvailableRoomsOnly()
	{
		List<Room> list;
		HotelSystem hS = new HotelSystem();
		list = hS.LoadRoomsFromFile();
		List<Room> AvailableRooms = new List<Room>();
		foreach (Room i in list)
		{
			if (i.AvailabilityStatus)
			{
				AvailableRooms.Add(i);
			}
		}
		int j = 1;
		foreach (Room room in AvailableRooms)
		{
			Console.Write("[" + j + "]");
			Console.WriteLine($" Room Number: {room.Number}, Room Type: {room.Type}");
			j++;
		}
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
	public string RID { get; set; }
	public DateTime CheckInDate { get; set; }
	public DateTime CheckOutDate { get; set; }
	public string MealOption { get; set; }
	public string ReservationStatus { get; set; }
	public Reservation(string RID, DateTime CheckInDate, DateTime CheckOutDate, string MealOption, string ReservationStatus, int Number, string Type, double PricePerDay, bool AvailabilityStatus) :
		base(Number, Type, PricePerDay, AvailabilityStatus)
	{
		this.RID = RID;
		this.CheckInDate = CheckInDate;
		this.CheckOutDate = CheckOutDate;
		this.MealOption = MealOption;
		this.ReservationStatus = ReservationStatus;
	}
	public Reservation() { }
	public string GenerateUnique4DigitIDNumber()
	{
		HotelSystem hotelSystem = new HotelSystem();
		List<Reservation> reservations = hotelSystem.LoadReservationsFromFile();
		int reservationCounter = reservations.Count;
		reservationCounter++;
		return reservationCounter.ToString("D4");
	}
	public Reservation StartNewReservation(Guest guest)
	{
		Console.WriteLine("Choose the appropriate room for your stay : ");
		HotelSystem hotelSystem = new HotelSystem();
		List<Room> availableRooms = hotelSystem.LoadRoomsFromFile().Where(r => r.AvailabilityStatus).ToList();

		if (availableRooms.Count == 0)
		{
			Console.WriteLine("No available rooms.");
			return null;
		}

		int roomIndex = 1;
		foreach (Room room in availableRooms)
		{
			Console.WriteLine($"[{roomIndex}] Room Number: {room.Number}, Type: {room.Type}, Price per Day: {room.PricePerDay}");
			roomIndex++;
		}

		Console.Write("Enter the number of the room you want to reserve: ");
		int selectedRoomIndex = Convert.ToInt32(Console.ReadLine()) - 1;

		if (selectedRoomIndex < 0 || selectedRoomIndex >= availableRooms.Count)
		{
			Console.WriteLine("Invalid room selection.");
			return null;
		}

		Room selectedRoom = availableRooms[selectedRoomIndex];

		Console.Write("Please enter your Check-In date (yyyy-MM-dd): ");
		string checkInInput = Console.ReadLine();
		DateTime checkInDate;
		while (!DateTime.TryParseExact(checkInInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out checkInDate))
		{
			Console.WriteLine("Invalid date format. Please enter the date in the format yyyy-MM-dd.");
			checkInInput = Console.ReadLine();
		}

		Console.Write("Please enter your Check-Out date (yyyy-MM-dd): ");
		string checkOutInput = Console.ReadLine();
		DateTime checkOutDate;
		while (!DateTime.TryParseExact(checkOutInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out checkOutDate) || checkOutDate <= checkInDate)
		{
			Console.WriteLine("Invalid date format or Check-Out date must be later than Check-In date. Please enter a valid date.");
			checkOutInput = Console.ReadLine();
		}

		Console.WriteLine("Select the meal option that suits you best : ");
		int i = 1;
		foreach (string option in MealOptions)
		{
			Console.WriteLine("[" + i + "] " + option);
			i++;
		}
		Console.Write("Enter your choice : ");
		int mealOptionIndex = Convert.ToInt32(Console.ReadLine());
		while (mealOptionIndex < 1 || mealOptionIndex > MealOptions.Length)
		{
			Console.WriteLine("Invalid choice. Enter Available meal option.");
			mealOptionIndex = Convert.ToInt32(Console.ReadLine());
		}
		string mealOption = MealOptions[mealOptionIndex - 1];

		this.RID = GenerateUnique4DigitIDNumber();
		this.CheckInDate = checkInDate;
		this.CheckOutDate = checkOutDate;
		this.MealOption = mealOption;
		this.ReservationStatus = "Confirmed";
		this.ID = guest.ID;
		this.Number = selectedRoom.Number;
		this.Type = selectedRoom.Type;
		this.PricePerDay = selectedRoom.PricePerDay;
		this.AvailabilityStatus = selectedRoom.AvailabilityStatus;

		hotelSystem.AddReservation(this);
		double totalAmount = CalculateReservationAmount();
		Payment payment = new Payment();
		payment.CreateAndSavePaymentRecord("Reservation", totalAmount, guest.ID);

		selectedRoom.AvailabilityStatus = false;
		hotelSystem.UpdateRoomFile(selectedRoom);

		Console.WriteLine($"Your reservation is confirmed.\nReservation ID: {this.RID}.\nYour bill number is: {payment.BillNumber}.\nYour bill amount is: {payment.TotalAmount}");
		return this;
	}

	public double CalculateReservationAmount()
	{
		TimeSpan residenceDays = this.CheckOutDate - this.CheckInDate;
		int days = residenceDays.Days;
		Console.WriteLine($"Your reservation is for {days} days.");
		double amount = days * this.PricePerDay;

		if (this.MealOption == MealOptions[0])
		{
			amount = amount;
		}
		else if (this.MealOption == MealOptions[1])
		{
			amount = 1.2 * amount;
		}
		else if (this.MealOption == MealOptions[2])
		{
			amount = 1.4 * amount;
		}

		if (this.CheckInDate == new DateTime(2025, 1, 2) ||
			this.CheckInDate == new DateTime(2025, 4, 22) ||
			this.CheckInDate == new DateTime(2025, 10, 10))
		{
			amount = ApplyDiscount(amount);
		}

		return amount;
	}
	public double ApplyDiscount(double amount)
	{
		Console.WriteLine("Congrats! You've got a discount!");
		double FinalAmount = amount * 0.6;
		return FinalAmount;
	}
	public string CheckInReservation(string guestID)
	{
		HotelSystem hotelSystem = new HotelSystem();
		List<Reservation> reservations = hotelSystem.LoadReservationsFromFile();

		List<Reservation> confirmedReservations = reservations
			.Where(r => r.ID == guestID && r.ReservationStatus == "Confirmed")
			.ToList();
		if (confirmedReservations.Count == 0)
		{
			return "No confirmed reservations found for the logged-in guest.";
		}
		Console.WriteLine("Your confirmed reservations:");
		for (int i = 0; i < confirmedReservations.Count; i++)
		{
			Console.WriteLine($"[{i + 1}] Reservation ID: {confirmedReservations[i].RID}, Check-in Date: {confirmedReservations[i].CheckInDate}, Check-out Date: {confirmedReservations[i].CheckOutDate}");
		}
		Console.Write("Enter the reservation ID to check-in: ");
		string reservationID = Console.ReadLine();
		Reservation selectedReservation = confirmedReservations.FirstOrDefault(r => r.RID == reservationID);
		if (selectedReservation == null)
		{
			return "Invalid reservation ID.";
		}
		selectedReservation.ReservationStatus = "Checked-in";
		hotelSystem.UpdateReservationInFile(selectedReservation);
		return "Check-in successful. Your reservation status is now 'Checked-in'.";
	}
	public string CheckOutReservation(string guestID)
	{
		HotelSystem hotelSystem = new HotelSystem();
		List<Reservation> reservations = hotelSystem.LoadReservationsFromFile();
		List<Reservation> checkedInReservations = reservations
			.Where(r => r.ID == guestID && r.ReservationStatus == "Checked-in")
			.ToList();
		if (checkedInReservations.Count == 0)
		{
			return "No checked-in reservations found for the logged-in guest.";
		}
		Console.WriteLine("Your checked-in reservations:");
		for (int i = 0; i < checkedInReservations.Count; i++)
		{
			Console.WriteLine($"[{i + 1}] Reservation ID: {checkedInReservations[i].RID}, Room Number: {checkedInReservations[i].Number}, Check-in Date: {checkedInReservations[i].CheckInDate}, Check-out Date: {checkedInReservations[i].CheckOutDate}");
		}
		Console.Write("Enter the reservation ID to check-out: ");
		string reservationID = Console.ReadLine();
		Reservation selectedReservation = checkedInReservations.FirstOrDefault(r => r.RID == reservationID);
		if (selectedReservation == null)
		{
			return "Invalid reservation ID.";
		}
		selectedReservation.ReservationStatus = "Checked-out";
		Room room = hotelSystem.LoadRoomsFromFile().FirstOrDefault(r => r.Number == selectedReservation.Number);
		if (room != null)
		{
			room.AvailabilityStatus = true;
			hotelSystem.SaveRoomToFile(room);
		}
		hotelSystem.UpdateReservationInFile(selectedReservation);
		return "Check-out successful. Your reservation status is now 'Checked-out'.";
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
		ReloadData();
	}

	public void ReloadData()
	{
		Rooms = LoadRoomsFromFile();
		Guests = LoadGuestsFromFile();
		Payments = LoadPaymentsFromFile();
		Services = LoadServicesFromFile();
		Reservations = LoadReservationsFromFile();
	}

	public void ViewAllGuests()
	{
		if (Guests != null && Guests.Count > 0)
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
		else
		{
			Console.WriteLine("No Guests Yet");
		}
	}

	public void ViewAllServices()
	{
		if (Services != null && Services.Count > 0)
		{
			int v = 1;
			foreach (Service service in Services)
			{
				Console.Write("[" + v + "]");
				Console.WriteLine(
					$" Service ID : {service.SID}," +
					$" Service Description : {service.Description}," +
					$" Service Notes : {service.Notes}," +
					$" Guest's national ID (who order this service) : {service.ID}"
				);
				v++;
			}
		}
		else
		{
			Console.WriteLine("No Services Yet");
		}
	}

	public void ViewAllPayments()
	{
		if (Payments != null && Payments.Count > 0)
		{
			int v = 1;
			foreach (Payment payment in Payments)
			{
				Console.Write("[" + v + "]");
				Console.WriteLine(
					$" Bill Number : {payment.BillNumber}," +
					$" Payment Source : {payment.PaymentSource}," +
					$" Payment Status : {payment.PaymentStatus}," +
					$" Total Amount : {payment.TotalAmount}," +
					$" Guest's national ID (who made this payment) : {payment.ID}"
				);
				v++;
			}
		}
		else
		{
			Console.WriteLine("No Payments Yet");
		}
	}

	public void ViewAllReservations()
	{
		if (Reservations != null && Reservations.Count > 0)
		{
			int v = 1;
			foreach (Reservation reservation in Reservations)
			{
				Console.Write("[" + v + "]");
				Console.WriteLine(
					$" Reservation ID : {reservation.RID}," +
					$" Check-in Date : {reservation.CheckInDate}," +
					$" Check-out Date : {reservation.CheckOutDate}," +
					$" Reservation Status : {reservation.ReservationStatus}," +
					$" Meals Option : {reservation.MealOption}," +
					$" Guest's national ID (who reserved this room) : {reservation.ID}," +
					$" Room Number : {reservation.Number}"
				);
				v++;
			}
		}
		else
		{
			Console.WriteLine("No Reservations Yet");
		}
	}

	public void ViewAllRooms()
	{
		if (Rooms != null && Rooms.Count > 0)
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
		else
		{
			Console.WriteLine("No Rooms Yet");
		}
	}

	public void UpdateReservationInFile(Reservation updatedReservation)
	{
		List<Reservation> reservations = LoadReservationsFromFile();
		int i = reservations.FindIndex(r => r.RID == updatedReservation.RID);
		if (i != -1)
		{
			reservations[i] = updatedReservation;
			using (FileStream ReservationsDataSave = new FileStream("ReservationFile.txt", FileMode.Create, FileAccess.Write))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Reservation>));
				serializer.Serialize(ReservationsDataSave, reservations);
			}
		}
	}

	public void UpdateRoomFile(Room updatedRoom)
	{
		List<Room> rooms = LoadRoomsFromFile();
		int roomIndex = rooms.FindIndex(r => r.Number == updatedRoom.Number);
		if (roomIndex != -1)
		{
			rooms[roomIndex] = updatedRoom;
			using (FileStream RoomsDataSave = new FileStream("RoomsFile.txt", FileMode.Create, FileAccess.Write))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
				serializer.Serialize(RoomsDataSave, rooms);
			}
		}
	}


	public void UpdateGuestInFile(Guest updatedGuest)
	{
		List<Guest> guests = LoadGuestsFromFile();
		int i = guests.FindIndex(g => g.ID == updatedGuest.ID);
		if (i != -1)
		{
			guests[i] = updatedGuest;
			using (FileStream GuestsDataSave = new FileStream("GuestsFile.txt", FileMode.Create, FileAccess.Write))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Guest>));
				serializer.Serialize(GuestsDataSave, guests);
			}
		}
	}

	public void UpdatePaymentInFile(Payment updatedPayment)
	{
		List<Payment> payments = LoadPaymentsFromFile();
		int i = payments.FindIndex(p => p.BillNumber == updatedPayment.BillNumber);
		if (i != -1)
		{
			payments[i] = updatedPayment;
			using (FileStream PaymentsDataSave = new FileStream("PaymentFile.txt", FileMode.Create, FileAccess.Write))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Payment>));
				serializer.Serialize(PaymentsDataSave, payments);
			}
		}
	}

	public bool LoginM()
	{
		Console.Write("Enter your ID :");
		string id = Console.ReadLine();
		while (id != "m2024")
		{
			Console.Write("Please enter valid ID (Note: There's only one Manager) : ");
			id = Console.ReadLine();
		}
		Console.Write("Enter your Password :");
		string password = Console.ReadLine();
		while (password != "00")
		{
			Console.Write("Please enter correct Password : ");
			password = Console.ReadLine();
		}
		Console.WriteLine("Log-in is successfully done!");
		return true;
	}

	public void LogoutM()
	{
		Console.WriteLine("You logged-out successfully, Goodbye");
	}

	public void NewUser()
	{
		Console.Write("Enter your Name : ");
		string name = Console.ReadLine();
		while (string.IsNullOrWhiteSpace(name))
		{
			Console.Write("Please enter valid Name (Note: Readable Name) : ");
			name = Console.ReadLine();
		}
		Console.WriteLine("");
		Console.Write("Enter your ID : ");
		string id = Console.ReadLine();
		while (id.Length != 5)
		{
			Console.Write("Please enter valid ID (Note: Of 5 digits) : ");
			id = Console.ReadLine();
		}
		Console.WriteLine("");
		Console.Write("Make a Password : ");
		string password = Console.ReadLine();
		while (password.Length != 2)
		{
			Console.Write("Please enter valid Password (Note: Of 2 digits) : ");
			password = Console.ReadLine();
		}
		Console.WriteLine("");
		Console.Write("Enter your PhoneNumber : ");
		string PN = Console.ReadLine();
		double phonenumber;
		while (PN.Length != 5 || !double.TryParse(PN, out phonenumber) || phonenumber == 00000)
		{
			Console.Write("Please enter a valid Phone Number (Note: Of 5 digits) : ");
			PN = Console.ReadLine();
		}
		Console.WriteLine("");
		Console.Write("Enter your Bank information (Balance) : ");
		double Balance;
		while (!double.TryParse(Console.ReadLine(), out Balance) || Balance == 0)
		{
			Console.Write("Please enter valid Bank Account : ");
		}
		Console.WriteLine("");
		Guest NewGuest = new Guest(id, name, password, phonenumber, Balance);
		Console.WriteLine("Your registration is successfully done! Welcome ");
		SaveGuestToFile(NewGuest);
	}

	public void LogoutG()
	{
		Console.WriteLine("Thanks for Choosing us! We hope you had a delightful experience and look forward to welcoming you back soon." +
			"\nGoodbye!");
	}

	public Guest LoginG()
	{
		Console.WriteLine();
		List<Guest> Guests = LoadGuestsFromFile();
		Console.Write("Enter your ID : ");
		string id = Console.ReadLine();
		while (id.Length != 5)
		{
			Console.Write("Please enter valid ID (Note: Of 5 digits) : ");
			id = Console.ReadLine();
		}
		Console.WriteLine("");
		Console.Write("Enter Your Password : ");
		string password = Console.ReadLine();
		while (password.Length != 2)
		{
			Console.Write("Please enter correct Password : ");
			password = Console.ReadLine();
		}
		Guest p = Guests.Find(guest => guest.ID == id && guest.Password == password);
		if (p != null)
		{
			Console.WriteLine("Log-in process is successfully done! Welcome");
			return p;
		}
		else
		{
			Console.WriteLine("Error, re-check your Password or ID, it does not match any in our system!");
			return null;
		}
	}

	public void SaveGuestToFile(Guest guest)
	{
		List<Guest> guests = LoadGuestsFromFile();
		guests.Add(guest);
		using (FileStream GuestsDataSave = new FileStream("GuestsFile.txt", FileMode.Create, FileAccess.Write))
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Guest>));
			serializer.Serialize(GuestsDataSave, guests);
		}
	}

	public void SaveReservationToFile(Reservation reservation)
	{
		List<Reservation> reservations = LoadReservationsFromFile();
		reservations.Add(reservation);
		using (FileStream ReservationsDataSave = new FileStream("ReservationFile.txt", FileMode.Create, FileAccess.Write))
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Reservation>));
			serializer.Serialize(ReservationsDataSave, reservations);
		}
	}

	public void SaveRoomToFile(Room room)
	{
		List<Room> rooms = LoadRoomsFromFile();
		rooms.Add(room);
		using (FileStream RoomsDataSave = new FileStream("RoomsFile.txt", FileMode.Create, FileAccess.Write))
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
			serializer.Serialize(RoomsDataSave, rooms);
		}
	}

	public void SaveServiceToFile(Service service)
	{
		List<Service> services = LoadServicesFromFile();
		services.Add(service);
		using (FileStream ServicesDataSave = new FileStream("ServiceFile.txt", FileMode.Create, FileAccess.Write))
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Service>));
			serializer.Serialize(ServicesDataSave, services);
		}
	}

	public void SavePaymentToFile(Payment payment)
	{
		List<Payment> payments = LoadPaymentsFromFile();
		payments.Add(payment);
		using (FileStream PaymentsDataSave = new FileStream("PaymentFile.txt", FileMode.Create, FileAccess.Write))
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Payment>));
			serializer.Serialize(PaymentsDataSave, payments);
		}
	}

	public List<Guest> LoadGuestsFromFile()
	{
		List<Guest> Guests = new List<Guest>();
		if (File.Exists("GuestsFile.txt"))
		{
			using (FileStream GuestsDataLoad = new FileStream("GuestsFile.txt", FileMode.Open, FileAccess.Read))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Guest>));
				if (GuestsDataLoad.Length > 0)
				{
					Guests = (List<Guest>)serializer.Deserialize(GuestsDataLoad);
				}
			}
		}
		return Guests;
	}

	public List<Room> LoadRoomsFromFile()
	{
		Rooms = new List<Room>();
		if (File.Exists("RoomsFile.txt"))
		{
			using (FileStream RoomsDataLoad = new FileStream("RoomsFile.txt", FileMode.Open, FileAccess.Read))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
				if (RoomsDataLoad.Length > 0)
				{
					Rooms = (List<Room>)serializer.Deserialize(RoomsDataLoad);
				}
			}
		}
		return Rooms;
	}

	public List<Reservation> LoadReservationsFromFile()
	{
		Reservations = new List<Reservation>();
		if (File.Exists("ReservationFile.txt"))
		{
			using (FileStream ReservationsDataLoad = new FileStream("ReservationFile.txt", FileMode.Open, FileAccess.Read))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Reservation>));
				if (ReservationsDataLoad.Length > 0)
				{
					Reservations = (List<Reservation>)serializer.Deserialize(ReservationsDataLoad);
				}
			}
		}
		return Reservations;
	}

	public List<Service> LoadServicesFromFile()
	{
		Services = new List<Service>();
		if (File.Exists("ServiceFile.txt"))
		{
			using (FileStream ServicesDataLoad = new FileStream("ServiceFile.txt", FileMode.Open, FileAccess.Read))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Service>));
				if (ServicesDataLoad.Length > 0)
				{
					Services = (List<Service>)serializer.Deserialize(ServicesDataLoad);
				}
			}
		}
		return Services;
	}

	public List<Payment> LoadPaymentsFromFile()
	{
		Payments = new List<Payment>();
		if (File.Exists("PaymentFile.txt"))
		{
			using (FileStream PaymentsDataLoad = new FileStream("PaymentFile.txt", FileMode.Open, FileAccess.Read))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Payment>));
				if (PaymentsDataLoad.Length > 0)
				{
					Payments = (List<Payment>)serializer.Deserialize(PaymentsDataLoad);
				}
			}
		}
		return Payments;
	}

	public void AddReservation(Reservation reservation)
	{
		Reservations.Add(reservation);
		SaveReservationToFile(reservation);
	}

	public void AddRoom(Room room)
	{
		Rooms.Add(room);
		SaveRoomToFile(room);
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