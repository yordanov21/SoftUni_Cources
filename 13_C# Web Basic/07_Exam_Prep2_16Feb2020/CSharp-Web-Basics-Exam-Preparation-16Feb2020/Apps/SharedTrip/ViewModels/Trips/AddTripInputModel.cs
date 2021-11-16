using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class AddTripInputModel
    {
        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        //must be string here, not dateTime.
        //EFC can't convert it (after that look TripsController, the validation for DepartureTime format )
        //and parse the DepartureTime in TripsService
        public string DepartureTime { get; set; }

        public string ImagePath { get; set; }

        public int Seats { get; set; }

        public string Description { get; set; }
    }
}
