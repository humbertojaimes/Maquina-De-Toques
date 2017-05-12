using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace ControlToques
{

	public enum Gender
	{
		male,
		Female
	}
	[DataTable("Perfiles")]
	public class User:ObservableBaseObject
	{
		private string name;
		[JsonProperty("nombre")]
		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged(); }
		}


		private int age;
		[JsonProperty("edad")]
		public int Age
		{
			get { return age; }
			set { age = value; OnPropertyChanged(); }
		}

		private Gender gender;
		[JsonProperty("genero")]
		public Gender Gender
		{
			get { return gender; }
			set { gender = value; OnPropertyChanged(); }
		}

		private byte[] photo;

		public byte[] Photo
		{
			get { return photo; }
			set { photo = value; OnPropertyChanged(); }
		}


		private string photoName;
		[JsonProperty("imagen")]
		public string PhotoName
		{
			get { return photoName; }
			set { photoName = value; OnPropertyChanged(); }
		}


		private float duration=0;
		[JsonProperty("duracion")]
		public float Duration
		{
			get { return duration; }
			set { duration = value; OnPropertyChanged(); }
		}

		private int intensity=1;
		[JsonProperty("intensidad")]
		public int Intensity
		{
			get { return intensity; }
			set { intensity = value; OnPropertyChanged(); }
		}

	}
}
