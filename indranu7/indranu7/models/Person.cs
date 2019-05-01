using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace indranu7.models
{
    public class Person
    {
        public FieldModel Name { get; set; }
        public FieldModel Surname { get; set; }
        public FieldModel Id { get; set; }
        public FieldModel HomeAddress { get; set; }
    }
}
