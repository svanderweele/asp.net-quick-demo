using System.ComponentModel.DataAnnotations;

namespace GameRentalDemo.Models
{
    public class GameModel
    {
        [KeyAttribute]
        public int Id { get; set; }

        public string Name { get; set; }
        public Genre Genre { get; set; }

        public int InStockCount { get; set; }

    }
    public enum Genre
    {
        [Display(Name ="Action Genre")]
        Action = 0,
        [Display(Name = "Survival Horror Genre")]
        SurvivalHorror = 1,
        [Display(Name = "Platformer Genre")]
        Platformer = 2,
        [Display(Name = "Puzzle Genre")]
        Puzzle = 3,
    }
}
