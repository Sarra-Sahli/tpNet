// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using AM.ApplicationCore.Domain;

Plane plane = new Plane();
plane.Capacity = 8;
plane.MenuFactureDate = DateTime.Now;

Plane plane2 = new Plane(20, DateTime.Now);

//Plane plane = new Plane()
//{
//    Capacity = 1,
//    MenuFactureDate = new DateTime(2022, 01, 01),

//};
Console.WriteLine(plane);
Passenger p1 = new Passenger { FirstName = "sara", LastName = "sahli", EmailAddress="sarra@esprit.tn"};

//Console.WriteLine(p1.CheckProfile("sara", "sahli","sarra@esprit.tn"));
//Staff staff=new Staff();
//Traveller traveller=new Traveller();

//staff.PassengerType();
//p1.PassengerType();
//traveller.PassengerType();

