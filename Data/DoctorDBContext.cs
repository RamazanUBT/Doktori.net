using System;
using System.Security.Cryptography;
using Doktori.Interface;
using Doktori.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Doktori.Data
{
	public class DoctorDBContext:IDoctorsList
	{
        public readonly IMongoDatabase _db;

        public DoctorDBContext(IOptions<MongoDBSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<DoctorEntity> doctorcollection =>
            _db.GetCollection<DoctorEntity>("doctorsignups");

        public void Create(DoctorEntity doctorData)
        {
            doctorcollection.InsertOne(doctorData);
        }

        public void Delete(string Name)
        {
            var filter = Builders<DoctorEntity>.Filter.Eq(c => c.fullName, Name);
            doctorcollection.DeleteOne(filter);
        }

        public IEnumerable<DoctorEntity> GetAllDoctors()
        {
            return doctorcollection.Find(a => true).ToList();
        }

        public DoctorEntity GetDoctorDetails(string Name)
        {
            var doctorDetails = doctorcollection.Find(m => m.fullName == Name).FirstOrDefault();
            return doctorDetails;
        }

        public void Update(string _id, DoctorEntity doctorData)
        {
            var filter = Builders<DoctorEntity>.Filter.Eq(c => c._id, _id);
            var update = Builders<DoctorEntity>.Update
                .Set("Full Name", doctorData.fullName)
                .Set("Email", doctorData.email)
                .Set("Password", doctorData.password);

            doctorcollection.UpdateOne(filter, update);
        }
    }
}

