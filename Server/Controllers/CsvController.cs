using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CsvController : ControllerBase
	{
		[HttpGet("read")]
		public IActionResult ReadCsv()
		{
			//string filePath = Path.Combine(Directory.GetCurrentDirectory(), "word.csv");
			string filePath = @"C:\Users\user\Desktop\241203\word.csv";

			if (!System.IO.File.Exists(filePath))
			{
				Console.WriteLine("지정된 경로에 파일이 존재하지 않습니다.");
				return NotFound("CSV 파일이 존재하지 않습니다.");
			}

			using (var reader = new StreamReader(filePath, Encoding.UTF8))
			{
				var content = reader.ReadToEnd();
				return Ok(content);
			}
		}
	}
}
