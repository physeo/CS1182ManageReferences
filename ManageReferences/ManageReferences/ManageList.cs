//------------------------------------------------------------------
// ManageList Class
// Written by Bryce Graham
// CS 1182
// Stores a static list in which reference objects can be stored
// and accessed from any part of the application.
//------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageReferences
{
    [Serializable]
    class ManageList
    {
        static List<Reference> referenceList = new List<Reference>();

        //------------------------------------------------------------------
        // Returns the list of references
        //------------------------------------------------------------------
        static public List<Reference> ReferenceList
        {
            get { return referenceList; }
        }

        //----------------------------------------------------------------------------------
        // Allows new reference type objects to be added to the list and then sorts them
        //----------------------------------------------------------------------------------
        public static void addReference(Reference newReference)
        {
            referenceList.Add(newReference);
            referenceList.Sort();
        }
    }
}
