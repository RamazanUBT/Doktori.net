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

        public void Delete(string id)
        {
            var filter = Builders<DoctorEntity>.Filter.Eq(c => c._id, id);
            doctorcollection.DeleteOne(filter);
        }

        public IEnumerable<DoctorEntity> GetAllDoctors()
        {
            return doctorcollection.Find(a => true).ToList();
        }

        public DoctorEntity GetDoctorDetails(string id)
        {
            var doctorDetails = doctorcollection.Find(m => m._id == id).FirstOrDefault();
            return doctorDetails;
        }

        public void Update(string _id, DoctorEntity doctorData)
        {
            var filter = Builders<DoctorEntity>.Filter.Eq(c => c._id, _id);
            var update = Builders<DoctorEntity>.Update
                .Set("fullName", doctorData.fullName)
                .Set("email", doctorData.email)
                .Set("password", doctorData.password);

            doctorcollection.UpdateOne(filter, update);
        }
    }
}

