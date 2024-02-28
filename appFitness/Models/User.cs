
using Microsoft.AspNetCore.Identity;

namespace appFitness.Models
{
    public class User : IdentityUser
    {
        public override string Id { get; set; } = Guid.NewGuid().ToString();
        public int Age { get; set; } = 18;
        public string Goal { get; set; }
        public string Gender { get; set; }
    }
}
