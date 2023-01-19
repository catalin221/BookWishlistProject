using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaulBejinariu_Project.Models
{
    public class BookRead
    {
        public int Id { get; set; }

        [DisplayName("Time Spent (Hours)"), Range(1, 500)]
        public int TimeSpent { get; set; } = 1;
        
        [DisplayName("Book Title")]
        public int BookId { get; set; }
        public Book? Book { get; set;}
    }
}
