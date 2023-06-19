using System;
using System.Collections.Generic;
using System.Linq;
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

        //public async Task RemoverProduto()
        //{

        //}

        //public async Task AtualizarProduto()
        //{

        //}

        //public async Task ListProduto()
        //{

        //}


    }
}
