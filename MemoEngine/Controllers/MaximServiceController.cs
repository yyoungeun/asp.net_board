using MemoEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MemoEngine.Controllers
{
    /// <summary>
    /// 명언(Maxim) 제공 서비스: /api/maximservice/
    /// 기본 뼈대 만드는 것은 Web API 스캐폴딩으로 구현 후 각각의 코드를 구현
    /// </summary>
    public class MaximServiceController : ApiController
    {
        MaximServiceRepository repo = new MaximServiceRepository();

        //Get: api/MaximService
        public IEnumerable<Maxim> Get()
        {
            return repo.GetMaxims().AsEnumerable(); //파라미터를 캐스팅하여 리턴시켜 주기만 한다.
        }

        //GET: api/MaximService/5
        public Maxim Get(int id)
        {
            //데이터 조회
            Maxim maxim = repo.GetMaximById(id);
            if (maxim == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return maxim;
        }

        //POST: api/MaximService
        public HttpResponseMessage Post([FromBody]Maxim maxim)
        {
            if (ModelState.IsValid)
            {
                //데이터 입력
                repo.AddMaxim(maxim);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, maxim); //상태코드와 데이터가 포함된 HTTP응답 메시지
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = maxim.Id })); //지정된 경로에 대한 링크 반환
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);  //400(모델 상태의 오류)
            }
        }

        //PUT: api/MaximService/5
        public HttpResponseMessage Put(int id, [FromBody]Maxim maxim)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != maxim.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest); //400
            }

            //데이터 수정
            repo.UpdateMaxim(maxim);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //DELETE: api/MaximService/5
        public HttpResponseMessage Delete(int id)
        {
            Maxim maxim = repo.GetMaximById(id);
            if (maxim == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound); //404
            }

            //데이터 삭제
            repo.RemoveMaxim(id);

            return Request.CreateResponse(HttpStatusCode.OK, maxim); //HTTP에 대해 정의된 상태코드값이 포함
        }

    }
}
