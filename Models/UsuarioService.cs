using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void Inserir(Usuario l)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.usuarios.Add(l);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Usuario l)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.usuarios.Find(l.Id);
                usuario.Id = l.Id;
                usuario.Nome = l.Nome;
                usuario.login = l.login;
                usuario.senha = l.senha;
                usuario.tipo = l.tipo;

                bc.SaveChanges();
            }
        }

        public ICollection<Usuario> ListarTodos()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;
                
                // caso filtro não tenha sido informado
                    query = bc.usuarios;
                                
                //ordenação padrão
                return query.OrderBy(l => l.Id).ToList();
            }
        }
        public Usuario ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.usuarios.Find(id);
            }
        }
        public void ExcluirUsuario(Usuario l)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.usuarios.Remove(l);
                bc.SaveChanges();
            }
        }

        public void Login(Usuario l)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.usuarios.Find(l.login);
                usuario.login = l.login;
                usuario.senha = l.senha;
            }
        }
    }
}