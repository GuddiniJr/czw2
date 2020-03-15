using ConsoleApp1.Models;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class EqualityComp : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.Index == y.Index && x.Imie == y.Imie && x.Nazwisko == y.Nazwisko;
        }

        public int GetHashCode(Student obj)
        {
            return obj.Index.GetHashCode();
        }
    }
}