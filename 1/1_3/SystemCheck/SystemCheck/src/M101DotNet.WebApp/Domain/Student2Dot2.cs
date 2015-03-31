using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization; 
using MongoDB.Bson.Serialization.Conventions;

namespace M101DotNet.WebApp.Domain
{
    public class Student2Dot2
    {
        public ObjectId Id { get; set; }

        [MongoDB.Bson.Serialization.Attributes.BsonElement("student_id")]
        public int studentId { get; set; }
        public string type { get; set; }

        public double score { get; set; }
    }
}