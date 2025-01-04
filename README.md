# Hotel Management System

## Introduction
This project is a console-based Hotel Management System developed in C#.
As a part of Object-Oriented software analysis and design CpE311 - Computer Engineering department - Computer and informatiom technology faculty - Jordan University of science and technology.
It allows users to perform various hotel management tasks such as making reservations, checking in, checking out, requesting services, and managing guests, rooms, payments, and services.

## Features
- **Guest Management**: Register new guests, log in existing guests, and manage guest information.
- **Room Management**: View and update room information, check room availability, and manage room reservations.
- **Reservation Management**: Make, check-in, and check-out reservations.
- **Service Management**: Request and manage hotel services.
- **Payment Management**: Create and manage payment records for reservations and services.
- **Manager Functions**: View all guests, rooms, reservations, services, and payments. Generate profit reports.

## File Structure
- `HotelSystem.cs`: Main file containing all the classes and methods for managing the hotel system.
- `Main.cs`: Contains the main static function which primary to run the whole program

## Classes
- **IOFiles**: Handles file operations for saving and loading data.
- **Guest**: Represents a hotel guest with properties like ID, Name, Password, PhoneNumber, and BankBalance.
- **Manager**: Represents a hotel manager with functions to manage the hotel system.
- **Service**: Represents a service provided by the hotel.
- **Payment**: Represents a payment record for reservations or services.
- **Room**: Represents a hotel room with properties like Number, Type, PricePerDay, and AvailabilityStatus.
- **Reservation**: Represents a room reservation with details like CheckInDate, CheckOutDate, MealOption, and ReservationStatus.
- **HotelSystem**: Main class that manages the overall hotel system, including guests, rooms, reservations, services, and payments.

## Usage
To use the system, run the `Program` class, which will present a menu with the following options:
1. Log-in as Guest
2. Log-in as Manager
3. Sign-in as new Guest
4. Exit (From the system)

## Contact 
For any questions or inquiries, please contact larahishamahmadby@gmail.com or lhbaniyasin22@cit.just.edu.jo
