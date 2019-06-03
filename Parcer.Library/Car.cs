using System;
using System.ComponentModel;

namespace Parcer.Library
{
    public class Car : INotifyPropertyChanged
    {
        string name;
        decimal price;
        int year;
        string city;
        string description;
        DateTime publicationDate;
        string imageLink;
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public decimal Price { get { return price; } set { price = value; OnPropertyChanged("Price"); } }
        public int Year { get { return year; } set { year = value; OnPropertyChanged("Year"); } }
        public string City { get { return city; } set { city = value; OnPropertyChanged("City"); } }
        public string Description { get { return description; } set { description = value; OnPropertyChanged("Description"); } }
        public DateTime PublicationDate { get { return publicationDate; } set { publicationDate = value; OnPropertyChanged("PublicationDate"); } }
        public string ImageLink { get { return imageLink; } set { imageLink = value; OnPropertyChanged("ImageLink"); } }
        public Car()
        {
            name = "";
        }
        public Car(string _name)
        {
            name = _name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
