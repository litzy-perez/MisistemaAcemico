namespace MisistemaAcemico.Clases
{
    public class Persona
    {
        private string nombres;
        private string apellidos;

        public string Nombres
        {
            get => nombres;
            set => nombres = string.IsNullOrEmpty(value) ? "" : value;
        }

        public string Apellidos
        {
            get => apellidos;
            set => apellidos = string.IsNullOrEmpty(value) ? "" : value;
        }

        public Persona(string noms = "", string apels = "")
        {
            Nombres = noms;
            Apellidos = apels;
        }

        public virtual void MostrarInfo()
        {
            MessageBox.Show($"{Nombres} {Apellidos}");
        }
    }
}