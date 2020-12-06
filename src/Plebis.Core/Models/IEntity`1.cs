using System;
using System.Linq;

namespace Plebis.Core.Models
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
}
