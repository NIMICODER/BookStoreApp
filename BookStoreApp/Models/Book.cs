using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Genre { get; set; }

        [Required]
        public decimal Price { get; set; }
    }



}
