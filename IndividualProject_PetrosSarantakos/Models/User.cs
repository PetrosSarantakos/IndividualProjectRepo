using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject_PetrosSarantakos.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public State UserState { get; set; }
        
        [InverseProperty ("Sender")]
        public ICollection<Message> SentMessages { get; set; }
        [InverseProperty("Receiver")]
        public ICollection<Message> ReceivedMessages { get; set; }        
    }
    public enum State
    {
        user=0,admin,inactive
    }
}
