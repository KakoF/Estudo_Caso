using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SimianEntity
    {
        public void SetId(int id)
        {
            Id = id;
        }
        public SimianEntity(string dna, bool isSimian)
        {
            Dna = dna;
            IsSimian = isSimian;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public string Dna { get; private set; }
        public bool IsSimian{ get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

    }
}
