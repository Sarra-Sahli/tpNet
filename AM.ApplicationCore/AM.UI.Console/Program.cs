// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;



//Plane plane = new Plane();
//plane.Capacity = 8;
//plane.ManufactureDate = DateTime.Now;

//Plane plane2 = new Plane(20, DateTime.Now);

////Plane plane = new Plane()
////{
////    Capacity = 1,
////    MenuFactureDate = new DateTime(2022, 01, 01),

////};
//Console.WriteLine(plane);
//Passenger p1 = new Passenger { FirstName = "sara", LastName = "sahli", EmailAddress="sarra@esprit.tn"};

////Console.WriteLine(p1.CheckProfile("sara", "sahli","sarra@esprit.tn"));
////Staff staff=new Staff();
////Traveller traveller=new Traveller();

////staff.PassengerType();
////p1.PassengerType();
////traveller.PassengerType();



//tp2
FlightMethods fm = new FlightMethods();

//fm.Flights = TestData.listFlights;
//foreach (var flight in fm.GetFlightDates("Paris")) 
//Console.WriteLine(flight);
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2022, 01, 01)));
Console.WriteLine(fm.DurationAverage("Paris"));
foreach (var flight in fm.OrderedDurationFlights())

    //Console.WriteLine(flight);
    //foreach (var traveller in fm.SeniorTravellers(TestData.flight1))
    //{
    //    Console.WriteLine(traveller);
    //}
 fm.DestinationGroupedFlight();

AMContext context = new AMContext();
context.flights.Add(TestData.flight1);
context.SaveChanges();
Console.WriteLine("Ajout avec succes");



