using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AeroAPI.Controllers
{
    public class PassageiroController : ApiController
    {

        public Passageiro GetPassageiro(int id)
        {
            var db = new DataClasses1DataContext();

            var objPassageiro = db.Passageiros.Where(x => x.Id == id).FirstOrDefault();

            return objPassageiro;

        }

        public HttpResponseMessage PostPassageiro(Passageiro obj)
        {
            var db = new DataClasses1DataContext();

            db.Passageiros.InsertOnSubmit(obj);

            db.SubmitChanges();

            ///Menssagem  de objeto criado
            var objResponse = Request.CreateResponse<Passageiro>(HttpStatusCode.Created, obj);
            string uri = Url.Link("DefaultApi", new { id = obj.Id });
            objResponse.Headers.Location = new Uri(uri);

            return objResponse;
        }

        public void PutPassageiro(int id, Passageiro obj)
        {
            var db = new DataClasses1DataContext();

           var old =  db.Passageiros.Where(x => x.Id == id).FirstOrDefault();

            old.Celular = obj.Celular;
            old.Idade = obj.Idade;
            old.Nome = obj.Nome;

            db.SubmitChanges();

        }

        public void DeletePassageiro(int id)
        {
            var db = new DataClasses1DataContext();

            var obj = db.Passageiros.Where(x => x.Id == id).FirstOrDefault();

            db.Passageiros.DeleteOnSubmit(obj);

            db.SubmitChanges();

        }
    }
}
