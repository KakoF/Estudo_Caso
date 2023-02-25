using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SimianCalcEntity : BaseEntity
    {
        
        public int Total { get; private set; }
        public int CountIsSimian { get; private set; }
        public int CountIsHuman { get; private set; }
        public decimal IsSimianPercent { get; private set; }
        public decimal IsHumanPercent { get; private set; }
        public decimal Ratio { get; private set; }

        public SimianCalcEntity(int id, int total, int countIsSimian, int countIsHuman, decimal isSimianPercente, decimal isHumanPercente, decimal ratio, DateTime? createdAt, DateTime? updatedAt) : base(id, createdAt, updatedAt)
        {
            Total = total;
            CountIsSimian = countIsSimian;
            CountIsHuman = countIsHuman;
            IsSimianPercent = isSimianPercente;
            IsHumanPercent = isHumanPercente;
            Ratio = ratio;

        }
    }
}
