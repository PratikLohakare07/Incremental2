using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Team
    {
        [Key]
        public int TeamId{get;set;}

        public Name TeamName{get;set;}

        
    }
}