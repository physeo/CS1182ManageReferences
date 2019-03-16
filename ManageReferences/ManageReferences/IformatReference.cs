// Reference Class
// Written by Bryce Graham
// CS 1182
// Stores the date, title and authors of a reference object

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageReferences
{
    interface  IformatReference
{
    string formatMLA();
    string formatAPA();
    string formatLibMed();
}
}
