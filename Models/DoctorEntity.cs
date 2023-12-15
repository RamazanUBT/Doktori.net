using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Doktori.Models
{
	public class DoctorEntity
	{
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string _id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string password { get; set; }


    }
}

