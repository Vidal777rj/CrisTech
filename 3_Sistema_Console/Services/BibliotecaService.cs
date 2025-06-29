
using _3_Sistema_Console.Models;
using System.Runtime.CompilerServices;

namespace _3_Sistema_Console.Services
{
    class BibliotecaService
    {
        private List<Livro> livros = new List<Livro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Emprestimos> emprestimos = new List<Emprestimos>();
        private int livroIdCounter = 0;
        private int usuarioIdCounter = 0;
        private int emprestimoIdCounter = 0;

        public void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n ---------- Menu Biblioteca ----------");
                Console.WriteLine("1 - Gerenciar Livros: ");
                Console.WriteLine("2 - Gerenciar Usuários: ");
                Console.WriteLine("0 - Sair: ");
                Console.Write("Escolha as opções: ");
                string opcaoEscolha = Console.ReadLine();

                switch (opcaoEscolha)
                {
                    case "1": MenuLivro(); break; 
                    case "2": MenuUsuarios(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida"); break;
                }
            }
        }
        //Gerenciamento de Livros
        private void MenuLivro()
        {
            while (true)
            {
                Console.WriteLine("\n ---------- Gerenciamento de Livros ----------");
                Console.WriteLine("1 - Adicionar Livro: ");
                Console.WriteLine("2 - Listar Livros: ");
                Console.WriteLine("3 - Atualizar Livro: ");
                Console.WriteLine("4 - Deletar Livro: ");
                Console.WriteLine("0 - Voltar ao menu principal: ");
                Console.Write("Escolha as opções: ");
                string opcaoEscolha = Console.ReadLine();

                
                switch (opcaoEscolha)
                {

                   case "1": AdicionarLivro(); break;
                   case "2": ListarLivro(); break;
                   case "3": AtualizarLivro(); break;
                   case "4": DeletarLivro(); break;
                   case "0": MenuPrincipal(); break;
                   default: Console.WriteLine("Opção inválida"); break;
                }
                }
                
            }
        //Gerenciar Usuarios
        private void MenuUsuarios()
        {
            while (true)
            {
                Console.WriteLine("\n --- Gerenciar Usuários ---");
                Console.WriteLine("1 - Adicionar Usuário");
                Console.WriteLine("2 - Listar Usuários");
                Console.WriteLine("3 - Atualizar Usuário");
                Console.WriteLine("4 - Deletar Usuário");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.Write("Escolha as opções: ");

                string opcaoEscolha = Console.ReadLine();
                switch (opcaoEscolha)
                {
                    case "1": AdicionarUsuario(); break;
                    case "2": ListarUsuarios(); break;
                    case "3": AtualizarUsuario(); break;
                    case "4": DeletarUsuario(); break;
                    case "0": MenuPrincipal(); break;
                    default: Console.WriteLine("Opção inválida"); break;
                }
                
            } 
        }
         
        //Métodos Livros
        private void AdicionarLivro()
        {
            Console.Write("Digite o titulo do livro: ");
            string tituto = Console.ReadLine();
            Console.Write("Digite o autor do livro: ");
            string autor = Console.ReadLine();

            livros.Add(new Livro { Id = livroIdCounter++, Titulo = tituto, Autor = autor});
            Console.WriteLine($"Livro: {tituto} adicionado com sucesso!");
        }
        private void ListarLivro()
        {
            if(livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro a ser listado, adicione alguns livro pelo menu ");
                return;
            }
            Console.WriteLine("\n ---------- Lista de Livros ----------");
            foreach(Livro livro in livros)
            {
                string status = livro.Disponivel ? "Disponivel" : "Emprestado";
                Console.WriteLine($"Id:{livro.Id} | Titulo: {livro.Titulo} | Autor:{livro.Autor} | Status: {status}");
            }
        }
        private void AtualizarLivro()
        {
            Console.WriteLine("Id do livro que deseja atualizar...");
            Thread.Sleep(2000);
            ListarLivro();
            int id = Convert.ToInt32(Console.ReadLine());
            Livro livro = livros.FirstOrDefault(l =>  l.Id == id);
            if(livro != null)
            {
                Console.Write("Novo Titulo: ");
                livro.Titulo = Console.ReadLine();
                Console.Write("Novo Autor: ");
                livro.Autor = Console.ReadLine();
                Console.WriteLine($"Livro do ID {livro.Id} atualizado com sucesso!");
                ListarLivro();
            }
            else
            {
                Console.WriteLine("Livro não localizado");
            }
        }
        private void DeletarLivro()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro a ser listado para deletado, adicione algum livrom pelo menu ");
                return;
            }
            Console.WriteLine("Id do livro que deseja deletar...");
            Thread.Sleep(2000);
            ListarLivro();
            int id = Convert.ToInt32(Console.ReadLine());
            livros.RemoveAll(l => l.Id == id);
            Console.WriteLine($"Livro com Id: {id} removido com sucesso!");
        }

        //Métodos Usuários
        private void AdicionarUsuario()
        {
            Console.Write("Digite o nome do novo usuário: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o e-mail do novo usuário: ");
            string email = Console.ReadLine();

            usuarios.Add(new Usuario { Id= usuarioIdCounter + 1, Nome = nome, Email=email });
        }
        private void ListarUsuarios()
        {
            Console.WriteLine("Lista de Usuários");
            foreach(Usuario usuario in usuarios)
            {
                Console.WriteLine($"Id: {usuario.Id} | Nome: {usuario.Nome} | Email: {usuario.Email}");
            }
        }
        private void AtualizarUsuario()
        {
            Console.WriteLine("Veja os usuários da seguir e qual deseja atualizar");
            Thread.Sleep(2000);
            ListarUsuarios();
            Console.Write("Digite o Id do usuário a ser atualizado: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if(id != 0)
            {
                Console.Write("Novo nome do usuário: ");
                usuario.Nome = Console.ReadLine();
                Console.Write("Novo e-mail do usuário: ");
                usuario.Email = Console.ReadLine();
                Console.WriteLine($"Usuário com ID: {usuario.Id} atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado");
            }
        }
        private void DeletarUsuario()
        {
            Console.WriteLine(" Qual usuário a ser deletado ");
            Thread.Sleep(2000);
            ListarUsuarios();
            Console.Write("Qual o ID do usuário a ser deletado: ");
            int id = Convert.ToInt32(Console.ReadLine());
            usuarios.RemoveAll(u => u.Id == id);
            Console.WriteLine($"Usuário com Id: {id} deletado com sucesso!");
        }
    }
}
