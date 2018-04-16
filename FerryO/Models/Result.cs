using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FerryO.Models
{
    public class Results
    {
        public List<Result> ResultsList { get; set; }
    }
    [DataContract]
    public class Result : IResult
    {
        [DataMember]
        [Display(Name="Entry")]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public byte Score { get; set; }
        [DataMember]
        [Display(Name="Time")]
        public TimeSpan CourseTime { get; set; }
        [DataMember]
        [Display(Name="Date")]
        public DateTime DateParticipated { get; set; }
        

        public void Display()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
