using System;
using Doktori.Models;
using MongoDB.Driver;

namespace Doktori.Interface
{
	public interface IDoctorsList
	{
		IMongoCollection<DoctorEntity> doctorcollection { get; }
		IEnumerable<DoctorEntity> GetAllDoctors ();
		DoctorEntity GetDoctorDetails (string Name);
		void Create (DoctorEntity doctorData);
		void Update (string _id, DoctorEntity doctorData);
		void Delete (string Name);
	}
}

