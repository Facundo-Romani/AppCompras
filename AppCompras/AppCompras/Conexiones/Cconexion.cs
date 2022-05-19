using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;


namespace AppCompras.Conexiones
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://appcompras-5baa3-default-rtdb.firebaseio.com");
    }
}
