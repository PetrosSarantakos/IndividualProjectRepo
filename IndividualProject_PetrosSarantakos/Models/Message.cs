using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject_PetrosSarantakos.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }



        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }

    }
}
