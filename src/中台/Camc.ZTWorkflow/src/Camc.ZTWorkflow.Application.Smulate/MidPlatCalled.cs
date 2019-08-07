using Abp.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Camc.ZTWorkflow.Application.Smulate
{
    public static class MidPlatCalled
    {

		private const string ServerUrlBase = "http://localhost:5081/";
		public static async Task<TOutput> GetMidPlatInterfaceFromWebApi<TOutput>(string currentNamespace, string methodName,Type inputType = null, Object inputObjects = null)
		{
			using (var client = new HttpClient())
			{

				var ZTName = currentNamespace.Split('.')[1];

				var InterfaceName = currentNamespace.Split('.')[currentNamespace.Split('.').Length-1].TrimEnd(new char[] { 'P', 'r', 'o', 'x', 'y'}).TrimEnd(new char[] { 'A','p','p','S','e','r','v','i','c', 'e' }).TrimEnd((new char[] { 'M', 'a', 'n', 'a', 'g', 'e', 'r'}));


				HttpContent inputContent = null;
				if (inputType != null)
				{
					//创建一个处理序列化的DataContractJsonSerializer
					DataContractJsonSerializer serializer = new DataContractJsonSerializer(inputType);
					MemoryStream ms = new MemoryStream();
					//将资料写入MemoryStream
					serializer.WriteObject(ms, inputObjects);
					//一定要在这设定Position
					ms.Position = 0;
					inputContent = new StreamContent(ms);//将MemoryStream转成HttpContent
					inputContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
				}

				var response = client.PostAsync($"{ServerUrlBase}api/services/{ZTName}/{InterfaceName}/{methodName}", inputContent);


				if (!response.Result.IsSuccessStatusCode)
				{
					Console.WriteLine(response.Result.StatusCode);
				}

				var outputContent = await response.Result.Content.ReadAsStringAsync();


				var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse<TOutput>>(outputContent);

				if (!ajaxResponse.Success)
				{
					throw new Exception(ajaxResponse.Error?.Message ?? "Remote service throws exception!");
				}

				return ajaxResponse.Result;


			}
		}
	}
}
