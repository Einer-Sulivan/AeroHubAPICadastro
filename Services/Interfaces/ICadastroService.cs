using AeroHubAPI.DTOs;
using AeroHubAPI.Models;

namespace AeroHubAPI.Services.Interfaces
{
    public interface ICadastroService
    {
        // Cadastro do Cliente (Contratante)
        Task<Pessoa> CadastrarClienteCpfAsync(ClienteCpfCadastroDto dto);
        Task<Pessoa> CadastrarClienteCnpjAsync(ClienteCnpjCadastroDto dto);

        // Cadastro do Piloto
        Task<Pessoa> CadastrarPilotoCpfAsync(PilotoCpfCadastroDto dto);
        Task<Pessoa> CadastrarPilotoCnpjAsync(PilotoCnpjCadastroDto dto);
    }
}