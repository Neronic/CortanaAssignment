using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApplication.Models
{
    public class People
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int Age { get; set; }
        public string FavouriteColor { get; set; }
        public string Relationship { get; set; }
        public string Sex { get; set; }
        public Location Locale { get; set; }
    }

    public class PeopleManager
    {
        public static List<People> GetPeople()
        {
            var peoples = new List<People>();

            peoples.Add(new People { PersonId = 1, FirstName = "Allison", LastName = "Sevigny", Age = 46, FavouriteColor = "Green", Relationship = "Mother", Sex = "Female", Locale = Locations.Blenheim });
            peoples.Add(new People { PersonId = 2, FirstName = "Jesse", LastName = "Wheeler", Age = 25, FavouriteColor = "Purple", Relationship = "Best Friend", Sex = "Male", Locale = Locations.Toronto });
            peoples.Add(new People { PersonId = 3, FirstName = "Nicholas", LastName = "Williams", Age = 24, FavouriteColor = "Red", Relationship = "Friend", Sex = "Male", Locale = Locations.Kitchener });
            peoples.Add(new People { PersonId = 4, FirstName = "Joan", LastName = "Sevigny", Age = 78, FavouriteColor = "Blue", Relationship = "Grandmother", Sex = "Female", Locale = Locations.Blenheim });
            peoples.Add(new People { PersonId = 5, FirstName = "Zakry", LastName = "Musyj", Age = 25, FavouriteColor = "Green", Relationship = "Friend", Sex = "Male", Locale = Locations.Blenheim });
            peoples.Add(new People { PersonId = 6, FirstName = "Alisha", LastName = "Musyj", Age = 24, FavouriteColor = "Purple", Relationship = "Friend", Sex = "Female", Locale = Locations.Blenheim });
            peoples.Add(new People { PersonId = 7, FirstName = "Andrew", LastName = "Crawford", Age = 26, FavouriteColor = "Red", Relationship = "Friend", Sex = "Male", Locale = Locations.London });
            peoples.Add(new People { PersonId = 8, FirstName = "Nicole", LastName = "Austin", Age = 23, FavouriteColor = "Purple", Relationship = "Friend", Sex = "Female", Locale = Locations.Chatham });
            peoples.Add(new People { PersonId = 9, FirstName = "Rielle", LastName = "Shaw", Age = 24, FavouriteColor = "Yellow", Relationship = "Friend", Sex = "Female", Locale = Locations.Windsor });
            peoples.Add(new People { PersonId = 10, FirstName = "Robert", LastName = "Sevigny", Age = 50, FavouriteColor = "Blue", Relationship = "Uncle", Sex = "Male", Locale = Locations.Caledonia });
            peoples.Add(new People { PersonId = 11, FirstName = "Kayla", LastName = "Adams", Age = 24, FavouriteColor = "Purple", Relationship = "Friend", Sex = "Female", Locale = Locations.Toronto });
            peoples.Add(new People { PersonId = 12, FirstName = "Olivia", LastName = "Martin", Age = 23, FavouriteColor = "Red", Relationship = "Friend", Sex = "Female", Locale = Locations.Chatham });
            peoples.Add(new People { PersonId = 13, FirstName = "Jamie", LastName = "Bennett", Age = 27, FavouriteColor = "Green", Relationship = "Friend", Sex = "Male", Locale = Locations.Toronto });
            peoples.Add(new People { PersonId = 14, FirstName = "Alex", LastName = "Barnier", Age = 25, FavouriteColor = "Purple", Relationship = "Friend", Sex = "Male", Locale = Locations.London });
            peoples.Add(new People { PersonId = 15, FirstName = "Dave", LastName = "Stovell", Age = 30, FavouriteColor = "Red", Relationship = "Teacher", Sex = "Male", Locale = Locations.Welland });
            peoples.Add(new People { PersonId = 16, FirstName = "Marsha", LastName = "Baddeley", Age = 30, FavouriteColor = "Pink", Relationship = "Teacher", Sex = "Female", Locale = Locations.Welland });
            peoples.Add(new People { PersonId = 17, FirstName = "Emilee", LastName = "Elizabeth", Age = 23, FavouriteColor = "Pink", Relationship = "Friend", Sex = "Female", Locale = Locations.Toronto });
            peoples.Add(new People { PersonId = 18, FirstName = "Jordan", LastName = "Barker", Age = 33, FavouriteColor = "Green", Relationship = "Friend", Sex = "Male", Locale = Locations.Toronto });
            peoples.Add(new People { PersonId = 19, FirstName = "Megan", LastName = "Williams", Age = 23, FavouriteColor = "Yellow", Relationship = "Friend", Sex = "Female", Locale = Locations.Kitchener });
            peoples.Add(new People { PersonId = 20, FirstName = "Mohit", LastName = "Mistry", Age = 25, FavouriteColor = "Green", Relationship = "Friend", Sex = "Male", Locale = Locations.Kitchener });

            //peoples.Sort((x, y) => x.LastName.CompareTo(y.LastName));
            return peoples;
        }
    }

    public class Location
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public Location(int id, string name)
        {
            LocationID = id;
            LocationName = name;
        }
    }

    public static class Locations
    {
        public static Location Toronto = new Location(1, "Toronto");
        public static Location Blenheim = new Location(2, "Blenheim");
        public static Location Kitchener = new Location(3, "Kitchener");
        public static Location Windsor = new Location(4, "Windsor");
        public static Location London = new Location(5, "London");
        public static Location Chatham = new Location(6, "Chatham");
        public static Location Caledonia = new Location(7, "Caledonia");
        public static Location Welland = new Location(8, "Welland");

    }
}
//peoples.Add(new People { PersonId =, FirstName = "", LastName = "", Age =, FavouriteColor = "", Relationship = "", Sex = "", Locale = Locations.});

