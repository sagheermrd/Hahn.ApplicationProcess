using System;
namespace Hahn.ApplicatonProcess.May2020.Data.Models
{
    public class ResponseModel
    {
        public bool? Success { get; set; } 
        public int? StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

    }
}
