using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Driver : Person
{
    public Cnh Cnh { get; set; }
}