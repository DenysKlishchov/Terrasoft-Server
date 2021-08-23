using ASPControl.Abstract;
using System.Web.Mvc;
using ASPControl.Class;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ASPControl.Controllers
{
    using Metrics;
    public class HomeController : Controller
    {
        private string _path;
        public ActionResult Index()
        {
            return View("Default");
        }
        [HttpPost]
        public async Task<string> GetMetricsAsync(string path)
        {
            _path = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<string>(path));
            ITextReader reader = new FileReader(_path);
            TextAnalysis textAnalyzer = new TextAnalysis(reader);
            textAnalyzer.AddMetrics(new SymbolsCount());
            textAnalyzer.AddMetrics(new ExclamationSentences());
            textAnalyzer.AddMetrics(new MostCountChar());
            textAnalyzer.Analyz();

            string answer = "";

            foreach(var item in textAnalyzer.Metrics)
            {
                answer += item.Result() + "; ";
            }


            return await Task.Factory.StartNew(()=> JsonConvert.SerializeObject(answer));
        }
    }
}