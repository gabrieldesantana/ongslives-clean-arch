using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngsLives.Domain.Entidades
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Actived { get; set; } = true;
    }
}
