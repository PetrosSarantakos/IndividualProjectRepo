using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject_PetrosSarantakos.Models;

namespace IndividualProject_PetrosSarantakos
{
    public class MessageManager
    {
        public void SendMessage(string senderId)
        {
            using (var db = new AppContext())
            {
                User sender = db.Users.Find(senderId);
                Console.WriteLine("Who do you want to contact? Enter receiver's username.");
                string receiverId = Console.ReadLine();
                User receiver = db.Users.Find(receiverId);
                Console.WriteLine("Write your message");
                string text = Console.ReadLine();
                Message message = new Message
                {
                    Time = DateTime.Now,
                    Sender = sender,
                    Receiver = receiver,
                    Text = text
                };
                db.Messages.Add(message);
                db.SaveChanges();
            }
            Console.WriteLine("Message sent. Press any key to continue");
            Console.ReadKey();
        }

        public void ViewMessageFromUser(string sender, string receiver)
        {
            List<Message> messages = new List<Message>();
            List<string> log = new List<string>();
            string path = $"from {sender} to {receiver}.txt";
            using (var db = new AppContext())
            {
                messages = db.Messages.Where(m => ((m.Sender.Id == sender) && (m.Receiver.Id == receiver))
                ||((m.Receiver.Id==sender)&&(m.Sender.Id==receiver))).ToList();

                if (messages.Count == 0)
                {
                    Console.WriteLine($"No messages between you and user {receiver}");
                }
                foreach (var item in messages)
                {
                    Console.WriteLine($"from:{item.Sender.Id} to:{item.Receiver.Id} text:{item.Text} \nsent:{item.Time}");
                    log.Add($"from:{item.Sender.Id} to:{item.Receiver.Id} text:{item.Text} \nsent:{item.Time}");
                }
                System.IO.File.Create(path).Close();
            }
            System.IO.File.AppendAllLines(path, log);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
