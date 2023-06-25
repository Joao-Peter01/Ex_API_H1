using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    public class IntegracaoProdutoAPI
    {
        public string Url { get; private set; }

        public IntegracaoProdutoAPI(string url)
        {
             Url = url;
        }
        public async Task CadastrarProduto(Cad_Produto novoProduto)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {

                    // Converter o objeto para JSON
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(novoProduto);

                    // Criar um conteúdo HTTP com o JSON
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    // Fazer a requisição POST para a URL da API
                    HttpResponseMessage response = await client.PostAsync(Url, content);


                    // Verificar se a requisição foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        // Ler a resposta como uma string
                        string responseBody = await response.Content.ReadAsStringAsync();
                        // Fazer algo com a resposta da API
                        Console.WriteLine(responseBody);

                    }
                    else
                    {
                        Console.WriteLine("A requisição não foi bem-sucedida. Código de status: " + response.StatusCode);
                    }
                }

                catch (Exception ex)

                {

                    Console.WriteLine("Ocorreu um erro: " + ex.Message);

                }

            }
        }

        public async Task RemoverProduto(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {      
                    // Fazer a requisição POST para a URL da API
                    HttpResponseMessage response = await client.DeleteAsync(Url + "/" + id);


                    // Verificar se a requisição foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        // Ler a resposta como uma string
                        string responseBody = await response.Content.ReadAsStringAsync();
                        // Fazer algo com a resposta da API
                        Console.WriteLine(responseBody);

                    }
                    else
                    {
                        Console.WriteLine("A requisição não foi bem-sucedida. Código de status: " + response.StatusCode);
                    }
                }

                catch (Exception ex)
                {

                    Console.WriteLine("Ocorreu um erro: " + ex.Message);

                }

            }
        }

        public async Task AtualizarProduto(string id , Cad_Produto atualizaProduto)
        {
        using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Converter o objeto para JSON
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(atualizaProduto);

                    // Criar um conteúdo HTTP com o JSON
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    // Fazer a requisição POST para a URL da API
                    HttpResponseMessage response = await client.PutAsync(Url + "/" + id, content);


                     // Verificar se a requisição foi bem-sucedida
                      if (response.IsSuccessStatusCode)
                                {
                                    // Ler a resposta como uma string
                                    string responseBody = await response.Content.ReadAsStringAsync();
                 // Fazer algo com a resposta da API
                    Console.WriteLine(responseBody);

                                }
                                else
                 {
                                 Console.WriteLine("A requisição não foi bem-sucedida. Código de status: " + response.StatusCode);
                 }
                            }

                            catch (Exception ex)

                            {

                Console.WriteLine("Ocorreu um erro: " + ex.Message);

                }

                }
        }

        public async Task ListProduto()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Fazer a requisição GET para a URL da API
                    HttpResponseMessage response = await client.GetAsync(Url);


                    // Verificar se a requisição foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        // Ler a resposta como uma string
                        string responseBody = await response.Content.ReadAsStringAsync();
                        // Fazer algo com a resposta da API
                        Console.WriteLine(responseBody);

                    }
                    else
                    {
                        Console.WriteLine("A requisição não foi bem-sucedida. Produtos: " + response.StatusCode);
                    }
                }

                catch (Exception ex)

                {

                    Console.WriteLine("Ocorreu um erro: " + ex.Message);

                }
            }
        }

        public async Task ExportarCSV(string[] args)
        {
            string json = File.ReadAllText("input.json"); // Ler o JSON de um arquivo

            JArray jsonArray = JArray.Parse(json); // Converter o JSON para um array de objetos

            string csvFilePath = "output.csv"; // Caminho para o arquivo CSV de saída

            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                // Escrever o cabeçalho do CSV
                JObject firstObject = (JObject)jsonArray.First;
                IEnumerable<string> headers = firstObject.Properties().Select(p => p.Name);
                writer.WriteLine(string.Join(",", headers));

                // Escrever os dados do CSV
                foreach (JObject jsonObject in jsonArray)
                {
                    IEnumerable<string> csvFields = jsonObject.Properties().Select(p => (string)p.Value);
                    writer.WriteLine(string.Join(",", csvFields));
                }
            }

            Console.WriteLine("JSON convertido para CSV com sucesso!");
        }
    }


}
}
