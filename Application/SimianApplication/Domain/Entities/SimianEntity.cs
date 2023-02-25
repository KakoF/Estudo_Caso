
namespace Domain.Entities
{
    public class SimianEntity
    {
        
        public SimianEntity(string dna, bool isSimian)
        {
            Dna = dna;
            IsSimian = isSimian;
        }

        public SimianEntity(int id, string dna, bool isSimian, DateTime? createdAt, DateTime? updatedAt)
        {
            Id = id;
            Dna = dna;
            IsSimian = isSimian;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int Id { get; private set; }
        public string Dna { get; private set; }
        public bool IsSimian{ get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public static implicit operator bool(SimianEntity v)
        {
            throw new NotImplementedException();
        }
    }
}
