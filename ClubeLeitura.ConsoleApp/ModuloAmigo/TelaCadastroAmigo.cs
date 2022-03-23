using System;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class Cadastroamigos
    {
        public class TelaCadastroAmigos
        {
            public Amigos[] amigos;
            public int numerodeamigos;
            public Notificador notificador;

            public string MostrarOpcoes()
            {
                Console.Clear();

                Console.WriteLine("Cadastro de Amigos");

                Console.WriteLine();

                Console.WriteLine("Digite 1 para inserir");
                Console.WriteLine("Digite 2 para editar");
                Console.WriteLine("Digite 3 para excluir");
                Console.WriteLine("Digite 4 para visualizar");

                Console.WriteLine("Digite s para sair");

                string opcao = Console.ReadLine();

                return opcao;
            }

            public void InserirNovoAmigo()
            {
                MostrarTitulo("Inserir um amigo novo ");

                Amigos amigo = ObterAmigo();

                amigo.numero = ++numerodeamigos;

                int posicaoVazia = ObterPosicaoVazia();
                amigos[posicaoVazia] = amigo;

                notificador.ApresentarMensagem("Amigo Inserido com sucesso!", "parabens");
            }

            private Amigos ObterAmigo()
            {
                Console.Write("Digite o nome do seu amigo : ");
                string nome = Console.ReadLine();

                Console.Write("Digite o nome do responsável: ");
                string nomedoresponsavel = Console.ReadLine();

                Console.Write("Digite o numero do responsável: ");
                string numeroresponsavel = Console.ReadLine();

                Amigos amigo = new();

                amigo.nomedoamiguinho = nome;
                amigo.nomedoresponsavel = nomedoresponsavel;
                amigo.numerodoresponsavel = numeroresponsavel;


                return amigo;
            }

            public void EditarAmigo()
            {
                MostrarTitulo("Editando Amigo");

                VisualizarAmigo("Pesquisando");

                Console.Write("Digite o número do amigo que deseja editar: ");
                int numeroAmigo = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i].numero == numeroAmigo)
                    {
                        Amigos amigo = ObterAmigo();

                        amigos[i] = amigo;
                        amigos[i].numero = numeroAmigo;

                        break;
                    }
                }

                notificador.ApresentarMensagem("Amigo editado com sucesso", "Sucesso");
            }

            public void MostrarTitulo(string titulo)
            {
                Console.Clear();

                Console.WriteLine(titulo);

                Console.WriteLine();
            }

            public void ExcluirAmigo()
            {
                MostrarTitulo("Excluindo Amigo");

                VisualizarAmigo("Pesquisando");

                Console.Write("Digite o número do amigo que deseja excluir: ");
                int numerodeamigos = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i].numero == numerodeamigos)
                    {
                        amigos[i] = null;
                        break;
                    }
                }

                notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
            }

            public void VisualizarAmigo(string tipo)
            {
                if (tipo == "Tela")
                    MostrarTitulo("Visualização de Revistas");

                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] == null)
                        continue;

                    Amigos a = amigos[i];

                    Console.WriteLine("nome: " + a.nomedoamiguinho);
                    Console.WriteLine("responsável: " + a.nomedoresponsavel);
                    Console.WriteLine("Numero do responsável: " + a.numerodoresponsavel);

                    Console.WriteLine();
                }
            }

            public int ObterPosicaoVazia()
            {
                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] == null)
                        return i;
                }

                return -1;
            }

        }
}