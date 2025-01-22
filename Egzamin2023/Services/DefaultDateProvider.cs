// Novytskyi Rostyslav 15204
namespace Egzamin2023.Services
{
    public class DefaultDateProvider : IDateProvider
    {
        public DateTime CurrentDate => DateTime.Now;
    }
}