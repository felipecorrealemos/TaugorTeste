using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRFireBase.Models
{
    public class CredenciaisFireBase
    {
        public static string arquivoCredencialJson { get; }
        public static string bucket { get; }
        public static string fireStore { get; }
        public static string documentoFireStore { get; }
        public static string colecao { get; }

        static CredenciaisFireBase()
        {
            arquivoCredencialJson = "triple-skein-255315-firebase-adminsdk-ak660-eb7295e557.json";
            bucket = "triple-skein-255315.appspot.com";
            fireStore = "triple-skein-255315";
            documentoFireStore = "autenticacao";
            colecao = "doc1";
        }

        public static StorageClient GetStorageClient()
        {
            GoogleCredential credential;
            using (var jsonStream = new FileStream(arquivoCredencialJson, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(jsonStream);
            }
            
            return StorageClient.Create(credential);
        }

        public static CollectionReference GetCollectionRef()
        {
            FirestoreDb db = FirestoreDb.Create(CredenciaisFireBase.fireStore);
            return  db.Collection(CredenciaisFireBase.documentoFireStore);
        }
    }
}
